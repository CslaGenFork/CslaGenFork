using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for AssemblyRulesFileNameEditor.
    /// </summary>
    public class AssemblyRulesFileNameEditor : FileNameEditor, IDisposable
    {
        private OpenFileDialog _fileDialog;

        public AssemblyRulesFileNameEditor()
        {
            _fileDialog = new OpenFileDialog();
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _fileDialog.AutoUpgradeEnabled = true;
            _fileDialog.DefaultExt = "dll";
            _fileDialog.InitialDirectory = GeneratorController.Current.RulesDirectory;
            _fileDialog.Filter = @"Assembly files (*.DLL) | *.DLL|Executable files (*.EXE) | *.EXE";
            _fileDialog.RestoreDirectory = false;
            _fileDialog.Title = @"Select the Rules file";
            DialogResult result = _fileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
                return value;

            GeneratorController.Current.RulesDirectory = _fileDialog.FileName.Substring(0, _fileDialog.FileName.LastIndexOf('\\'));
            ConfigTools.SharedAppConfigChange("RulesDirectory", GeneratorController.Current.RulesDirectory); 
            return _fileDialog.FileName;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                if (_fileDialog != null)
                {
                    _fileDialog.Dispose();
                    _fileDialog = null;
                }
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}