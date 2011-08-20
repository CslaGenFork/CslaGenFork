using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class AllPropertiesTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;

        public AllPropertiesTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.SelectionMode = SelectionMode.One;
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
                    TypeHelper.GetPropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    var parameter = (BusinessRuleConstructorParameter) objinfo;
                    _lstProperties.Items.Clear();
                    var info = (CslaObjectInfo) GeneratorController.Current.MainForm.ProjectPanel.ListObjects.SelectedItem;
                    var allRulesProperties = new HaveBusinessRulesCollection();
                    allRulesProperties.AddRange(info.AllValueProperties); // ValueProperties and ConvertValueProperties
                    allRulesProperties.AddRange(info.InheritedValueProperties); // InheritedValueProperties
                    // ChildProperties, ChildCollectionProperties, InheritedChildProperties, InheritedChildCollectionProperties
                    allRulesProperties.AddRange(info.GetAllChildProperties());

                    foreach (IHaveBusinessRules rulableProperty in allRulesProperties)
                    {
                        _lstProperties.Items.Add(rulableProperty.Name);
                    }
                    _lstProperties.Sorted = true;

                    _lstProperties.SelectedItem = parameter.Value.ToString();
                    _editorService.DropDownControl(_lstProperties);
                    if (_lstProperties.SelectedIndex < 0 || _lstProperties.SelectedItem.ToString() == "(None)")
                        return string.Empty;

                    return _lstProperties.SelectedItem.ToString();
                }
            }

            return value;
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