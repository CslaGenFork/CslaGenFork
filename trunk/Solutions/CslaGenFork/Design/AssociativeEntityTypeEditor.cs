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
        private IWindowsFormsEditorService editorService = null;
        private ListBox lstProperties;

        public AssociativeEntityTypeEditor()
        {
            lstProperties = new ListBox();
            lstProperties.DoubleClick += lstProperties_DoubleClick;
            lstProperties.SelectionMode = SelectionMode.One;
        }

        void lstProperties_DoubleClick(object sender, EventArgs e)
        {
            editorService.CloseDropDown();
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
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
                    var associativeEntity = (AssociativeEntity) objinfo;
                    lstProperties.Items.Clear();
                    lstProperties.Items.Add("(None)");
                    if (context.PropertyDescriptor.DisplayName == "MainObject" ||
                        (context.PropertyDescriptor.DisplayName == "SecondaryObject" &&
                        associativeEntity.RelationType ==ObjectRelationType.MultipleToMultiple))
                    {
                        foreach (var obj in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            if (RelationRulesEngine.IsAllowedEntityObject(obj))
                            {
                                lstProperties.Items.Add(obj.ObjectName);
                            }
                        }
                    }
                    if (context.PropertyDescriptor.DisplayName == "MainCollectionTypeName" ||
                        (context.PropertyDescriptor.DisplayName == "SecondaryCollectionTypeName" &&
                        associativeEntity.RelationType == ObjectRelationType.MultipleToMultiple))
                    {
                        foreach (var obj in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            if (RelationRulesEngine.IsAllowedEntityCollection(obj))
                            {
                                lstProperties.Items.Add(obj.ObjectName);
                            }
                        }
                    }
                    if (context.PropertyDescriptor.DisplayName == "MainItemTypeName" ||
                        (context.PropertyDescriptor.DisplayName == "SecondaryItemTypeName" &&
                        associativeEntity.RelationType == ObjectRelationType.MultipleToMultiple))
                    {
                        foreach (var obj in GeneratorController.Current.CurrentUnit.CslaObjects)
                        {
                            if (RelationRulesEngine.IsAllowedEntityCollectionItem(obj))
                            {
                                lstProperties.Items.Add(obj.ObjectName);
                            }
                        }
                    }
                    lstProperties.Sorted = true;
                    if (context.PropertyDescriptor.DisplayName == "MainObject" && associativeEntity.MainObject != null)
                    {
                        if (lstProperties.Items.Contains(associativeEntity.MainObject))
                            lstProperties.SelectedItem = associativeEntity.MainObject;
                    }
                    else if (context.PropertyDescriptor.DisplayName == "SecondaryObject" && associativeEntity.SecondaryObject != null)
                    {
                        if (lstProperties.Items.Contains(associativeEntity.SecondaryObject))
                            lstProperties.SelectedItem = associativeEntity.SecondaryObject;
                    }
                    else if (context.PropertyDescriptor.DisplayName == "MainCollectionTypeName" && associativeEntity.MainCollectionTypeName != null)
                    {
                        if (lstProperties.Items.Contains(associativeEntity.MainCollectionTypeName))
                            lstProperties.SelectedItem = associativeEntity.MainCollectionTypeName;
                    }
                    else if (context.PropertyDescriptor.DisplayName == "SecondaryCollectionTypeName" && associativeEntity.SecondaryCollectionTypeName != null)
                    {
                        if (lstProperties.Items.Contains(associativeEntity.SecondaryCollectionTypeName))
                            lstProperties.SelectedItem = associativeEntity.SecondaryCollectionTypeName;
                    }
                    else if (context.PropertyDescriptor.DisplayName == "MainItemTypeName" && associativeEntity.MainItemTypeName != null)
                    {
                        if (lstProperties.Items.Contains(associativeEntity.MainItemTypeName))
                            lstProperties.SelectedItem = associativeEntity.MainItemTypeName;
                    }
                    else if (context.PropertyDescriptor.DisplayName == "SecondaryItemTypeName" && associativeEntity.SecondaryItemTypeName != null)
                    {
                        if (lstProperties.Items.Contains(associativeEntity.SecondaryItemTypeName))
                            lstProperties.SelectedItem = associativeEntity.SecondaryItemTypeName;
                    }
                    else
                    {
                        lstProperties.SelectedItem = "(None)";
                    }
                    editorService.DropDownControl(lstProperties);
                    if (lstProperties.SelectedIndex < 0 || lstProperties.SelectedItem.ToString() == "(None)")
                        return string.Empty;

                    return lstProperties.SelectedItem.ToString();

                }

            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}