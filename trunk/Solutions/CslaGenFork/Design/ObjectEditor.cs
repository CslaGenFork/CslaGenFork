using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for ObjectEditor (TypeInfo and AuthorizationRule).
    /// </summary>
    /// <remarks> This is used by: 
    /// CslaObjectInfo.InheritedType, 
    /// CslaObjectInfo.InheritedTypeWinForms, 
    /// CslaObjectInfo.NewAuthzRuleType, 
    /// CslaObjectInfo.GetAuthzRuleType, 
    /// CslaObjectInfo.UpdateAuthzRuleType, 
    /// CslaObjectInfo.DeleteAuthzRuleType, 
    /// ValueProperty.ReadAuthzRuleType, 
    /// ValueProperty.WriteAuthzRuleType, 
    /// ChildProperty.ReadAuthzRuleType, 
    /// ChildProperty.WriteAuthzRuleType, 
    /// Criteria.CustomCriteriaClass.
    /// </remarks>
    public class ObjectEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                _editorService = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
                if (_editorService != null)
                {
                    var isInheritedType = false;
                    var isInheritedTypeWinForms = false;
                    MemberDescriptor propertyDescriptor =
                        GeneratorController.Current.MainForm.ObjectInfoGrid.SelectedGridItem.PropertyDescriptor;

                    if (propertyDescriptor != null)
                    {
                        if (propertyDescriptor.Name == "Inherited Type")
                            isInheritedType = true;
                        if (propertyDescriptor.Name == "Inherited Type for WinForms")
                            isInheritedTypeWinForms = true;
                        if (propertyDescriptor.Name == "Criteria Objects" && value == null)
                            value = new TypeInfo();
                    }

                    object temp;
                    DialogResult result;
                    using (var frmEdit = new ObjectEditorForm())
                    {
                        if (isInheritedType || isInheritedTypeWinForms)
                        {
                            if (value == null)
                                value = new TypeInfo();

                            ((TypeInfo) value).IsInheritedType = isInheritedType;
                            ((TypeInfo) value).IsInheritedTypeWinForms = isInheritedTypeWinForms;
                        }

                        temp = ((ICloneable) value).Clone();
                        frmEdit.ObjectToEdit = temp;
                        result = _editorService.ShowDialog(frmEdit);
                    }
                    if (result == DialogResult.OK)
                    {
                        Copy(value, temp);
                        return value;
                    }

                    return value;
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        private void Copy(Object dest, Object src)
        {
            try
            {
                var destType = dest.GetType();
                var srcType = src.GetType();
                if (destType.Equals(srcType))
                {
                    var destProps = destType.GetProperties();
                    var srcProps = srcType.GetProperties();
                    for (var i = 0; i < destProps.Length; i++)
                    {
                        if (destProps[i].CanWrite)
                        {
                            var val = srcProps[i].GetValue(src, null);
                            if (val != null)
                            {
                                destProps[i].SetValue(dest, val, null); //srcProps[i].GetValue(src, null), null);
                            }
                            else
                            {
                                destProps[i].SetValue(dest, null, null);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}