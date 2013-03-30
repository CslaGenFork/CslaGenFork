using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using HandleCodeSmithExtension.Properties;
using Ionic.Zip;
using Microsoft.VisualBasic;

namespace HandleCodeSmithExtension
{
    public partial class HandleCodeSmithExtension : Form
    {
        private static string _targetDir = string.Empty;
        private static bool _codeSmithDll = false;
        private static bool _codeSmithTraces = false;

        public HandleCodeSmithExtension()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _targetDir = Application.StartupPath + "\\";

            if (Windows7Security.IsVistaOrHigher())
            {
                Icon = new Icon(SystemIcons.Shield, 16, 16);
                PictureBox.Image = Resources.Security;
                Windows7Security.AddShieldToButton(InstallCodeSmith);
                Windows7Security.AddShieldToButton(UninstallCodeSmith);
            }
            else
            {
                Icon = new Icon(Resources.Cgf, 16, 16);
                PictureBox.Image = Resources.Cgf.ToBitmap();
            }

            UpdateCodeSmithExtensionStatus();
        }

        private void UpdateCodeSmithExtensionStatus()
        {
            _codeSmithDll = File.Exists(_targetDir + "CodeSmith.Engine.dll");
            _codeSmithTraces = _codeSmithDll || File.Exists(_targetDir + "CodeSmith.license.rtf");

            InstallCodeSmith.Enabled = !_codeSmithDll;
            UninstallCodeSmith.Enabled = _codeSmithTraces;

            if (InstallCodeSmith.Enabled)
            {
                InstallLbl1.Text = @"CodeSmith DLL not found.";
                InstallLbl2.Text = @"To enable all features of CslaGenFork install CodeSmith Extension.";
            }
            else
            {
                InstallLbl1.Text = string.Empty;
                InstallLbl2.Text = @"CodeSmith DLL found.";
            }

            if (UninstallCodeSmith.Enabled)
            {
                UninstallLbl1.Text = @"CodeSmith Extension file(s) found.";
                UninstallLbl2.Text = @"Remove all files before uninstalling CslaGenFork.";
            }
            else
            {
                UninstallLbl1.Text = string.Empty;
                UninstallLbl2.Text = @"CodeSmith Extension files not found";
            }
        }

        internal static void InstallCodeSmithExtension()
        {
            var openFile = new OpenFileDialog();
            openFile.Title = @"CodeSmith Extension - Select the free CodeSmith ZIP file";
            openFile.Filter = @"ZIP files (*.zip) | *.zip";
            openFile.DefaultExt = "zip";
            openFile.Multiselect = false;
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.AddExtension = true;
            var result = openFile.ShowDialog();
            if (result != DialogResult.OK)
                return;

            using (var zip = ZipFile.Read(openFile.FileName))
            {
                zip["CodeSmith.Engine.dll"].Extract(_targetDir, ExtractExistingFileAction.DoNotOverwrite);
                zip["license.rtf"].Extract(_targetDir, ExtractExistingFileAction.OverwriteSilently);
            }

            File.Delete(_targetDir + "CodeSmith.license.rtf");
            FileSystem.Rename(_targetDir + "license.rtf", _targetDir + "CodeSmith.license.rtf");
        }

        internal static void UninstallCodeSmithExtension()
        {
            try
            {
                File.Delete(_targetDir + "CodeSmith.license.rtf");
                File.Delete(_targetDir + "CodeSmith.Engine.dll");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    @"CslaGenFork locked the CodeSmith Extension files to generate code." +
                    Environment.NewLine +
                    @"Reopen CslaGenFork and retry.",
                    @"CodeSmith Extension Handler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InstallCodeSmithClick(object sender, System.EventArgs e)
        {
            InstallCodeSmithExtension();
            UpdateCodeSmithExtensionStatus();
        }

        private void UninstallCodeSmithClick(object sender, System.EventArgs e)
        {
            UninstallCodeSmithExtension();
            UpdateCodeSmithExtensionStatus();
        }

        private void ExitButtonClick(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}