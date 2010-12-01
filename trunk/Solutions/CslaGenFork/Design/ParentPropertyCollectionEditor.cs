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
    public class ParentPropertyCollectionEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties;

        public ParentPropertyCollectionEditor()
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
                    var propInfo = instanceType.GetProperty("ParentProperties");
                    var propColl = (PropertyCollection)propInfo.GetValue(objinfo, null);

                    var parentTypeInfo = instanceType.GetProperty("ParentType");
                    var parentType = (string)parentTypeInfo.GetValue(objinfo, null);
                    if (!string.IsNullOrEmpty(parentType))
                    {
                        var unitInfo = instanceType.GetProperty("Parent");
                        var unit = (CslaGeneratorUnit)unitInfo.GetValue(objinfo, null);
                        var info = unit.CslaObjects.Find(parentType);
                        if (info.ObjectType == CslaObjectType.EditableChildCollection ||
                            info.ObjectType == CslaObjectType.ReadOnlyCollection)
                        {
                            info = unit.CslaObjects.Find(info.ParentType);
                        }
                        else if (info.ObjectType == CslaObjectType.EditableRootCollection ||
                            info.ObjectType == CslaObjectType.DynamicEditableRootCollection)
                        {
                            info = null;
                        }
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

                                foreach (var parentProp in propColl)
                                {
                                    var key = parentProp.Name;
                                    for (var entry = 0; entry < _lstProperties.Items.Count; entry++)
                                    {
                                        if (key == ((DictionaryEntry)_lstProperties.Items[entry]).Key.ToString())
                                        {
                                            var val = (Property)((DictionaryEntry)_lstProperties.Items[entry]).Value;
                                            _lstProperties.SelectedItems.Add(new DictionaryEntry(key, val));
                                        }
                                    }
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
                    else
                    {
                        _lstProperties.Items.Clear();
                        return new PropertyCollection();
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