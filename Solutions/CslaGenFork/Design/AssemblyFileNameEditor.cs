using System;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace CslaGenerator.Design
{
	/// <summary>
	/// Summary description for AssemblyFileNameEditor.
	/// </summary>
	public class AssemblyFileNameEditor : FileNameEditor
	{
		public AssemblyFileNameEditor()
		{
		}

		protected override void InitializeDialog(OpenFileDialog fileDialog)
		{
			fileDialog.InitialDirectory = "c:\\" ;
			fileDialog.Filter = "Assembly files (*.DLL) | *.DLL" ;
			fileDialog.RestoreDirectory = true ;
		}
	}
}
