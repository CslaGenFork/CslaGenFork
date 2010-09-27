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
//    /// Summary description for ViewSchemaEditor.
//    /// </summary>
//    public class ViewSchemaEditor : UITypeEditor
//    {
//        private IWindowsFormsEditorService editorService = null;
//        private ListBox lstViews = new ListBox();

//        public ViewSchemaEditor()
//        {
//            lstViews.DisplayMember = "key";
//            lstViews.ValueMember = "value";
//            lstViews.SelectedValueChanged += new EventHandler(lstViews_SelectedValueChanged);
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

//                    lstViews.Items.Clear();
//                    ViewSchema[] views = new ViewSchema[schema.Views.Count];
//                    schema.Views.CopyTo(views,0);
//                    Array.Sort(views,new ViewSchemaComparer());
//                    for (int i = 0; i < views.Length; i++)
//                    {
//                        lstViews.Items.Add(new DictionaryEntry(views[i].Name,views[i]));
//                    }

//                    editorService.DropDownControl(lstViews);

//                    if (lstViews.SelectedItem != null)
//                    {
//                        return ((DictionaryEntry)lstViews.SelectedItem).Value;
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

//        private void lstViews_SelectedValueChanged(object sender, EventArgs e)
//        {
//            if (editorService != null)
//            {
//                editorService.CloseDropDown();
//            }
//        }
//    }
//}
