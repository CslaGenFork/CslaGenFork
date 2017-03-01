using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

//http://stackoverflow.com/questions/473506/using-the-net-collection-editor-without-using-a-property-grid-control

namespace CslaGenerator.Design
{
    public class DbProviderTypeEditor : IWindowsFormsEditorService, ITypeDescriptorContext
    {
        private readonly IWin32Window _owner;
        private readonly object _component;
        private readonly PropertyDescriptor _property;

        private DbProviderTypeEditor(IWin32Window owner, object component, PropertyDescriptor property)
        {
            _owner = owner;
            _component = component;
            _property = property;
        }

        public static void EditValue(IWin32Window owner, object component, string propertyName)
        {
            var prop = TypeDescriptor.GetProperties(component)[propertyName];
            if (prop == null)
                throw new ArgumentException("propertyName");

            var editor = (UITypeEditor) prop.GetEditor(typeof(UITypeEditor));

            var ctx = new DbProviderTypeEditor(owner, component, prop);

            if (editor != null && editor.GetEditStyle(ctx) == UITypeEditorEditStyle.Modal)
            {
                object value = prop.GetValue(component);
                value = editor.EditValue(ctx, ctx, value);
                if (!prop.IsReadOnly)
                {
                    prop.SetValue(component, value);
                    var dirtyProp = TypeDescriptor.GetProperties(component)["Dirty"];
                    if (dirtyProp != null)
                        dirtyProp.SetValue(component, true);
                }
            }
        }

        #region IWindowsFormsEditorService Members

        public void CloseDropDown()
        {
            throw new NotImplementedException();
        }

        public void DropDownControl(System.Windows.Forms.Control control)
        {
            throw new NotImplementedException();
        }

        public System.Windows.Forms.DialogResult ShowDialog(System.Windows.Forms.Form dialog)
        {
            return dialog.ShowDialog(_owner);
        }

        #endregion

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            return serviceType == typeof(IWindowsFormsEditorService) ? this : null;
        }

        #endregion

        #region ITypeDescriptorContext Members

        IContainer ITypeDescriptorContext.Container
        {
            get { return null; }
        }

        object ITypeDescriptorContext.Instance
        {
            get { return _component; }
        }

        void ITypeDescriptorContext.OnComponentChanged()
        {
        }

        bool ITypeDescriptorContext.OnComponentChanging()
        {
            return true;
        }

        PropertyDescriptor ITypeDescriptorContext.PropertyDescriptor
        {
            get { return _property; }
        }

        #endregion
    }
}