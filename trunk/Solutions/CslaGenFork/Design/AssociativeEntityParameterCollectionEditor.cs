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
    /// Summary description for AssociativeEntityParameterCollectionEditor. Used by
    /// // MainLoadParameters = "Primary Load Parameters"
    /// // SecondaryLoadParameters = "Secondary Load Parameters"
    /// </summary>
    public class AssociativeEntityParameterCollectionEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;
        private object _instance;

        public AssociativeEntityParameterCollectionEditor()
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
            if (_editorService != null && context.Instance != null)
            {
                // CR modifying to accomodate PropertyBag
                Type instanceType = null;
                object objinfo = null;
                ContextHelper.GetAssociativeEntityContextInstanceObject(context, ref objinfo, ref instanceType);
                PropertyInfo propInfo;
                var associativeEntity = (AssociativeEntity)objinfo;
                string cslaObject;
                if (context.PropertyDescriptor.DisplayName == "Primary Load Parameters" &&
                    associativeEntity.MainObject != null)
                {
                    propInfo = instanceType.GetProperty("MainLoadParameters");
//                    if (associativeEntity.MainLoadingScheme == LoadingScheme.SelfLoad)
//                        cslaObject = associativeEntity.MainCollectionTypeName;
//                    else
                        cslaObject = associativeEntity.MainObject;
                }
                else
                {
                    propInfo = instanceType.GetProperty("SecondaryLoadParameters");
//                    if (associativeEntity.SecondaryLoadingScheme == LoadingScheme.SelfLoad)
//                        cslaObject = associativeEntity.SecondaryCollectionTypeName;
//                    else
                        cslaObject = associativeEntity.SecondaryObject;
                }
                var paramColl = (ParameterCollection)propInfo.GetValue(objinfo, null);
                var objectColl = GeneratorController.Current.MainForm.ProjectPanel.Objects;
                _instance = objectColl.Find(cslaObject);

                var criteriaInfo = typeof(CslaObjectInfo).GetProperty("CriteriaObjects");
                var criteriaObjects = criteriaInfo.GetValue(_instance, null);

                _lstProperties.Items.Clear();
                _lstProperties.Items.Add(new DictionaryEntry("(None)", new Parameter()));
                foreach (var crit in (CriteriaCollection)criteriaObjects)
                {
                    if (crit.GetOptions.Factory || crit.GetOptions.AddRemove || crit.GetOptions.DataPortal)
                    {
                        foreach (var prop in crit.Properties)
                        {
                            _lstProperties.Items.Add(new DictionaryEntry(crit.Name + "." + prop.Name,
                                                                         new Parameter(crit, prop)));
                        }
                    }
                }
                _lstProperties.Sorted = true;

                foreach (var param in paramColl)
                {
                    var key = param.Criteria.Name + "." + param.Property.Name;
                    for (var entry = 0; entry < _lstProperties.Items.Count; entry++)
                    {
                        if (key == ((DictionaryEntry)_lstProperties.Items[entry]).Key.ToString())
                        {
                            var val = (Parameter)((DictionaryEntry)_lstProperties.Items[entry]).Value;
                            _lstProperties.SelectedItems.Add(new DictionaryEntry(key, val));
                        }
                    }
                }

                _lstProperties.SelectedIndexChanged += LstPropertiesSelectedIndexChanged;
                _editorService.DropDownControl(_lstProperties);
                _lstProperties.SelectedIndexChanged -= LstPropertiesSelectedIndexChanged;

                if (_lstProperties.SelectedItems.Count > 0)
                {
                    var param = new ParameterCollection();
                    foreach (var item in _lstProperties.SelectedItems)
                    {
                        param.Add((Parameter)((DictionaryEntry)item).Value);
                    }
                    return param;
                }

                return new ParameterCollection();
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