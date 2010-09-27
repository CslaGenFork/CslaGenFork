//using System;
//using System.Collections;
//using System.ComponentModel;
//using System.Drawing.Design;
//using System.Windows.Forms;
//using System.Windows.Forms.Design;
//using SchemaExplorer;
//using CslaGenerator.Metadata;
//using CslaGenerator.Util;

//namespace CslaGenerator.Design
//{
//    /// <summary>
//    /// Summary description for TableSchemaEditor.
//    /// </summary>
//    public class TableSchemaEditor : UITypeEditor
//    {
//        private IWindowsFormsEditorService editorService = null;
//        private ListBox lstTables = new ListBox();

//        public TableSchemaEditor()
//        {
//            lstTables.DisplayMember = "key";
//            lstTables.ValueMember = "value";
//            lstTables.SelectedValueChanged += new EventHandler(lstTables_SelectedValueChanged);
//        }

//        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
//        {
//            if (provider != null)
//            {
//                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
//                if (editorService != null) 
//                {
//                    DatabaseSchema schema = GeneratorController.Schema;
//                    if (schema == null)
//                    {
//                        throw new InvalidOperationException("You must connect to a datasource first.");
//                    }

//                    lstTables.Items.Clear();
//                    TableSchema[] tables = new TableSchema[schema.Tables.Count];
//                    schema.Tables.CopyTo(tables,0);
//                    Array.Sort(tables,new TableSchemaComparer());
//                    for (int i = 0; i < tables.Length; i++)
//                    {
//                        lstTables.Items.Add(new DictionaryEntry(tables[i].Name,tables[i]));
//                    }

//                    editorService.DropDownControl(lstTables);

//                    if (lstTables.SelectedItem != null)
//                    {
//                        return ((DictionaryEntry)lstTables.SelectedItem).Value;
//                    }
//                    else { return null; }
//                }
//            }
			
//            return value;
//        }
		
//        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
//        {
//            return UITypeEditorEditStyle.DropDown;
//        }

//        private void lstTables_SelectedValueChanged(object sender, EventArgs e)
//        {
//            if (editorService != null)
//            {
//                editorService.CloseDropDown();
//            }
//        }
//    }
//}
