using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for XmlCommentEditor.
    /// </summary>
    public class XmlCommentEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;

        public XmlCommentEditor()
        {
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (editorService != null)
                {
                    XmlCommentEditorForm frmEdit = new XmlCommentEditorForm();
                    frmEdit.XmlComment = (string)value;
                    DialogResult result = editorService.ShowDialog(frmEdit);
                    if (result == DialogResult.OK)
                    {
                        return frmEdit.XmlComment;
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
    }
}
