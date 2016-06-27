using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class UnitOfWorkTypeEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;

        public UnitOfWorkTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.SelectionMode = SelectionMode.One;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
            if (_editorService != null)
            {
                if (context.Instance != null)
                {
                    // CR modifying to accomodate PropertyBag
                    Type instanceType = null;
                    object objinfo = null;
                    ContextHelper.GetUnitOfWorkPropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    var prop = (UnitOfWorkProperty) objinfo;
                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    foreach (var o in GeneratorController.Current.CurrentUnit.CslaObjects)
                    {
                        if (o.IsNameValueList())
                            _lstProperties.Items.Add(o.ObjectName);
                        if (o.IsEditableRoot())
                            _lstProperties.Items.Add(o.ObjectName);
                        if (o.IsReadOnlyObject() && o.ParentType == string.Empty)
                            _lstProperties.Items.Add(o.ObjectName);
                        if (o.IsEditableRootCollection())
                            _lstProperties.Items.Add(o.ObjectName);
                        if (o.IsDynamicEditableRootCollection())
                            _lstProperties.Items.Add(o.ObjectName);
                        if (o.IsReadOnlyCollection() && o.ParentType == string.Empty)
                            _lstProperties.Items.Add(o.ObjectName);
                    }
                    _lstProperties.Sorted = true;

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