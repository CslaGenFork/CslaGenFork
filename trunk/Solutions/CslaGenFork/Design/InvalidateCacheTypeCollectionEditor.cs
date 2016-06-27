using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class InvalidateCacheTypeCollectionEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;

        public InvalidateCacheTypeCollectionEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.SelectionMode = SelectionMode.MultiSimple;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
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
                    var propInfo = instanceType.GetProperty("InvalidateCache");
                    var objectNameColl = (List<string>) propInfo.GetValue(objinfo, null);

                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    foreach (var o in GeneratorController.Current.CurrentUnit.CslaObjects)
                    {
                        if (o.IsReadOnlyCollection() ||
                            o.IsNameValueList())
                        {
                            _lstProperties.Items.Add(o.ObjectName);

                            foreach (var objName in objectNameColl)
                            {
                                if (objName == o.ObjectName)
                                    _lstProperties.SelectedItems.Add(objName);
                            }
                        }
                    }
                    _lstProperties.Sorted = true;

                    _lstProperties.SelectedIndexChanged += LstPropertiesSelectedIndexChanged;
                    _editorService.DropDownControl(_lstProperties);
                    _lstProperties.SelectedIndexChanged -= LstPropertiesSelectedIndexChanged;

                    if (_lstProperties.SelectedItems.Count > 0)
                    {
                        var prop = new List<string>();
                        foreach (var item in _lstProperties.SelectedItems)
                        {
                            prop.Add((string) item);
                        }
                        return prop;
                    }

                    return new List<string>();
                }
            }

            return value;
        }

        private void LstPropertiesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lstProperties.SelectedIndex == 0)
                _lstProperties.SelectedIndices.Clear();
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        private void LstPropertiesDoubleClick(object sender, EventArgs e)
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
