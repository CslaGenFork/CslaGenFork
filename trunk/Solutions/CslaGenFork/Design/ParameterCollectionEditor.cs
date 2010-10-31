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
    /// Summary description for ParameterCollectionEditor. Used by Childproperty.LoadParameters
    /// </summary>
    public class ParameterCollectionEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;
        private ListBox lstParameters;
        private object _instance = null;

        public ParameterCollectionEditor()
        {
            lstParameters = new ListBox();
            lstParameters.DoubleClick += lstProperties_DoubleClick;
            lstParameters.DisplayMember = "key";
            lstParameters.ValueMember = "value";
            lstParameters.SelectionMode = SelectionMode.MultiSimple;
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
                if (editorService != null && context.Instance != null)
                {
                    // CR modifying to accomodate PropertyBag
                    Type instanceType = null;
                    object objinfo = null;
                    TypeHelper.GetChildPropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    PropertyInfo propInfo = instanceType.GetProperty("LoadParameters");
                    ParameterCollection paramColl = (ParameterCollection)propInfo.GetValue(objinfo, null);

                    if (instanceType != typeof(CslaObjectInfo))
                    {
                        _instance = GeneratorController.Current.GeneratorForm.ProjectPanel.ListObjects.SelectedItem;
                        //_instance = GetInfoTypeInstance(objinfo);
                    }
                    else
                    {
                        //_instance = context.Instance;
                        _instance = objinfo;
                    }
                    PropertyInfo criteriaInfo = typeof(CslaObjectInfo).GetProperty("CriteriaObjects");
                    object criteriaObjects = criteriaInfo.GetValue(_instance,null);

                    lstParameters.Items.Clear();
                    foreach (Criteria crit in (CriteriaCollection)criteriaObjects)
                    {
                        if (crit.GetOptions.Factory || crit.GetOptions.AddRemove || crit.GetOptions.DataPortal)
                        {
                            foreach (Property prop in crit.Properties)
                            {
                                lstParameters.Items.Add(new DictionaryEntry(crit.Name + "." + prop.Name,
                                                                            new Parameter(crit, prop)));
                            }
                        }
                    }
                    lstParameters.Sorted = true;

                    foreach (Parameter param in paramColl)
                    {
                        var key = param.Criteria.Name + "." + param.Property.Name;
                        for (var entry = 0; entry < lstParameters.Items.Count; entry++)
                        {
                            if (key == ((DictionaryEntry)lstParameters.Items[entry]).Key.ToString())
                            {
                                var val = (Parameter)((DictionaryEntry)lstParameters.Items[entry]).Value;
                                lstParameters.SelectedItems.Add(new DictionaryEntry(key, val));
                            }
                        }
                    }

                    editorService.DropDownControl(lstParameters);

                    if (lstParameters.SelectedItems != null && lstParameters.SelectedItems.Count > 0)
                    {
                        ParameterCollection param = new ParameterCollection();
                        foreach (object item in lstParameters.SelectedItems)
                        {
                            param.Add((Parameter)((DictionaryEntry)item).Value);
                        }
                        return param;
                    }

                    return new ParameterCollection();
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        //private object GetInfoTypeInstance(object o)
        //{
        //    if (o is ChildProperty)
        //    {
        //        //return ChildProperty.Parent;
        //    }
        //    else { throw new Exception("Invalid type"); }
        //}
    }
}
