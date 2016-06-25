using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class ChildTypeEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;

        public ChildTypeEditor()
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
                    ContextHelper.GetChildPropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    var prop = (ChildProperty)objinfo;
                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    foreach (var o in GeneratorController.Current.CurrentUnit.CslaObjects)
                    {
                        // waiting to find a way to distinguish collection and non collection child properties
                        //if (!TypeHelper.IsCollectionType(o.ObjectType))
                        if (o.ObjectType != CslaObjectType.NameValueList &&
                            o.ObjectType != CslaObjectType.UnitOfWork &&
                            o.ObjectType != CslaObjectType.CriteriaClass &&
                            o.ObjectType != CslaObjectType.BaseClass &&
                            o.ObjectType != CslaObjectType.PlaceHolder)
                            _lstProperties.Items.Add(o.ObjectName);
                    }
                    _lstProperties.Sorted = true;

                    // waiting to find a way to fetch the CslaObjectInfo

                    //var currentCslaObject = (CslaObjectInfo)GeneratorController.Current.GetSelectedItem();
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

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                if (_lstProperties != null)
                {
                    _lstProperties.Dispose();
                    _lstProperties = null;
                }
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}