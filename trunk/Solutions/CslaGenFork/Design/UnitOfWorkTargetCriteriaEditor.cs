using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class UnitOfWorkTargetCriteriaEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;

        public UnitOfWorkTargetCriteriaEditor()
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
                    TypeHelper.GetUnitOfWorkPropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    var currentCslaObject = (CslaObjectInfo)GeneratorController.Current.GeneratorForm.ProjectPanel.ListObjects.SelectedItem;
                    var target = (UnitOfWorkProperty)objinfo;
                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    foreach (var o in GeneratorController.Current.CurrentUnit.CslaObjects)
                    {
                        if (o.ObjectName == target.TypeName)
                        {
                            var isGetter =
                                CodeGen.CslaTemplateHelperCS.ForceIsGetter(currentCslaObject, target);

                            /*var isGetter = currentCslaObject.IsGetter;
                            if (!CodeGen.CslaTemplateHelperCS.IsEditableType(o.ObjectType))
                                isGetter = true;*/

                            foreach (var criteria in o.CriteriaObjects)
                            {
                                if ((criteria.IsCreator && !isGetter) ||
                                    (criteria.IsGetter && isGetter) ||
                                    (criteria.IsDeleter && currentCslaObject.IsDeleter))
                                {
                                    if (criteria.Properties.Count > 0)
                                        _lstProperties.Items.Add(criteria.Name);
                                }
                            }
                        }
                    }
                    _lstProperties.Sorted = true;
                    _lstProperties.SelectedItem = value;
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
