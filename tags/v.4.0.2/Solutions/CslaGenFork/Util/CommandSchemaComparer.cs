using System;
using System.Collections;
using System.Windows.Forms;
using SchemaExplorer;

namespace CslaGenerator.Util
{
	/// <summary>
	/// Summary description for CommandSchemaComparer.
	/// </summary>
	public class CommandSchemaComparer : IComparer
	{
		public CommandSchemaComparer()
		{
		}

		public int Compare(object x, object y)
		{
			return CaseInsensitiveComparer.Default.Compare(((CommandSchema)x).Name,((CommandSchema)y).Name);
		}
	}
}
