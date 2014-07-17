using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Generate Inline Query Collection Editor
    /// </summary>
    public class GenerateInlineQueryCollectionEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstCrudOperations;

        public GenerateInlineQueryCollectionEditor()
        {
            _lstCrudOperations = new ListBox();
            _lstCrudOperations.DoubleClick += LstCrudOperationsDoubleClick;
            _lstCrudOperations.DisplayMember = "key";
            _lstCrudOperations.ValueMember = "value";
            _lstCrudOperations.SelectionMode = SelectionMode.MultiSimple;
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
                    var propInfo = instanceType.GetProperty("GenerateInlineQueries");
                    var propColl = (List<string>)propInfo.GetValue(objinfo, null);

                    _lstCrudOperations.Items.Clear();
                    _lstCrudOperations.Items.Add("(None)");
                    _lstCrudOperations.Items.Add("Create");
                    _lstCrudOperations.Items.Add("Read");
                    _lstCrudOperations.Items.Add("Update");
                    _lstCrudOperations.Items.Add("Delete");

                    foreach (var item in propColl)
                    {
                        _lstCrudOperations.SelectedItems.Add(item);
                    }

                    _lstCrudOperations.SelectedIndexChanged += LstPropertiesSelectedIndexChanged;
                    _editorService.DropDownControl(_lstCrudOperations);
                    _lstCrudOperations.SelectedIndexChanged -= LstPropertiesSelectedIndexChanged;

                    if (_lstCrudOperations.SelectedItems.Count > 0)
                    {
                        var prop = new List<string>();
                        foreach (var item in _lstCrudOperations.SelectedItems)
                        {
                            prop.Add((string) item);
                        }
                        return prop;
                    }

                    return new List<string>();
                }
            }

            return value;
        }

        void LstPropertiesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lstCrudOperations.SelectedIndex == 0)
                _lstCrudOperations.SelectedIndices.Clear();
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        void LstCrudOperationsDoubleClick(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                if (_lstCrudOperations != null)
                {
                    _lstCrudOperations.Dispose();
                    _lstCrudOperations = null;
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
