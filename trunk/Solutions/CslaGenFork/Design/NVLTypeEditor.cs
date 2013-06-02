using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class NVLTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;

        public NVLTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.SelectionMode = SelectionMode.One;
            _lstProperties.Width = 300;
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
                    TypeHelper.GetConvertValuePropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    var obj = (ConvertValueProperty)objinfo;
                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    foreach (var o in GeneratorController.Current.CurrentUnit.CslaObjects)
                    {
                        if (o.ObjectType == CslaObjectType.NameValueList)
                        {
                            var prefix = string.Empty;
                            var objectNamespace = ((CslaObjectInfo)GeneratorController.Current.GetSelectedItem()).ObjectNamespace;
                            if (objectNamespace != o.ObjectNamespace)
                            {
                                var idx = objectNamespace.IndexOf(o.ObjectNamespace);
                                if (idx == 0)
                                {
                                    prefix = objectNamespace.Substring(o.ObjectNamespace.Length + 1) + ".";
                                }
                                else if (idx == -1)
                                {
                                    idx = o.ObjectNamespace.IndexOf(objectNamespace);
                                    if (idx == 0)
                                        prefix = o.ObjectNamespace.Substring(objectNamespace.Length + 1) + ".";
                                }
                                else
                                {
                                    prefix = o.ObjectNamespace + ".";
                                }
                            }
                            _lstProperties.Items.Add(prefix + o.ObjectName + ".Get" + o.ObjectName);
                        }
                    }
                    _lstProperties.Sorted = true;

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