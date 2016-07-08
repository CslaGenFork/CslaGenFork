using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class SourcePropertyTypeEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;

        public SourcePropertyTypeEditor()
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
                    ContextHelper.GetConvertValuePropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    var obj = (ConvertValueProperty) objinfo;

                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    var props = GeneratorController.Current.CurrentCslaObject.GetAllValueProperties();
                    foreach (var prop in props)
                    {
                        if (prop.PropertyType == TypeCodeEx.Int16 ||
                            prop.PropertyType == TypeCodeEx.Int32 ||
                            prop.PropertyType == TypeCodeEx.Int64 ||
                            prop.PropertyType == TypeCodeEx.UInt16 ||
                            prop.PropertyType == TypeCodeEx.UInt32 ||
                            prop.PropertyType == TypeCodeEx.UInt64 ||
                            prop.PropertyType == TypeCodeEx.SByte)
                        {
                            _lstProperties.Items.Add(prop.Name);
                        }
                    }
                    _lstProperties.Sorted = true;

                    if (_lstProperties.Items.Contains(obj.SourcePropertyName))
                        _lstProperties.SelectedItem = obj.SourcePropertyName;
                    else
                        _lstProperties.SelectedItem = "(None)";

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