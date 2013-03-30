using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for TypeInfoEditor.
    /// </summary>
    // guess isn't used any longer
    public class TypeInfoEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;

        public TypeInfoEditor()
        {
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (editorService != null)
                {
                    ObjectEditorForm frmEdit = new ObjectEditorForm();
                    object temp = ((ICloneable)value).Clone();
                    frmEdit.ObjectToEdit = temp;
                    DialogResult result = editorService.ShowDialog(frmEdit);
                    if (result == DialogResult.OK)
                    {
                        CopyProps((TypeInfo)value,(TypeInfo)temp);
                        return value;
                    }
                    else
                    {
                        return value;
                    }
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        private void CopyProps(TypeInfo dest, TypeInfo src)
        {
            dest.AssemblyFile = src.AssemblyFile;
            dest.Type = src.Type;
        }
    }
}
