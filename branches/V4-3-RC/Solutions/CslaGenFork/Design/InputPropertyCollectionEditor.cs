using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Used by BusinessRule.InputProperties
    /// </summary>
    public class InputPropertyCollectionEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;

        public InputPropertyCollectionEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.DisplayMember = "key";
            _lstProperties.ValueMember = "value";
            _lstProperties.SelectionMode = SelectionMode.MultiSimple;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
            if (_editorService != null)
            {
                if (context.Instance != null)
                {
                    // CR modifying to accomodate PropertyBag
                    Type instanceType = null;
                    object objinfo = null;
                    TypeHelper.GetBusinessRuleTypeContextInstanceObject(context, ref objinfo, ref instanceType);
                    var propInfo = instanceType.GetProperty("InputProperties");
                    var propColl = (PropertyCollection)propInfo.GetValue(objinfo, null);

                    var obj = (BusinessRule) objinfo;

                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add(new DictionaryEntry("(None)", new ValueProperty()));
                    var valPropColl =
                        ((CslaObjectInfo) GeneratorController.Current.MainForm.ProjectPanel.ListObjects.SelectedItem).
                            GetAllValueProperties();
                    foreach (var prop in valPropColl)
                    {
                        _lstProperties.Items.Add(new DictionaryEntry(prop.Name, prop));
                    }
                    _lstProperties.Sorted = true;

                    foreach (var prop in propColl)
                    {
                        _lstProperties.SelectedItems.Add(new DictionaryEntry(prop.Name, prop));
                    }

                    _lstProperties.SelectedIndexChanged += LstPropertiesSelectedIndexChanged;
                    _editorService.DropDownControl(_lstProperties);
                    _lstProperties.SelectedIndexChanged -= LstPropertiesSelectedIndexChanged;

                    if (_lstProperties.SelectedItems.Count > 0)
                    {
                        var prop = new PropertyCollection();
                        foreach (var item in _lstProperties.SelectedItems)
                        {
                            prop.Add((Property) ((DictionaryEntry) item).Value);
                        }
                        return prop;
                    }

                    return new PropertyCollection();
                }
            }

            return value;
        }

        private void LstPropertiesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lstProperties.SelectedIndex == 0)
                _lstProperties.SelectedIndices.Clear();
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        void LstPropertiesDoubleClick(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }
    }
}