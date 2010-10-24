using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using DBSchemaInfo.Base;

namespace CslaGenerator.Design
{
    public class DbBindColumnEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;

        public DbBindColumnEditor()
        {
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (editorService != null)
                {
                    if (context.Instance != null)
                    {
                        // CR modifying to accomodate PropertyBag
                        Type instanceType = null;
                        object objinfo = null;
                        TypeHelper.GetContextInstanceObject(context, ref objinfo, ref instanceType);

                        IBoundProperty obj = (IBoundProperty) objinfo;

                        DbBindColumnEditorForm frm = new DbBindColumnEditorForm();
                        frm.ColumnInfo = obj.DbBindColumn.Column;


                        if (editorService.ShowDialog(frm) == DialogResult.Cancel)
                            return value;
                        TreeNode selected = frm.SelectedNode;
                        IColumnInfo newCol = null;
                        if (selected != null)
                            newCol = selected.Tag as IColumnInfo;
                        if (frm.NoneSelected)
                        {
                            obj.DbBindColumn = new DbBindColumn();
                        }
                        else if (newCol != null)
                        {
                            DbBindColumn newDbc = new DbBindColumn();
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
