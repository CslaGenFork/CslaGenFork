using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CslaGenerator.Data;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using SchemaExplorer;
using SchemaExplorer.Design;


namespace CslaGenerator
{
	/// <summary>
	/// Summary description for GeneratorController.
	/// </summary>
	public class GeneratorController : IDisposable
	{
		#region Private Fields
		private CslaGeneratorUnit _currentUnit = null;
		private CslaObjectInfo _currentCslaObject = null;
		private GeneratorForm frmGenerator = null;
		private static DatabaseSchema _schema = null;
		#endregion

		#region Constructors/Dispose
		public GeneratorController()
		{
			Init();
		}

		private void Init()
		{
			frmGenerator = new GeneratorForm(this);
			frmGenerator.SchemaTree.MouseUp += new MouseEventHandler(SchemaTree_MouseUp);
			frmGenerator.CslaObjectList.SelectedIndexChanged += new EventHandler(CslaObjectList_SelectedIndexChanged);
			frmGenerator.Show();
		}

		public void Dispose()
		{
		}
		#endregion

		#region Main
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			GeneratorController controller = new GeneratorController();
			controller.GeneratorForm.Closing += new CancelEventHandler(controller.GeneratorForm_Closing);
			Application.Run();
		}
		#endregion

		#region Public Properties
		public CslaGeneratorUnit CurrentUnit
		{
			get { return _currentUnit; }
		}

		public GeneratorForm GeneratorForm
		{
			get { return frmGenerator; }
			set { frmGenerator = value; }
		}
		#endregion

		#region Internal Properties
		internal static DatabaseSchema Schema
		{
			get { return _schema; }
		}

		#endregion

		#region Event Handlers
		private void GeneratorForm_Closing(object sender, CancelEventArgs e)
		{
			Application.Exit();
		}

		#endregion

		#region Public Methods

		public void AddNewObject()
		{
			if (_currentUnit != null)
			{
				_currentUnit.CslaObjects.Add(new CslaObjectInfo(_currentUnit));
				_currentCslaObject = _currentUnit.CslaObjects[_currentUnit.CslaObjects.Count - 1];
				// Use output language from the first Csla object of the current unit 
				if (_currentUnit.CslaObjects.Count > 0) { _currentCslaObject.OutputLanguage = _currentUnit.CslaObjects[0].OutputLanguage; }
				_currentCslaObject.ObjectNameChanged += new EventHandler(CslaObject_ObjectNameChanged);
				frmGenerator.CslaObjectList.Items.Add(new DictionaryEntry(_currentCslaObject.ObjectName,_currentCslaObject));
				frmGenerator.CslaObjectList.SelectedIndex = frmGenerator.CslaObjectList.Items.Count - 1;
			}
		}

		public void AddPropertiesForSelectedColumns()
		{
			if (frmGenerator.ColumnList.SelectedIndices.Count > 0)
			{
				StringCollection addedProps = new StringCollection();
				foreach (int index in frmGenerator.ColumnList.SelectedIndices)
				{
					DictionaryEntry e = (DictionaryEntry)frmGenerator.ColumnList.Items[index];
					// use name of column to see if a property of the same name exists
					if (!PropertyExists((string)e.Value))
					{
						object prop = e.Key;
						if (prop is ColumnSchema)
						{
							ValueProperty newProp = new ValueProperty();
							newProp.DbBindColumn.TableSchema = ((ColumnSchema)prop).Table;
							newProp.DbBindColumn.TableColumn = (ColumnSchema)prop;
							newProp.Name = ((ColumnSchema)prop).Name;
							newProp.PropertyType = TypeHelper.GetTypeCodeEx(SchemaUtility.GetSystemType(((ColumnSchema)prop).DataType));
							if (newProp.DbBindColumn.Identity || newProp.DbBindColumn.NativeType == "timestamp")
							{
								newProp.ReadOnly = true; 
								newProp.MarkDirtyOnChange = false;
								newProp.Undoable = false;
							}
							if (((ColumnSchema)prop).IsUnique && newProp.PropertyType == TypeCodeEx.Guid)
								newProp.DefaultValue = "Guid.NewGuid()";
							_currentCslaObject.ValueProperties.Add(newProp);
							addedProps.Add(newProp.Name);
						}
						else if (prop is ViewColumnSchema)
						{
							ValueProperty newProp = new ValueProperty();
							newProp.DbBindColumn.ViewSchema = ((ViewColumnSchema)prop).View;
							newProp.DbBindColumn.ViewColumn = (ViewColumnSchema)prop;
							newProp.Name = ((ViewColumnSchema)prop).Name;
							newProp.PropertyType = TypeHelper.GetTypeCodeEx(SchemaUtility.GetSystemType(((ViewColumnSchema)prop).DataType));
							if (newProp.DbBindColumn.NativeType == "timestamp") 
							{
								newProp.ReadOnly = true; 
								newProp.MarkDirtyOnChange = false;
								newProp.Undoable = false;
							}
							_currentCslaObject.ValueProperties.Add(newProp);
							addedProps.Add(newProp.Name);
						}
						else if (prop is CommandResultColumnSchema)
						{
							ValueProperty newProp = new ValueProperty();
							newProp.DbBindColumn.SpSchema = ((CommandResultColumnSchema)prop).Command.CommandResults[GetCurrentResultSetIndex()];
							newProp.DbBindColumn.SpColumn = (CommandResultColumnSchema)prop;
							newProp.DbBindColumn.SpResultIndex = GetCurrentResultSetIndex();
							newProp.Name = ((CommandResultColumnSchema)prop).Name;
							newProp.PropertyType = TypeHelper.GetTypeCodeEx(SchemaUtility.GetSystemType(((CommandResultColumnSchema)prop).DataType));
							if (newProp.DbBindColumn.NativeType == "timestamp")
							{
								newProp.ReadOnly = true; 
								newProp.MarkDirtyOnChange = false;
								newProp.Undoable = false;
							}
							_currentCslaObject.ValueProperties.Add(newProp);
							addedProps.Add(newProp.Name);
						}
						else
						{
							throw new InvalidOperationException("Unexpected column schema type.");
						}
					}
				}

				// Add Get-, New- and DeleteObjectCriteria and linked parameters 
				AddCriteriaAndParameters();

				// Display message to the user 
				if (addedProps.Count > 0)
				{
					StringBuilder sb = new StringBuilder();
					sb.Append("Successfully added the following properties:" + Environment.NewLine);
					foreach (string propName in addedProps)
					{	
						sb.Append("\t" + propName + Environment.NewLine);
					}
					MessageBox.Show(frmGenerator,sb.ToString(),"Properties Added Successfully");
				}
				else
				{
					MessageBox.Show(frmGenerator,"All columns selected already have corresponding properties", "Properties Already Exist");
				}
			}
		}

		public void AddCriteriaAndParameters()
		{
			ArrayList primaryKeyProperties = new ArrayList();
			ValueProperty timeStampProperty = null;

			// retrieve all primary key and timestamp properties 
			foreach (ValueProperty prop in _currentCslaObject.ValueProperties) 
			{
				if (prop.DbBindColumn.IsPrimaryKey()) 
				{ 
					primaryKeyProperties.Add(prop); 
				}
				else if (prop.DbBindColumn.NativeType == "timestamp")
				{
					timeStampProperty = prop;
				}
			}

			if (primaryKeyProperties.Count > 0 || timeStampProperty != null)
			{
				// Try to find default Criteria object 
				Criteria defaultCriteria = _currentCslaObject.CriteriaObjects.Find("Criteria");

				// If one of the criteria objects is not set 
				if (_currentCslaObject.GetObjectCriteriaType == null || 
					_currentCslaObject.NewObjectCriteriaType == null ||
					_currentCslaObject.DeleteObjectCriteriaType == null)
				{
					// If default criteria doesn't exists, create a new criteria 
					if (defaultCriteria == null) 
					{
						defaultCriteria = new Criteria();
						defaultCriteria.Name = "Criteria";
						_currentCslaObject.CriteriaObjects.Add(defaultCriteria);
					}

					if (_currentCslaObject.GetObjectCriteriaType == null) { _currentCslaObject.GetObjectCriteriaType = defaultCriteria; }
					if (_currentCslaObject.ObjectType != CslaObjectType.ReadOnlyObject) 
					{
						if (_currentCslaObject.NewObjectCriteriaType == null) { _currentCslaObject.NewObjectCriteriaType = defaultCriteria; }
						if (_currentCslaObject.DeleteObjectCriteriaType == null) { _currentCslaObject.DeleteObjectCriteriaType = defaultCriteria; }
					}
				}

				// Refresh criteria properties and parameters for Get, New and Delete methods 
				if (_currentCslaObject.GetObjectCriteriaType != null) 
				{
					AddPropertiesToCriteria(primaryKeyProperties, null, _currentCslaObject.GetObjectCriteriaType);
					foreach (Property prop in _currentCslaObject.GetObjectCriteriaType.Properties)
					{
						if (!_currentCslaObject.GetObjectParameters.Contains(_currentCslaObject.GetObjectCriteriaType, prop))
						{
							_currentCslaObject.GetObjectParameters.Add(new Parameter(_currentCslaObject.GetObjectCriteriaType, prop));
						}
					}
				}
				if (_currentCslaObject.NewObjectCriteriaType != null)
				{
					AddPropertiesToCriteria(primaryKeyProperties, null, _currentCslaObject.NewObjectCriteriaType);
					foreach (Property prop in _currentCslaObject.NewObjectCriteriaType.Properties)
					{
						if (!_currentCslaObject.NewObjectParameters.Contains(_currentCslaObject.NewObjectCriteriaType, prop))
						{
							_currentCslaObject.NewObjectParameters.Add(new Parameter(_currentCslaObject.NewObjectCriteriaType, prop));
						}
					}
				}
				if (_currentCslaObject.DeleteObjectCriteriaType != null)
				{
					AddPropertiesToCriteria(primaryKeyProperties, timeStampProperty, _currentCslaObject.DeleteObjectCriteriaType);
					foreach (Property prop in _currentCslaObject.DeleteObjectCriteriaType.Properties)
					{
						if (!_currentCslaObject.DeleteObjectParameters.Contains(_currentCslaObject.DeleteObjectCriteriaType, prop))
						{
							_currentCslaObject.DeleteObjectParameters.Add(new Parameter(_currentCslaObject.DeleteObjectCriteriaType, prop));
						}
					}
				}
				
				// Refresh Equals, HashCode and ToString properties 
				foreach (ValueProperty prop in primaryKeyProperties)
				{
					if (!_currentCslaObject.EqualsProperty.Contains(prop))
					{
						_currentCslaObject.EqualsProperty.Add(prop);
					}
					if (!_currentCslaObject.HashcodeProperty.Contains(prop))
					{
						_currentCslaObject.HashcodeProperty.Add(prop);
					}
					if (!_currentCslaObject.ToStringProperty.Contains(prop))
					{
						_currentCslaObject.ToStringProperty.Add(prop);
					}
				}
			}
		}

		// Helper function for AddCriteriaAndParameters method 
		private void AddPropertiesToCriteria(ArrayList primaryKeyProperties, ValueProperty timeStampProperty, Criteria crit)
		{
			// Add all primary key properties to critera if they dont already exist 
			foreach (ValueProperty prop in primaryKeyProperties)
			{
				if (!crit.Properties.Contains(prop.Name))
				{
					crit.Properties.Add(new Property(prop.Name, prop.PropertyType));
				}
			}

			// Add timestamp property to criteria if it not already exist 
			if (timeStampProperty != null)
			{
				if (!crit.Properties.Contains(timeStampProperty.Name))
				{
					crit.Properties.Add(new Property(timeStampProperty.Name, timeStampProperty.PropertyType));
				}
			}
		}

		public void Connect()
		{
			ConnectionForm frmConn = new ConnectionForm();
			DialogResult result = frmConn.ShowDialog();
			if (result == DialogResult.OK)
			{
				Cursor.Current = Cursors.WaitCursor;
				BuildSchemaTree(ConnectionFactory.ConnectionString);
				Cursor.Current = Cursors.Default;
			}
		}

		public void DeleteObject()
		{
			if (_currentCslaObject != null && _currentUnit != null)
			{
				int currentIndex = 0;
				if (frmGenerator.CslaObjectList.SelectedIndices.Count > 0)
				{
					currentIndex = frmGenerator.CslaObjectList.SelectedIndices[0];
					CslaObjectInfo obj = (CslaObjectInfo)((DictionaryEntry)frmGenerator.CslaObjectList.Items[currentIndex]).Value;
					_currentUnit.CslaObjects.Remove(obj);
					BindCslaList();
				}
				
				if (frmGenerator.CslaObjectList.Items.Count > 0)
				{
					if (currentIndex+1 < frmGenerator.CslaObjectList.Items.Count)
					{
						frmGenerator.CslaObjectList.SelectedIndex = currentIndex;
					}
					else
					{
						currentIndex--;
						if (currentIndex < 0) { currentIndex = 0; }
						frmGenerator.CslaObjectList.SelectedIndex = currentIndex;
					}
				}
				else
				{
					AddNewObject();
				}
			}
		}

		public void DuplicateObject()
		{
			if (_currentCslaObject != null)
			{
				_currentUnit.CslaObjects.Add(_currentCslaObject.Duplicate(_schema));
				_currentCslaObject = _currentUnit.CslaObjects[_currentUnit.CslaObjects.Count -1];
				_currentCslaObject.ObjectNameChanged += new EventHandler(CslaObject_ObjectNameChanged);
				frmGenerator.CslaObjectList.Items.Add(new DictionaryEntry(_currentCslaObject.ObjectName,_currentCslaObject));
				frmGenerator.CslaObjectList.SelectedIndex = frmGenerator.CslaObjectList.Items.Count - 1;
			}
		}

//		Obsolete.
//		Probeably will be removed in next versions.
//
//		public void ExecuteDelete()
//		{
//			ExecuteProcedure(_currentCslaObject.DeleteProcedure);
//		}
//
//		public void ExecuteInsert()
//		{
//			ExecuteProcedure(_currentCslaObject.InsertProcedure);
//		}
//
//		public void ExecuteSelect()
//		{
//			ExecuteProcedure(_currentCslaObject.SelectProcedure);
//		}
//
//		public void ExecuteUpdate()
//		{
//			ExecuteProcedure(_currentCslaObject.UpdateProcedure);
//		}
//
//		public void ExecuteProcedure(string sql)
//		{
//			SqlConnection cn = null;
//			try
//			{
//				if (ConnectionFactory.ConnectionString != "")
//				{
//					// if multiple statements, parse and execute individually
//					string matchString = "\n[Gg][Oo]";
//					Regex regex = new Regex(matchString,RegexOptions.Multiline);
//
//					string[] sqlStatements = regex.Split(sql);
//
//					cn = ConnectionFactory.NewConnection;
//					SqlCommand cmd = cn.CreateCommand();
//
//					cmd.CommandType = CommandType.Text;
//					cmd.Connection.Open();
//					
//					for (int i = 0; i < sqlStatements.Length; i++)
//					{
//						cmd.CommandText = sqlStatements[i];
//						cmd.ExecuteNonQuery();
//					}
//				}
//			}
//			catch (SqlException e)
//			{
//				MessageBox.Show(frmGenerator,e.Message,"Database Error");
//			}
//			finally
//			{
//				if (cn != null && cn.State == ConnectionState.Open)
//				{
//					cn.Close();
//				}
//			}
//		}
		
		public void Load(string fileName)
		{
			FileStream fs = null;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				fs = File.Open(fileName,FileMode.Open);
				XmlSerializer s = new XmlSerializer(typeof(CslaGeneratorUnit));
				_currentUnit = (CslaGeneratorUnit)s.Deserialize(fs);
				_currentUnit.ResetParent();
				_currentCslaObject = null;

				BindControls();

				ConnectionFactory.ConnectionString = _currentUnit.ConnectionString;
				// check if this is a valid connection, else let the user enter new connection info
				SqlConnection cn = null;
				try
				{
					cn = ConnectionFactory.NewConnection;
					cn.Open();
					BuildSchemaTree(_currentUnit.ConnectionString);
				}
				catch (SqlException e)
				{
					// call connect function which will allow user to enter new info
					Connect();
				}
				finally
				{
					if (cn != null && cn.State == ConnectionState.Open)
					{
						cn.Close();
					}
				}
				
				foreach (CslaObjectInfo info in _currentUnit.CslaObjects)
				{
					if (_schema != null)
					{
						info.LoadColumnInfo(_schema);
					}
					info.InheritedType.Parent = info;
					info.ObjectNameChanged += new EventHandler(CslaObject_ObjectNameChanged);
					EnableButtons();
				}
				if (_currentUnit.CslaObjects.Count > 0)
				{
					_currentCslaObject = _currentUnit.CslaObjects[0];
				}
				else { AddNewObject(); }
				frmGenerator.PropertyGrid.SelectedObject = _currentCslaObject;
			}
			catch (Exception e)
			{
				MessageBox.Show(frmGenerator,"An error occurred while trying to load: " + Environment.NewLine + e.Message + Environment.NewLine + e.StackTrace, "Loading Error");
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				fs.Close();	
			}
		}

		public void NewCslaUnit()
		{
			_currentUnit = new CslaGeneratorUnit();
			_currentCslaObject = null;
			_currentUnit.ConnectionString = ConnectionFactory.ConnectionString;
			BindControls();
			EnableButtons();
		}

		public void Save(string fileName)
		{
			FileStream fs = null;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				fs = File.Open(fileName,FileMode.Create);
				XmlSerializer s = new XmlSerializer(typeof(CslaGeneratorUnit));
				s.Serialize(fs,_currentUnit);
			}
			catch (Exception e)
			{
				MessageBox.Show(frmGenerator,"An error occurred while trying to save: " + Environment.NewLine + e.Message, "Save Error");
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				fs.Close();
			}
		}
		#endregion

		#region Private Methods
		private void BindControls()
		{
			if (_currentUnit != null)
			{
				frmGenerator.ProjectNameTextBox.DataBindings.Clear();
				frmGenerator.ProjectNameTextBox.DataBindings.Add("Text",_currentUnit,"ProjectName");

				frmGenerator.TargetDirectoryTextBox.DataBindings.Clear();
				frmGenerator.TargetDirectoryTextBox.DataBindings.Add("Text",_currentUnit,"TargetDirectory");
			
				BindCslaList();
			}
		}

		private void BindCslaList()
		{
			if (_currentUnit != null)
			{
				// Bind object list
				frmGenerator.CslaObjectList.Items.Clear();
				frmGenerator.CslaObjectList.DisplayMember = "key";
				frmGenerator.CslaObjectList.ValueMember = "value";

				int index = 0;
				// Save index of current object if one is selected.
				if (_currentCslaObject != null)
				{
					int count = 0;
					foreach (CslaObjectInfo info in _currentUnit.CslaObjects)
					{
						frmGenerator.CslaObjectList.Items.Add(new DictionaryEntry(info.ObjectName,info));
						if (_currentCslaObject == info)
						{
							index = count;
						}
						count++;
					}
				}
				else
				{
					foreach (CslaObjectInfo info in _currentUnit.CslaObjects)
					{
						frmGenerator.CslaObjectList.Items.Add(new DictionaryEntry(info.ObjectName,info));
					}
				}
				
				if (frmGenerator.CslaObjectList.Items.Count > 0)
				{
					_currentCslaObject = (CslaObjectInfo)((DictionaryEntry)frmGenerator.CslaObjectList.Items[index]).Value;
					frmGenerator.PropertyGrid.SelectedObject = _currentCslaObject;
					frmGenerator.CslaObjectList.SelectedIndex = index;
				}
				else
				{
					AddNewObject();
				}
			}
		}

		private void BuildSchemaTree(string connectionString)
		{
			// Get Schema
			try
			{
				frmGenerator.SchemaTree.Nodes.Clear();

				_schema = new DatabaseSchema(new SqlSchemaProvider(), connectionString);
				if (_currentUnit != null)
				{
					_currentUnit.ConnectionString = ConnectionFactory.ConnectionString;
				}

				#region  Add Tables
				TreeNode tableBaseNode = null;
				TreeNode[] tableNodes = new TreeNode[_schema.Tables.Count];
				for (int i = 0; i < _schema.Tables.Count; i++)
				{
					tableNodes[i] = new TreeNode(_schema.Tables[i].Name);
					tableNodes[i].Tag = _schema.Tables[i];
				}
				if (_schema.Tables.Count > 0)
				{
					Array.Sort(tableNodes,new TreeNodeComparer());
					tableBaseNode = new TreeNode("Tables",tableNodes);
				}
				else 
				{
					tableBaseNode = new TreeNode("Tables");
				}
				frmGenerator.SchemaTree.Nodes.Add(tableBaseNode);
				#endregion
			
				#region Add Views
				TreeNode viewBaseNode = null;
				TreeNode[] viewNodes = new TreeNode[_schema.Views.Count];
				for (int i = 0; i < _schema.Views.Count; i++)
				{
					viewNodes[i] = new TreeNode(_schema.Views[i].Name);
					viewNodes[i].Tag = _schema.Views[i];
				}
				if (_schema.Views.Count > 0)
				{
					Array.Sort(viewNodes,new TreeNodeComparer());
					viewBaseNode = new TreeNode("Views",viewNodes);
				}
				else 
				{
					viewBaseNode = new TreeNode("Views");
				}
				frmGenerator.SchemaTree.Nodes.Add(viewBaseNode);
			#endregion

				#region Add Stored Procs
				TreeNode spBaseNode = null;
				ArrayList spNodes = new ArrayList();
				for (int i = 0; i < _schema.Commands.Count; i++)
				{
					try
					{
						if (_schema.Commands[i].CommandResults.Count > 0)
						{
							TreeNode[] resultNodes = new TreeNode[_schema.Commands[i].CommandResults.Count];
							// Add result nodes
							for (int j=0; j < _schema.Commands[i].CommandResults.Count; j++)
							{
								resultNodes[j] = new TreeNode("Result Set " + _schema.Commands[i].CommandResults[j].Name);
								resultNodes[j].Tag = _schema.Commands[i].CommandResults[j];
							}
							TreeNode node = new TreeNode(_schema.Commands[i].Name,resultNodes);
							node.Tag = _schema.Commands[i];
							spNodes.Add(node);
						}
					}
					catch (SqlException e)
					{
						// if this error was created by a user (probably invalid proc),
						// then continue, else if problem is more severe, throw exception
						byte maxSeverity = 0;
						foreach (SqlError err in e.Errors)
						{
							if (err.Class > maxSeverity) { maxSeverity = err.Class; }
						}
						if (maxSeverity > 16) { throw e; }
					}
				}
				if (_schema.Commands.Count > 0)
				{
					TreeNode[] children = new TreeNode[spNodes.Count];
					spNodes.CopyTo(children);
					Array.Sort(children,new TreeNodeComparer());
					spBaseNode = new TreeNode("Stored Procedures",children);
				}
				else 
				{
					spBaseNode = new TreeNode("Stored Procedures");
				}
				frmGenerator.SchemaTree.Nodes.Add(spBaseNode);

			#endregion
			}
			catch (SqlException e)
			{
				_schema = null;
				MessageBox.Show(frmGenerator,e.Message,"Database Error");
			}
		}

		private void EnableButtons()
		{
			frmGenerator.AddPropertiesButtton.Enabled = true;
			frmGenerator.AddObjectButton.Enabled = true;
			frmGenerator.DeleteObjectButton.Enabled = true;
			frmGenerator.SaveButton.Enabled = true;
			frmGenerator.DuplicateButton.Enabled = true;
			frmGenerator.ConnectButton.Enabled = true;
			frmGenerator.SelectDirectoryButton.Enabled = true;
		}

		private string GetFileNameWithoutExtension(string fileName)
		{
			int index = fileName.LastIndexOf(".");
			if (index >= 0)
			{
				return fileName.Substring(0,index);
			}
			return fileName;
		}

		private string GetFileExtension(string fileName)
		{
			int index = fileName.LastIndexOf(".");
			if (index >= 0)
			{
				return fileName.Substring(index+1);
			}
			return ".cs";
		}

		private int GetCurrentResultSetIndex()
		{
			// this is a hack because the CommandResultColumnSchema does not store a reference to its  CommandResult
			return frmGenerator.SchemaTree.SelectedNode.Index;
		}
		
		private string GetTemplateName(CslaObjectInfo info)
		{
			switch (info.ObjectType)
			{
				case CslaObjectType.EditableRoot:
					return ConfigurationSettings.AppSettings["EditableRootTemplate"];
				case CslaObjectType.EditableChild:
					return ConfigurationSettings.AppSettings["EditableChildTemplate"];
				case CslaObjectType.EditableRootCollection:
					return ConfigurationSettings.AppSettings["EditableRootCollectionTemplate"];
				case CslaObjectType.EditableChildCollection:
					return ConfigurationSettings.AppSettings["EditableChildCollectionTemplate"];
				case CslaObjectType.EditableSwitchable:
					return ConfigurationSettings.AppSettings["EditableSwitchableTemplate"];
				case CslaObjectType.ReadOnlyObject:
					return ConfigurationSettings.AppSettings["ReadOnlyObjectTemplate"];
				case CslaObjectType.ReadOnlyCollection:
					return ConfigurationSettings.AppSettings["ReadOnlyCollectionTemplate"];
				default:
					return String.Empty;
			}
		}

		private bool PropertyExists(string name)
		{
			if (_currentCslaObject.InheritedValueProperties.Contains(name) ||
				_currentCslaObject.InheritedChildProperties.Contains(name) ||
				_currentCslaObject.InheritedChildCollectionProperties.Contains(name) ||
				_currentCslaObject.ValueProperties.Contains(name) ||
				_currentCslaObject.ChildProperties.Contains(name) ||
				_currentCslaObject.ChildCollectionProperties.Contains(name))
			{
				return true;
			}
			else
				return false;
		}
		#endregion

		#region Event Handlers
		private void SchemaTree_MouseUp(object sender, MouseEventArgs e)
		{
			frmGenerator.ColumnList.Items.Clear();
			TreeNode node = frmGenerator.SchemaTree.GetNodeAt(e.X,e.Y);
			if (node != null)
			{
				if (node.Tag != null)
				{
					if (node.Tag is TableSchema)
					{
						foreach(ColumnSchema column in ((TableSchema)node.Tag).Columns)
						{
							frmGenerator.ColumnList.Items.Add(new DictionaryEntry(column,column.Name));
						}
					}
					else if (node.Tag is ViewSchema)
					{
						foreach(ViewColumnSchema column in ((ViewSchema)node.Tag).Columns)
						{
							frmGenerator.ColumnList.Items.Add(new DictionaryEntry(column,column.Name));
						}
					}
					else if (node.Tag is CommandResultSchema)
					{
						foreach(CommandResultColumnSchema column in ((CommandResultSchema)node.Tag).Columns)
						{
							frmGenerator.ColumnList.Items.Add(new DictionaryEntry(column,column.Name));
						}
					}
				}
			}
		}

		private void CslaObjectList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (frmGenerator.CslaObjectList.SelectedIndices.Count > 0)
			{
				int index = frmGenerator.CslaObjectList.SelectedIndex;
				_currentCslaObject = (CslaObjectInfo)((DictionaryEntry)frmGenerator.CslaObjectList.Items[index]).Value;
				frmGenerator.PropertyGrid.SelectedObject = _currentCslaObject;
				ChildProperty.Parent = _currentCslaObject;
			}
		}

		private void CslaObject_ObjectNameChanged(object sender, EventArgs e)
		{
			BindCslaList();
		}
		#endregion
	}
}
