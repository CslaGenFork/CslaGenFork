using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
	public class PropertyNameChangedEventArgs : EventArgs
	{
		public string OldName;
		public string NewName;

		public PropertyNameChangedEventArgs(string oName, string nName)
		{
			OldName = oName;
			NewName = nName;
		}
	}

	public delegate void PropertyNameChanged(ValueProperty sender, PropertyNameChangedEventArgs e);

	/// <summary>
	/// Summary description for ValueProperty.
	/// </summary>
	[Serializable]
	public class ValueProperty : Property, IBoundProperty
	{
		public enum DataAccessBehaviour
		{
			ReadWrite,
			ReadOnly,
			WriteOnly,
			UpdateOnly,
			CreateOnly 
		}

		public enum UserDefinedKeyBehaviour
		{
			Default,
			UserProvidedPK, 
			DBProvidedPK
        }

        #region Private Fields

        private RuleCollection _rules = new RuleCollection();
		private DbBindColumn _dbBindColumn = new DbBindColumn();
        private string _fkConstraint = String.Empty;
        private bool _markDirtyOnChange = true;
		private bool _undoable = true;
        private string _defaultValue = string.Empty;
        private string _friendlyName = string.Empty;
        private PropertyDeclaration _declarationMode;
        private string _implements = string.Empty;
        private string[] _attributes = new string[] { };
        private string _allowReadRoles = string.Empty;
        private string _allowWriteRoles = string.Empty;
        private string _denyReadRoles = string.Empty;
        private string _denyWriteRoles = string.Empty;
        private PropertyAccess _access = PropertyAccess.IsPublic;
		private DataAccessBehaviour _dataAccess = DataAccessBehaviour.ReadWrite;
		private UserDefinedKeyBehaviour _primaryKey = UserDefinedKeyBehaviour.Default;
		private AccessorVisibility _propSetAccessibility = AccessorVisibility.Default;
        private TypeCodeEx _backingFieldType = TypeCodeEx.Empty;

        #endregion

        #region Properties

        #region Database Related

        [Category("Database Related")]
        [Editor(typeof(DbBindColumnEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(DbBindColumnConverter))]
        [Description("The database column this property is bound to.")]
        public virtual DbBindColumn DbBindColumn
        {
            get { return _dbBindColumn; }
            set
            {
                _dbBindColumn = value;
                ResetProperties(value);
            }
        }

        [Category("Database Related")]
        [Description("When \"PrimaryKey\" is set to \"Default\", this controls the data flow of the property. Using the legend \"C=Create\", \"R=Read\", \"U=Update\" and \"x=no op\", the rules are as follows:" +
            "\r\n\tReadWrite=CRU (full access)" +
            "\r\n\tReadOnly=xRx (can't write)" +
            "\r\n\tWriteOnly=CxU (can't read)" +
            "\r\n\tUpdateOnly=xRU (can't create)" +
            "\r\n\tCreateOnly=CRx (can't update)"+
            "")]
        public virtual DataAccessBehaviour DataAccess
        {
            get { return _dataAccess; }
            set { _dataAccess = value; }
        }

        [Category("Database Related")]
        [Description("The type of primary key or \"Default\" to none.")]
        public virtual UserDefinedKeyBehaviour PrimaryKey
		{
			get { return _primaryKey; }
			set { _primaryKey = value; }
		}

        [Category("Database Related")]
        [Description("Use this foreign key constraint to find the property value.")]
        public virtual string FKConstraint
        {
            get { return _fkConstraint; }
            set { _fkConstraint = value; }
        }

		[Category("Database Related")]
        [Description("The stored procedure parameter name.")]
        public override string ParameterName
		{
			get 
			{
                if (base._parameterName.Equals(String.Empty))
                {
                    if (!string.IsNullOrEmpty(DbBindColumn.ColumnName))
                        return DbBindColumn.ColumnName;

                    return Name;
                }
				return _parameterName;
			}
			set { _parameterName = value; }
        }

        #endregion

        #region Definition

        public override string Name
        {
            get { return base.Name; }
            set
            {
                PropertyNameChangedEventArgs e;
                e = new PropertyNameChangedEventArgs(base.Name, value);
                base.Name = value;
                if (Changed != null)
                    Changed(this, e);

            }
        }

        [Category("Definition")]
        [Description("This is a description.")]
        public string FriendlyName
        {
            get
            {
                if (string.IsNullOrEmpty(_friendlyName))
                    return SplitOnCaps(base.Name);
                return _friendlyName;
            }
            set
            {
                if (value != null && !value.Equals(SplitOnCaps(base.Name)))
                    _friendlyName = value;
                else
                    _friendlyName = string.Empty;
            }
        }

        public override TypeCodeEx PropertyType
        {
            get { return base.PropertyType; }
            set { base.PropertyType = value; }
        }
       
        [Category("Definition")]
        [Description("Property Declaration Mode.")]
        public PropertyDeclaration DeclarationMode
        {
            get { return _declarationMode; }
            set { _declarationMode = value; }
        }

        [Category("Definition")]
        [Description("Type of Backing Field of the Property.")]
        public TypeCodeEx BackingFieldType
        {
            get { return _backingFieldType; }
            set { _backingFieldType = value; }
        }

        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set { base.ReadOnly = value; }
        }

        public override bool Nullable
        {
            get { return base.Nullable; }
            set { base.Nullable = value; }
        }

        [Category("Definition")]
        [Description("This is a description.")]
        public virtual string DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        [Category("Definition")]
        [Description("This is a description.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        public virtual RuleCollection Rules
        {
            get { return _rules; }
        }

        #endregion

        #region Definition (Advanced)

        [Category("Definition (Advanced)")]
        [Description("This is a description.")]
        public virtual string Implements
        {
            get { return _implements; }
            set
            {
                if (value != null)
                    _implements = value;
            }
        }

        [Category("Definition (Advanced)")]
        [Description("This is a description.")]
        public virtual string[] Attributes
        {
            get { return _attributes; }
            set
            {
                if (value != null)
                    _attributes = value; 
            }
        }

        #endregion

        #region Definition (Authorization)

        [Category("Definition (Authorization)")]
        [Description("Roles allowed to read the property. Multiple roles must be separated with ;")]
        public virtual string AllowReadRoles
        {
            get { return _allowReadRoles; }
            set
            {
                if (value != null)
                    _allowReadRoles = value;
            }
        }
        
        [Category("Definition (Authorization)")]
        [Description("Roles allowed to write to the property. Multiple roles must be separated with ;")]
        public virtual string AllowWriteRoles
        {
            get { return _allowWriteRoles; }
            set
            {
                if (value != null)
                    _allowWriteRoles = value;
            }
        }

        [Category("Definition (Authorization)")]
        [Description("Roles denied to read the property. Multiple roles must be separated with ;")]
        public virtual string DenyReadRoles
        {
            get { return _denyReadRoles; }
            set
            {
                if (value != null)
                    _denyReadRoles = value;
            }
        }

        [Category("Definition (Authorization)")]
        [Description("Roles denied to write to the property. Multiple roles must be separated with ;")]
        public virtual string DenyWriteRoles
        {
            get { return _denyWriteRoles; }
            set
            {
                if (value != null)
                    _denyWriteRoles = value;
            }
        }

        #endregion

        #region Options

        [Category("Options")]
        [Description("Accessibility for the property as a whole.")]
        public PropertyAccess Access
        {
            get { return _access; }
            set { _access = value; }
        }

        [Category("Options")]
        [Description("Accessibility for property setter.\r\nDefaults to public.")]
        public AccessorVisibility PropSetAccessibility
        {
            get { return _propSetAccessibility; }
            set { _propSetAccessibility = value; }
        }

        [Category("Options")]
        [Description("This is a description.")]
        public bool Undoable
        {
            get { return _undoable; }
            set { _undoable = value; }
        }

        [Category("Options")]
        [Description("This is a description.")]
        public bool MarkDirtyOnChange
		{
			get { return _markDirtyOnChange; }
			set { _markDirtyOnChange = value; }
        }

        #endregion

        #endregion

        public static string SplitOnCaps(string name)
        {
            var mc = System.Text.RegularExpressions.Regex.Matches(name, @"(\P{Lu}+)|(\p{Lu}+\P{Lu}*)");
            var parts = new string[mc.Count];
            for (var i = 0; i < mc.Count; i++)
            {
                parts[i] = mc[i].ToString();
            }
            return string.Join(" ", parts);
        }

        [field: NonSerialized]
        public event PropertyNameChanged Changed;

        public override object Clone()
		{
			var buffer = new MemoryStream();
			var ser = new XmlSerializer(typeof(ValueProperty));
			ser.Serialize(buffer, this);
			buffer.Position = 0;
			return ser.Deserialize(buffer);
		}

		internal void RetrieveSummaryFromColumnDefinition()
		{
			if (DbBindColumn.Column != null) 
			{
                var prop = DbBindColumn.Column.ColumnDescription;
                if (prop != null)
                    base.Summary = prop;
                else
                    base.Summary = string.Empty;
			}
		}

	}
}
