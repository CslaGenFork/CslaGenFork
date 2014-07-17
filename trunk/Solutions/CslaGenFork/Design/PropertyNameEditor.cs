using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class PropertyNameEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;
        private Type _instance;

        public PropertyNameEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.DisplayMember = "key";
            _lstProperties.ValueMember = "value";
            _lstProperties.SelectedIndexChanged += LstPropertiesSelectedIndexChanged;
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
                    TypeHelper.GetContextInstanceObject(context, ref objinfo, ref instanceType);
                    var obj = (CslaObjectInfo)objinfo;
                    _instance = objinfo.GetType();
                    var valuePropsInfo = _instance.GetProperty("ValueProperties");
                    var valueProps = (ValuePropertyCollection)valuePropsInfo.GetValue(objinfo, null);
                    if (valueProps.Count > 0)
                    {
                        _lstProperties.Items.Clear();
                        for (int i = 0; i < valueProps.Count; i++)
                        {
                            _lstProperties.Items.Add(valueProps[i].Name);
                        }
                        _lstProperties.Sorted = true;

                        if (context.PropertyDescriptor.DisplayName == "Value Column")
                            _lstProperties.SelectedItem = obj.NameColumn;
                        else if (context.PropertyDescriptor.DisplayName == "Key Column")
                            _lstProperties.SelectedItem = obj.ValueColumn;

                        _editorService.DropDownControl(_lstProperties);
                        if (_lstProperties.SelectedItem == null)
                            return string.Empty;

                        return _lstProperties.SelectedItem.ToString();
                    }
                }
            }

            return value;
        }

        private void LstPropertiesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_editorService != null)
            {
                _editorService.CloseDropDown();
            }
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
