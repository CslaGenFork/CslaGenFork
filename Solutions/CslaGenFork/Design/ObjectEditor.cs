using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
	/// <summary>
	/// Summary description for ObjectEditor.
	/// </summary>
	public class ObjectEditor : UITypeEditor
	{
		private IWindowsFormsEditorService editorService = null;

		public ObjectEditor()
		{
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
		{
			if (provider != null)
			{
				editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if (editorService != null) 
				{
					ObjectEditorForm frmEdit = new ObjectEditorForm();
					object temp = ((ICloneable)value).Clone();
					frmEdit.ObjectToEdit = temp;
					DialogResult result = editorService.ShowDialog(frmEdit);
					if (result == DialogResult.OK)
					{
						Copy(value, temp);
						return value;
					}
					else
					{
						return value;
					}
				}
			}
			
			return value;
		}
		
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			return UITypeEditorEditStyle.Modal;
		}

		private void Copy(Object dest, Object src)
		{
			try
			{
				Type destType = dest.GetType();
				Type srcType = src.GetType();
				if (destType.Equals(srcType))
				{
					PropertyInfo[] destProps = destType.GetProperties();
					PropertyInfo[] srcProps = srcType.GetProperties();
					for (int i = 0; i < destProps.Length; i++)
					{
						if (destProps[i].CanWrite)
						{
							object val = srcProps[i].GetValue(src, null);
							if (val != null)
							{
								destProps[i].SetValue(dest, val, null); //srcProps[i].GetValue(src, null), null);
							}
							else
							{
								destProps[i].SetValue(dest, null, null);
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
	}
}
