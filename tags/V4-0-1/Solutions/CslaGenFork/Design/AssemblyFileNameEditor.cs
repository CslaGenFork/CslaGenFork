using System.Windows.Forms;
using System.Windows.Forms.Design;

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
            fileDialog.Filter = @"Assembly files (*.DLL) | *.DLL" ;
            fileDialog.RestoreDirectory = true ;
        }
    }
}
