using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class CslaObjectInfoEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;
        private Type _instance;

        public CslaObjectInfoEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.DisplayMember = "key";
            _lstProperties.ValueMember = "value";
            _lstProperties.SelectedValueChanged += ValueChanged;
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
                    TypeHelper.GetInheritedTypeContextInstanceObject(context, ref objinfo, ref instanceType);
                    _instance = objinfo.GetType();

                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add(new DictionaryEntry("(None)", null));
                    // Get object info properties
                    var parentInfo = _instance.GetProperty("Parent");
                    var cslaObj = (CslaObjectInfo) parentInfo.GetValue(objinfo, null);
                    foreach (var obj in GeneratorController.Current.CurrentUnit.CslaObjects)
                    {
                        if (obj.ObjectName != cslaObj.ObjectName)
                            _lstProperties.Items.Add(new DictionaryEntry(obj.ObjectName, obj));
                    }
                    _lstProperties.Sorted = true;

                    _lstProperties.SelectedItem = new DictionaryEntry("(None)", null);
                    for (var entry = 0; entry < _lstProperties.Items.Count; entry++)
                    {
                        if ((string) value == ((DictionaryEntry) _lstProperties.Items[entry]).Key.ToString())
                        {
                            var val = (CslaObjectInfo) ((DictionaryEntry) _lstProperties.Items[entry]).Value;
                            _lstProperties.SelectedItems.Add(new DictionaryEntry(value, val));
                        }
                    }

                    _editorService.DropDownControl(_lstProperties);
                    if (_lstProperties.SelectedIndex < 0 || ((DictionaryEntry) _lstProperties.SelectedItem).Key.ToString() == "(None)")
                        return string.Empty;

                    return ((CslaObjectInfo) ((DictionaryEntry) _lstProperties.SelectedItem).Value).ObjectName;
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            if (_editorService != null)
            {
                _editorService.CloseDropDown();
            }
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