using System;
using System.Collections;
using System.Windows.Forms;
using SchemaExplorer;

namespace CslaGenerator.Util
{
	/// <summary>
	/// Summary description for TableSchemaComparer.
	/// </summary>
	public class TableSchemaComparer : IComparer
	{
		public TableSchemaComparer()
		{
		}

		public int Compare(object x, object y)
		{
			return CaseInsensitiveComparer.Default.Compare(((TableSchema)x).Name,((TableSchema)y).Name);
		}
	}
}
