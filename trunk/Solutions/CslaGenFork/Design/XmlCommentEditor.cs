using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using DBSchemaInfo.Base;

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
            if (context.Instance != null)
            {
                // check property is Summary and context.Instance is ValuePropertyBag
                if (context.PropertyDescriptor.Name == "Summary" &&
                    context.Instance is Util.PropertyBags.ValuePropertyBag)
                {
                    if (((Util.PropertyBags.ValuePropertyBag)context.Instance).SelectedObject[0].Summary.Trim() == string.Empty &&
                        ((Util.PropertyBags.ValuePropertyBag)context.Instance).SelectedObject[0].DbBindColumn.Column.ColumnDescription.Trim() != string.Empty)
                    {
                        return ((Util.PropertyBags.ValuePropertyBag)context.Instance).SelectedObject[0].DbBindColumn.Column.ColumnDescription;
                    }
                }

                // check property is Class Summary and context.Instance is PropertyBag
                if (context.PropertyDescriptor.Name == "Class Summary" &&
                    context.Instance is Util.PropertyBags.PropertyBag)
                {
                    if (((Util.PropertyBags.PropertyBag)context.Instance).SelectedObject[0].ClassSummary.Trim() == string.Empty)
                    {
                        var tableDescriptions = new List<string>();
                        foreach (var prop in ((Util.PropertyBags.PropertyBag)context.Instance).SelectedObject[0].ValueProperties)
                        {
                            var description = prop.DbBindColumn.DatabaseObject.ObjectDescription;
                            if (description != string.Empty && !tableDescriptions.Contains(description))
                                    tableDescriptions.Add(description);
                        }

                        var result = string.Empty;
                        bool first = true;
                        foreach (var description in tableDescriptions)
                        {
                            result += (!first ? Environment.NewLine : "") + description;
                            first = false;
                        }

                        return result;
                    }
                }
            }

            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (_editorService != null)
            {
                var frmEdit = new XmlCommentEditorForm { XmlComment = (string)value };
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
