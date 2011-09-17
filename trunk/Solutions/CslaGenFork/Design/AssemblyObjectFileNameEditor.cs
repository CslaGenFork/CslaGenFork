using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for AssemblyObjectFileNameEditor.
    /// </summary>
    public class AssemblyObjectFileNameEditor : FileNameEditor
    {
        private OpenFileDialog _fileDialog;

        public AssemblyObjectFileNameEditor()
        {
            _fileDialog = new OpenFileDialog();
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _fileDialog.AutoUpgradeEnabled = true;
            _fileDialog.DefaultExt = "dll";
            _fileDialog.InitialDirectory = GeneratorController.Current.ObjectsFolderPath;
            _fileDialog.Filter = @"Assembly files (*.DLL) | *.DLL|Executable files (*.EXE) | *.EXE";
            _fileDialog.RestoreDirectory = false;
            _fileDialog.Title = @"Select the Objects file";
            DialogResult result = _fileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
                return value;

            GeneratorController.Current.ObjectsFolderPath =
                _fileDialog.FileName.Substring(0, _fileDialog.FileName. LastIndexOf('\\'));
            return _fileDialog.FileName;
        }
    }
}