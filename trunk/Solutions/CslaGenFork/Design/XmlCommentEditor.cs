using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for XmlCommentEditor.
    /// </summary>
    public class XmlCommentEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;

        public XmlCommentEditor()
        {
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (_editorService != null)
            {
                var frmEdit = new XmlCommentEditorForm {XmlComment = (string) value};
                var result = _editorService.ShowDialog(frmEdit);
                if (result == DialogResult.OK)
                {
                    return frmEdit.XmlComment;
                }

                return value;
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
}