using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class UseUnitOfWorkTypeEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;

        public UseUnitOfWorkTypeEditor()
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
                    ContextHelper.GetContextInstanceObject(context, ref objinfo, ref instanceType);
                    var obj = (CslaObjectInfo)objinfo;
                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    foreach (var o in GeneratorController.Current.CurrentUnit.CslaObjects)
                    {
                        var accept = false;
                        if (o.ObjectType == CslaObjectType.UnitOfWork)
                        {
                            if (obj.ObjectType.IsReadOnlyType())
                            {
                                if (o.UnitOfWorkType == UnitOfWorkFunction.Getter)
                                    accept = true;
                            }
                            else
                            {
                                if (o.UnitOfWorkType != UnitOfWorkFunction.Deleter &&
                                    o.UnitOfWorkType != UnitOfWorkFunction.Updater)
                                    accept = true;
                            }
                            if (accept)
                                _lstProperties.Items.Add(o.ObjectName);
                        }
                    }
                    _lstProperties.Sorted = true;

                    if (_lstProperties.Items.Contains(obj.UseUnitOfWorkType))
                        _lstProperties.SelectedItem = obj.UseUnitOfWorkType;
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