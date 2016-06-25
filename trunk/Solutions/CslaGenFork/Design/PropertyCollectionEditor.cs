using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Used by ToStringProperty
    /// </summary>
    public class PropertyCollectionEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;

        public PropertyCollectionEditor()
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
                    var propColl = new PropertyCollection();
                    var obj = new CslaObjectInfo();

                    ContextHelper.GetContextInstanceObject(context, ref objinfo, ref instanceType);
                    if (instanceType == typeof(CslaObjectInfo))
                    {
                        PropertyInfo propInfo;
                        propInfo = instanceType.GetProperty("ToStringProperty");
                        propColl = (PropertyCollection)propInfo.GetValue(objinfo, null);
                        obj = (CslaObjectInfo)objinfo;
                    }
                    else
                    {
                        instanceType = null;
                        objinfo = null;
                        ContextHelper.GetChildPropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                        var parentPropertiesPropInfo = instanceType.GetProperty("ParentLoadProperties");
                        propColl = (PropertyCollection)parentPropertiesPropInfo.GetValue(objinfo, null);

                        obj = (CslaObjectInfo)GeneratorController.Current.GetSelectedItem();
                    }

                    var valueProps = obj.GetAllValueProperties();
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

            return value;
        }

        private void LstPropertiesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lstProperties.SelectedIndices.Contains(0))
            {
                for (int i = 0; i < _lstProperties.Items.Count; i++)
                {
                    _lstProperties.SetSelected(i, false);
                }
            }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        void LstPropertiesDoubleClick(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                if (_lstProperties != null)
                {
                    _lstProperties.Dispose();
                    _lstProperties = null;
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
