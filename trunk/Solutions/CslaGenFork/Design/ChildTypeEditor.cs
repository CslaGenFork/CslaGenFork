using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using System.Drawing;

namespace CslaGenerator.Design
{
    public class ChildTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;
        private ListBox lstProperties;

        public ChildTypeEditor()
        {
            lstProperties = new ListBox();
            lstProperties.DoubleClick += lstProperties_DoubleClick;
            lstProperties.SelectionMode = SelectionMode.One;
        }

        void lstProperties_DoubleClick(object sender, EventArgs e)
        {
            editorService.CloseDropDown();
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
                        TypeHelper.GetChildPropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                        ChildProperty prop = (ChildProperty) objinfo;
                        lstProperties.Items.Clear();
                        lstProperties.Items.Add("(None)");
                        foreach (CslaObjectInfo o in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            // wainting to find a way to distinguish collection and non collection child properties
                            //if(!TypeHelper.IsCollectionType(o.ObjectType))
                            if(o.ObjectType != CslaObjectType.NameValueList)
                                lstProperties.Items.Add(o.ObjectName);
                        }
                        lstProperties.Sorted = true;

                        // waiting to find a way to fetc the CslaObjectInfo
                        /*var obj = GeneratorController.Current.CurrentUnit.CslaObjects.Find("");
                        foreach (CslaObjectInfo o in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            //if (o.ObjectName != obj.ObjectName)
                            //    lstProperties.Items.Add(o.ObjectName);
                            if (o.ObjectName != obj.ObjectName)
                            {
                                if (RelationRulesEngine.IsParentAllowed(o.ObjectType, obj.ObjectType))
                                    lstProperties.Items.Add(o.ObjectName);
                            }
                        }

                        if (lstProperties.Items.Contains(obj.ParentType))
                            lstProperties.SelectedItem = obj.ParentType;
                        else
                            lstProperties.SelectedItem = "(None)";*/
                        lstProperties.SelectedItem = prop.TypeName;
                        editorService.DropDownControl(lstProperties);
                        if (lstProperties.SelectedIndex < 0 || lstProperties.SelectedItem.ToString() == "(None)")
                            return string.Empty;

                        return lstProperties.SelectedItem.ToString();

                    }

                }
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}
