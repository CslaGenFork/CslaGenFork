using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using DBSchemaInfo.Base;

namespace CslaGenerator.Design
{
    public class DbBindColumnEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;

        public DbBindColumnEditor()
        {
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
                    TypeHelper.GetContextInstanceObject(context, ref objinfo, ref instanceType);
                    var obj = (IBoundProperty)objinfo;
                    using (var frm = new DbBindColumnEditorForm())
                    {
                        frm.ColumnInfo = obj.DbBindColumn.Column;

                        if (_editorService.ShowDialog(frm) == DialogResult.Cancel)
                            return value;

                        var selected = frm.SelectedNode;
                        IColumnInfo newCol = null;
                        if (selected != null)
                            newCol = selected.Tag as IColumnInfo;
                        if (frm.NoneSelected)
                        {
                            obj.DbBindColumn = new DbBindColumn();
                        }
                        else if (newCol != null)
                        {
                            var newDbc = new DbBindColumn();
                            Controls.DbSchemaPanel.SetDbBindColumn(selected.Parent, newCol, newDbc);
                            obj.DbBindColumn = newDbc;
                        }
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