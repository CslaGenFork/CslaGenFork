using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class UnitOfWorkTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;

        public UnitOfWorkTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.SelectionMode = SelectionMode.One;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (_editorService != null)
            {
                if (context.Instance != null)
                {
                    // CR modifying to accomodate PropertyBag
                    Type instanceType = null;
                    object objinfo = null;
                    TypeHelper.GetUnitOfWorkPropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    var prop = (UnitOfWorkProperty)objinfo;
                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    foreach (var o in GeneratorController.Current.CurrentUnit.CslaObjects)
                    {
                        // waiting to find a way to distinguish collection and non collection child properties
                        //if (!TypeHelper.IsCollectionType(o.ObjectType))
                        if (o.ObjectType == CslaObjectType.NameValueList)
                            _lstProperties.Items.Add(o.ObjectName);
                        if (o.ObjectType == CslaObjectType.EditableRoot)
                            _lstProperties.Items.Add(o.ObjectName);
                        if (o.ObjectType == CslaObjectType.ReadOnlyObject && o.ParentType == string.Empty)
                            _lstProperties.Items.Add(o.ObjectName);
                        if (o.ObjectType == CslaObjectType.EditableRootCollection)
                            _lstProperties.Items.Add(o.ObjectName);
                        if (o.ObjectType == CslaObjectType.DynamicEditableRootCollection)
                            _lstProperties.Items.Add(o.ObjectName);
                        if (o.ObjectType == CslaObjectType.ReadOnlyCollection && o.ParentType==string.Empty)
                            _lstProperties.Items.Add(o.ObjectName);
                    }
                    _lstProperties.Sorted = true;

                    // waiting to find a way to fetch the CslaObjectInfo
                    
                    var currentCslaObject = (CslaObjectInfo)GeneratorController.Current.MainForm.ProjectPanel.ListObjects.SelectedItem;
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
                    _lstProperties.SelectedItem = prop.TypeName;
                    _editorService.DropDownControl(_lstProperties);
                    if (_lstProperties.SelectedIndex < 0 || _lstProperties.SelectedItem.ToString() == "(None)")
                        return string.Empty;

                    return _lstProperties.SelectedItem.ToString();
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        void LstPropertiesDoubleClick(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }
    }
}