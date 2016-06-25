using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class UpdaterTypeEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;

        public UpdaterTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += lstProperties_DoubleClick;
            _lstProperties.SelectionMode = SelectionMode.One;
        }

        private void lstProperties_DoubleClick(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                _editorService = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
                if (_editorService != null)
                {
                    if (context.Instance != null)
                    {
                        // CR modifying to accomodate PropertyBag
                        Type instanceType = null;
                        object objinfo = null;
                        ContextHelper.GetContextInstanceObject(context, ref objinfo, ref instanceType);
                        var obj = (CslaObjectInfo) objinfo;
                        _lstProperties.Items.Clear();
                        _lstProperties.Items.Add("(None)");
                        foreach (CslaObjectInfo o in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            if (o.ObjectName != obj.ObjectName)
                            {
                                if (IsUpdaterType(o.ObjectType))
                                    _lstProperties.Items.Add(o.ObjectName);
                            }
                        }
                        _lstProperties.Sorted = true;

                        if (_lstProperties.Items.Contains(obj.UpdaterType))
                            _lstProperties.SelectedItem = obj.UpdaterType;
                        else
                            _lstProperties.SelectedItem = "(None)";

                        _editorService.DropDownControl(_lstProperties);
                        if (_lstProperties.SelectedIndex < 0 || _lstProperties.SelectedItem.ToString() == "(None)")
                            return string.Empty;

                        return _lstProperties.SelectedItem.ToString();
                    }
                }
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public bool IsUpdaterType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableRoot ||
                cslaType == CslaObjectType.EditableChild ||
                cslaType == CslaObjectType.DynamicEditableRootCollection ||
                cslaType == CslaObjectType.EditableSwitchable)
                return true;

            return false;
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
