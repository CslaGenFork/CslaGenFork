using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using SchemaExplorer;
using System.Reflection;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
namespace CslaGenerator.Design
{
    public class ViewColumnSchemaEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;
        private ListBox lstColumns = new ListBox();
        private Type instance;

        public ViewColumnSchemaEditor()
        {
            lstColumns.SelectedIndexChanged += new EventHandler(lstColumns_SelectedIndexChanged);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (editorService != null)
                {
                    if (context.Instance != null)
                    {
                        // CR modifying to accomodate PropertyBag
                        Type instanceType = null;
                        object objinfo = null;
                        TypeHelper.GetContextInstanceObject(context, ref objinfo, ref instanceType);
                        instance = objinfo.GetType();
                        PropertyInfo tableInfo = instance.GetProperty("ViewSchema");
                        //object table = tableInfo.GetValue(context.Instance,null);
                        object table = tableInfo.GetValue(objinfo,null);
                        if (table != null)
                        {
                            lstColumns.Items.Clear();
                            ViewSchema t = (ViewSchema)table;
                            for (int i = 0; i < t.Columns.Count; i++)
                            {
                                lstColumns.Items.Add(t.Columns[i].Name);
                            }
                            editorService.DropDownControl(lstColumns);
                            if (lstColumns.SelectedItem != null)
                            {
                                string column = (string)lstColumns.SelectedItem;
                                if (column != String.Empty)
                                {
                                    value = t.Columns[column];
                                }
                            }
                        }
                    }
                }
            }

            return value;
        }

        private void lstColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editorService != null)
            {
                editorService.CloseDropDown();
            }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}
