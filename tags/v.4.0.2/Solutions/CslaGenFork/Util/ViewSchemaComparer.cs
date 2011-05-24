using System;
using System.Collections;
using System.Windows.Forms;
using SchemaExplorer;

namespace CslaGenerator.Util
{
	/// <summary>
	/// Summary description for ViewSchemaComparer.
	/// </summary>
	public class ViewSchemaComparer : IComparer
	{
		public ViewSchemaComparer()
		{
		}

		public int Compare(object x, object y)
		{
			return CaseInsensitiveComparer.Default.Compare(((ViewSchema)x).Name,((ViewSchema)y).Name);
		}
	}
}
