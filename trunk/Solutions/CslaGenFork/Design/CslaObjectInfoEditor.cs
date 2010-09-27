using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Collections;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
	// TODO: This editor is used in TypeInfo class for ObjectMetabata property. 
	// Make this editor to work with TypeInfo.ObjectName property. 
	// One possible solution would be to have shared GeneratorController.CurrentUnit property, 
	// and to enumerate CslaObjects collection. 
	public class CslaObjectInfoEditor : UITypeEditor
	{
		private IWindowsFormsEditorService editorService = null;
		private ListBox lstObjectInfo = null;
		private Type instance;

		public CslaObjectInfoEditor()
		{
			lstObjectInfo = new ListBox();
			lstObjectInfo.DisplayMember = "key";
			lstObjectInfo.ValueMember = "value";
			lstObjectInfo.SelectedValueChanged += new EventHandler(Value_Changed);
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

						lstObjectInfo.Items.Clear();
						lstObjectInfo.Items.Add(new DictionaryEntry("None", null));
						// Get object info properties
						PropertyInfo parentInfo = instance.GetProperty("Parent");
						//CslaObjectInfo cslaObj = (CslaObjectInfo)parentInfo.GetValue(context.Instance, null);
						CslaObjectInfo cslaObj = (CslaObjectInfo)parentInfo.GetValue(objinfo, null);
						foreach (CslaObjectInfo obj in cslaObj.Parent.CslaObjects)
						{
							lstObjectInfo.Items.Add(new DictionaryEntry(obj.ObjectName,obj));
						}
						
						editorService.DropDownControl(lstObjectInfo);
						if (lstObjectInfo.SelectedItem != null)
						{
							return (CslaObjectInfo)((DictionaryEntry)lstObjectInfo.SelectedItem).Value;
						}
					}
				}
			}
			
			return value;
		}
		
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			return UITypeEditorEditStyle.Modal;
		}

		private void Value_Changed(object sender, EventArgs e)
		{
			if (editorService != null)
			{
				editorService.CloseDropDown();
			}
		}
	}
}
