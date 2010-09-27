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
	public class CriteriaTypeEditor : UITypeEditor
	{
		private IWindowsFormsEditorService editorService = null;
		private ListBox lstCriteria = new ListBox();
		private Type instance;

		public CriteriaTypeEditor()
		{
			lstCriteria.DisplayMember = "key";
			lstCriteria.ValueMember = "value";
			lstCriteria.SelectedIndexChanged += new EventHandler(lstCriteria_SelectedIndexChanged);
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
						instance = objinfo.GetType();
						PropertyInfo criteriaInfo = instance.GetProperty("CriteriaObjects");
						//CriteriaCollection criteria = (CriteriaCollection)criteriaInfo.GetValue(context.Instance,null);
						CriteriaCollection criteria = (CriteriaCollection)criteriaInfo.GetValue(objinfo,null);
						if (criteria != null && criteria.Count > 0)
						{
							lstCriteria.Items.Clear();
							for (int i = 0; i < criteria.Count; i++)
							{
								lstCriteria.Items.Add(new DictionaryEntry(criteria[i].Name,criteria[i]));
							}
							editorService.DropDownControl(lstCriteria);
							if (lstCriteria.SelectedItem != null)
							{
								return ((DictionaryEntry)lstCriteria.SelectedItem).Value;
							}
							else
							{
								return new Criteria();
							}
						}
					}
				}
			}
			
			return null;
		}

		private void lstCriteria_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (editorService != null)
			{
				editorService.CloseDropDown();
			}
		}
		
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if (context != null && context.Instance != null)
			{
				return UITypeEditorEditStyle.DropDown;
			}
			else { return base.GetEditStyle(context); }
		}
	}
}
