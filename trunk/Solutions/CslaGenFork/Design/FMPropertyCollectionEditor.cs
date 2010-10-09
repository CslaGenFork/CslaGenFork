using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Find Method Property Collection Editor
    /// </summary>
    public class FMPropertyCollectionEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;
        private ListBox lstProperties;

        public FMPropertyCollectionEditor()
        {
            lstProperties = new ListBox();
            lstProperties.DoubleClick += lstProperties_DoubleClick;
            lstProperties.DisplayMember = "key";
            lstProperties.ValueMember = "value";
            lstProperties.SelectionMode = SelectionMode.MultiSimple;
        }

        void lstProperties_DoubleClick(object sender, EventArgs e)
        {
            editorService.CloseDropDown();
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
                        PropertyInfo propInfo = instanceType.GetProperty("FindMethodsParameters");
                        PropertyCollection propColl = (PropertyCollection) propInfo.GetValue(objinfo, null);

                        CslaObjectInfo obj = (CslaObjectInfo) objinfo;
                        string itemType = obj.ItemType;
                        if (itemType != null && itemType != "")
                        {
                            CslaObjectInfo info = GeneratorController.Current.CurrentUnit.CslaObjects.Find(itemType);
                            if (info != null)
                            {
                                ValuePropertyCollection valueProps = info.ValueProperties;
                                if (valueProps.Count > 0)
                                {
                                    lstProperties.Items.Clear();
                                    lstProperties.Items.Add(new DictionaryEntry("(None)",new ValueProperty()));
                                    for (int i = 0; i < valueProps.Count; i++)
                                    {
                                        lstProperties.Items.Add(new DictionaryEntry(valueProps[i].Name,valueProps[i]));
                                    }
                                    lstProperties.Sorted = true;

                                    foreach (var parentProp in propColl)
                                    {
                                        lstProperties.SelectedItems.Add(new DictionaryEntry(parentProp.Name, parentProp));
                                    }

                                    lstProperties.SelectedIndexChanged += lstProperties_SelectedIndexChanged;
                                    editorService.DropDownControl(lstProperties);
                                    lstProperties.SelectedIndexChanged -= lstProperties_SelectedIndexChanged;

                                    if (lstProperties.SelectedItems != null && lstProperties.SelectedItems.Count > 0)
                                    {
                                        PropertyCollection prop = new PropertyCollection();
                                        foreach (object item in lstProperties.SelectedItems)
                                        {
                                            prop.Add((Property)((DictionaryEntry)item).Value);
                                        }
                                        return prop;
                                    }

                                    return new PropertyCollection();
                                }
                            }
                        }
                    }
                }
            }
            return value;
        }

        void lstProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProperties.SelectedIndex == 0)
                lstProperties.SelectedIndices.Clear();
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}
