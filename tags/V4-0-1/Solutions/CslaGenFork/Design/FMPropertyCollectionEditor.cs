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
    /// Find Method Property Collection Editor
    /// </summary>
    public class FMPropertyCollectionEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;

        public FMPropertyCollectionEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.DisplayMember = "key";
            _lstProperties.ValueMember = "value";
            _lstProperties.SelectionMode = SelectionMode.MultiSimple;
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
                    var propInfo = instanceType.GetProperty("FindMethodsParameters");
                    var propColl = (PropertyCollection)propInfo.GetValue(objinfo, null);

                    var obj = (CslaObjectInfo)objinfo;
                    var itemType = obj.ItemType;
                    if (!string.IsNullOrEmpty(itemType))
                    {
                        var info = GeneratorController.Current.CurrentUnit.CslaObjects.Find(itemType);
                        if (info != null)
                        {
                            var valueProps = info.ValueProperties;
                            if (valueProps.Count > 0)
                            {
                                _lstProperties.Items.Clear();
                                _lstProperties.Items.Add(new DictionaryEntry("(None)", new ValueProperty()));
                                for (int i = 0; i < valueProps.Count; i++)
                                {
                                    _lstProperties.Items.Add(new DictionaryEntry(valueProps[i].Name, valueProps[i]));
                                }
                                _lstProperties.Sorted = true;

                                foreach (var parentProp in propColl)
                                {
                                    _lstProperties.SelectedItems.Add(new DictionaryEntry(parentProp.Name, parentProp));
                                }

                                _lstProperties.SelectedIndexChanged += LstPropertiesSelectedIndexChanged;
                                _editorService.DropDownControl(_lstProperties);
                                _lstProperties.SelectedIndexChanged -= LstPropertiesSelectedIndexChanged;

                                if (_lstProperties.SelectedItems.Count > 0)
                                {
                                    var prop = new PropertyCollection();
                                    foreach (var item in _lstProperties.SelectedItems)
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

            return value;
        }

        void LstPropertiesSelectedIndexChanged(object sender, EventArgs e)
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
