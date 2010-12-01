using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class AssociativeEntityTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;

        public AssociativeEntityTypeEditor()
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
                    TypeHelper.GetAssociativeEntityContextInstanceObject(context, ref objinfo, ref instanceType);
                    var associativeEntity = (AssociativeEntity)objinfo;
                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    if (context.PropertyDescriptor.DisplayName == "Primary Object" ||
                        (context.PropertyDescriptor.DisplayName == "Secondary Object" &&
                        associativeEntity.RelationType == ObjectRelationType.MultipleToMultiple))
                    {
                        foreach (var obj in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            if (RelationRulesEngine.IsAllowedEntityObject(obj))
                            {
                                _lstProperties.Items.Add(obj.ObjectName);
                            }
                        }
                    }
                    if (context.PropertyDescriptor.DisplayName == "Primary Collection Type Name" ||
                        (context.PropertyDescriptor.DisplayName == "Secondary Collection Type Name" &&
                        associativeEntity.RelationType == ObjectRelationType.MultipleToMultiple))
                    {
                        foreach (var obj in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            if (RelationRulesEngine.IsAllowedEntityCollection(obj))
                            {
                                _lstProperties.Items.Add(obj.ObjectName);
                            }
                        }
                    }
                    if (context.PropertyDescriptor.DisplayName == "Primary Item Type Name" ||
                        (context.PropertyDescriptor.DisplayName == "Secondary Item Type Name" &&
                        associativeEntity.RelationType == ObjectRelationType.MultipleToMultiple))
                    {
                        foreach (var obj in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            if (RelationRulesEngine.IsAllowedEntityCollectionItem(obj))
                            {
                                _lstProperties.Items.Add(obj.ObjectName);
                            }
                        }
                    }
                    _lstProperties.Sorted = true;

                    if (context.PropertyDescriptor.DisplayName == "Primary Object" && associativeEntity.MainObject != null)
                    {
                        if (_lstProperties.Items.Contains(associativeEntity.MainObject))
                            _lstProperties.SelectedItem = associativeEntity.MainObject;
                    }
                    else if (context.PropertyDescriptor.DisplayName == "Secondary Object" && associativeEntity.SecondaryObject != null)
                    {
                        if (_lstProperties.Items.Contains(associativeEntity.SecondaryObject))
                            _lstProperties.SelectedItem = associativeEntity.SecondaryObject;
                    }
                    else if (context.PropertyDescriptor.DisplayName == "Primary Collection Type Name" && associativeEntity.MainCollectionTypeName != null)
                    {
                        if (_lstProperties.Items.Contains(associativeEntity.MainCollectionTypeName))
                            _lstProperties.SelectedItem = associativeEntity.MainCollectionTypeName;
                    }
                    else if (context.PropertyDescriptor.DisplayName == "Secondary Collection Type Name" && associativeEntity.SecondaryCollectionTypeName != null)
                    {
                        if (_lstProperties.Items.Contains(associativeEntity.SecondaryCollectionTypeName))
                            _lstProperties.SelectedItem = associativeEntity.SecondaryCollectionTypeName;
                    }
                    else if (context.PropertyDescriptor.DisplayName == "Primary Item Type Name" && associativeEntity.MainItemTypeName != null)
                    {
                        if (_lstProperties.Items.Contains(associativeEntity.MainItemTypeName))
                            _lstProperties.SelectedItem = associativeEntity.MainItemTypeName;
                    }
                    else if (context.PropertyDescriptor.DisplayName == "Secondary Item Type Name" && associativeEntity.SecondaryItemTypeName != null)
                    {
                        if (_lstProperties.Items.Contains(associativeEntity.SecondaryItemTypeName))
                            _lstProperties.SelectedItem = associativeEntity.SecondaryItemTypeName;
                    }
                    else
                    {
                        _lstProperties.SelectedItem = "(None)";
                    }

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