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
    // guess isn't used any longer
    public class CriteriaTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private readonly ListBox _lstProperties = new ListBox();
        private Type _instance;

        public CriteriaTypeEditor()
        {
            _lstProperties.DisplayMember = "key";
            _lstProperties.ValueMember = "value";
            _lstProperties.SelectedIndexChanged += LstCriteriaSelectedIndexChanged;
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
                    _instance = objinfo.GetType();
                    var criteriaInfo = _instance.GetProperty("CriteriaObjects");
                    //CriteriaCollection criteria = (CriteriaCollection)criteriaInfo.GetValue(context.Instance,null);
                    var criteria = (CriteriaCollection)criteriaInfo.GetValue(objinfo, null);
                    if (criteria != null && criteria.Count > 0)
                    {
                        _lstProperties.Items.Clear();
                        for (int i = 0; i < criteria.Count; i++)
                        {
                            _lstProperties.Items.Add(new DictionaryEntry(criteria[i].Name, criteria[i]));
                        }
                        _editorService.DropDownControl(_lstProperties);
                        if (_lstProperties.SelectedItem != null)
                        {
                            return ((DictionaryEntry)_lstProperties.SelectedItem).Value;
                        }

                        return new Criteria();
                    }
                }
            }

            return null;
        }

        private void LstCriteriaSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_editorService != null)
            {
                _editorService.CloseDropDown();
            }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }

            return base.GetEditStyle(context);
        }
    }
}