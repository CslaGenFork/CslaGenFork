using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using System.Diagnostics;

namespace CslaGenerator.Design
{
	/// <summary>
	/// Summary description for ParameterCollectionEditor.
	/// </summary>
	public class ParameterCollectionEditor : UITypeEditor
	{
		private IWindowsFormsEditorService editorService = null;
		private ListBox lstParameters;
		private object _instance = null;

		public ParameterCollectionEditor()
		{
			lstParameters = new ListBox();
			lstParameters.DisplayMember = "key";
			lstParameters.ValueMember = "value";
			lstParameters.SelectionMode = SelectionMode.MultiSimple;
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
					TypeHelper.GetContextInstanceObject(context, ref objinfo, ref instanceType);					 

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
						foreach(Property prop in crit.Properties)
						{
							lstParameters.Items.Add(new DictionaryEntry(crit.Name + "." + prop.Name, new Parameter(crit,prop)));
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
					else { return new ParameterCollection(); }
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
