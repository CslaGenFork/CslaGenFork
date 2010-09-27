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
	public class PropertyCollectionEditor : UITypeEditor
	{
		private IWindowsFormsEditorService editorService = null;
		private ListBox lstProperties;
		//private Type instance;

		public PropertyCollectionEditor()
		{
			lstProperties = new ListBox();
			lstProperties.DisplayMember = "key";
			lstProperties.ValueMember = "value";
			lstProperties.SelectionMode = SelectionMode.MultiSimple;
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

						CslaObjectInfo obj = (CslaObjectInfo)objinfo;
							 
						ValuePropertyCollection valueProps = obj.GetAllValueProperties();
						if (valueProps.Count > 0)
						{
							lstProperties.Items.Clear();
							lstProperties.Items.Add(new DictionaryEntry("None",new ValueProperty()));
							lstProperties.SelectedIndexChanged += new EventHandler(lstProperties_SelectedIndexChanged);
							for (int i = 0; i < valueProps.Count; i++)
							{
								lstProperties.Items.Add(new DictionaryEntry(valueProps[i].Name,valueProps[i]));
							}
							editorService.DropDownControl(lstProperties);
							lstProperties.SelectedIndexChanged -= new EventHandler(lstProperties_SelectedIndexChanged);
							if (lstProperties.SelectedItems != null && lstProperties.SelectedItems.Count > 0)
							{
								PropertyCollection prop = new PropertyCollection();
								foreach (object item in lstProperties.SelectedItems)
								{
									prop.Add((Property)((DictionaryEntry)item).Value);
								}
								return prop;
							}
							else { return new PropertyCollection(); }
						}
					}
				}
			}
			return value;
		}
		
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			return UITypeEditorEditStyle.DropDown;
		}

		private void lstProperties_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstProperties.SelectedIndices.Contains(0))
				for (int i = 0; i < lstProperties.Items.Count; i++)
				{
					 lstProperties.SetSelected(i,false);
				}
		}
	}
}
