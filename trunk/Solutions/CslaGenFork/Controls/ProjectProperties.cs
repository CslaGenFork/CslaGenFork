using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator.Controls
{
    internal partial class ProjectProperties : DockContent
    {
        #region Fix for form flicker

        // http://www.angryhacker.com/blog/archive/2010/07/21/how-to-get-rid-of-flicker-on-windows-forms-applications.aspx

        int _originalExStyle = -1;
        private bool _enableFormLevelDoubleBuffering = true;

        protected override CreateParams CreateParams
        {
            get
            {
                if (_originalExStyle == -1)
                    _originalExStyle = base.CreateParams.ExStyle;
                CreateParams cp = base.CreateParams;
                if (_enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                else
                    cp.ExStyle = _originalExStyle;
                return cp;
            }
        }

        internal void TurnOnFormLevelDoubleBuffering()
        {
            _enableFormLevelDoubleBuffering = true;
        }

        internal void TurnOffFormLevelDoubleBuffering()
        {
            _enableFormLevelDoubleBuffering = false;
            MaximizeBox = true;
        }

        private void ProjectProperties_Shown(object sender, EventArgs e)
        {
            TurnOffFormLevelDoubleBuffering();
        }

        private void ProjectProperties_ResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
            TurnOnFormLevelDoubleBuffering();
        }

        private void ProjectProperties_ResizeEnd(object sender, EventArgs e)
        {
            TurnOffFormLevelDoubleBuffering();
            ResumeLayout(true);
        }

        #endregion

        #region Fields and Properties

        private CslaGeneratorUnit Project
        {
            get { return GeneratorController.Current.CurrentUnit; }
        }

        private static GenerationParameters _genParams;

        public static GenerationParameters GenParams
        {
            get { return _genParams; }
        }

        private ProjectParameters _projParams;

        #endregion

        #region Constructor

        internal ProjectProperties()
        {
            InitializeComponent();

            FillComboBox(cboOutputLanguage, typeof(CodeLanguage));
            FillComboBox(cboTarget, typeof(TargetFramework));
            FillComboBox(cboGenerateAuthorization, typeof(AuthorizationLevel));
            FillComboBox(cboHeaderVerbosity, typeof(HeaderVerbosity));
            FillComboBox(cboTransactionType, typeof(TransactionType));
            FillComboBox(cboPersistenceType, typeof(PersistenceType));
            FillComboBox(cboInlineQueries, typeof(UseInlineQueries));
            FillComboBox(cboObjectNotFound, typeof(ReportObjectNotFound));
        }

        #endregion

        private void FillComboBox(ComboBox cbo, Type enumType)
        {
            var converter = TypeDescriptor.GetConverter(enumType);

            foreach (var value in Enum.GetValues(enumType))
            {
                var converted = converter.ConvertToString(value);
                if (converted != null)
                    cbo.Items.Add(converted);
            }
            cbo.Tag = enumType;
            cbo.DataBindings[0].Parse += EnumDropDownParse;
        }

        private void EnumDropDownParse(object sender, ConvertEventArgs e)
        {
            var binding = (Binding) sender;
            var cbo = (ComboBox) binding.Control;

            if (cbo != null)
            {
                var enumType = (Type) cbo.Tag;
                var converter = TypeDescriptor.GetConverter(enumType);

                var converted = converter.ConvertFromInvariantString(e.Value.ToString());
                if (converted != null)
                {
                    var value = Enum.Parse(enumType, converted.ToString());
                    e.Value = value;
                }
            }
        }

        internal void LoadInfo()
        {
            _genParams = Project.GenerationParams.Clone();
            _projParams = Project.Params.Clone();
            generationParametersBindingSource.DataSource = _genParams;
            generationDbProviderCollectionBindingSource.DataSource = _genParams.GenerationDbProviderCollection;
            projectParametersBindingSource.DataSource = _projParams;

            NotYetImplemented();
        }

        private void NotYetImplemented()
        {
            txtIntSoftDelete.Enabled = false;
        }

        internal void SaveInfo()
        {
            if (_genParams.Dirty)
                Project.GenerationParams = _genParams.Clone();
            if (_projParams.Dirty)
                Project.Params = _projParams.Clone();
            LoadInfo();
        }

        private void CmdApplyClick(object sender, EventArgs e)
        {
            if (!ValidateOptions())
                return;

            var confirm = DialogResult.No;
            if (!(_projParams.SpGeneralPrefix.Equals(Project.Params.SpGeneralPrefix) &&
                  _projParams.SpGetPrefix.Equals(Project.Params.SpGetPrefix) &&
                  _projParams.SpAddPrefix.Equals(Project.Params.SpAddPrefix) &&
                  _projParams.SpUpdatePrefix.Equals(Project.Params.SpUpdatePrefix) &&
                  _projParams.SpDeletePrefix.Equals(Project.Params.SpDeletePrefix) &&
                  _projParams.SpGeneralSuffix.Equals(Project.Params.SpGeneralSuffix) &&
                  _projParams.SpGetSuffix.Equals(Project.Params.SpGetSuffix) &&
                  _projParams.SpAddSuffix.Equals(Project.Params.SpAddSuffix) &&
                  _projParams.SpUpdateSuffix.Equals(Project.Params.SpUpdateSuffix) &&
                  _projParams.SpDeleteSuffix.Equals(Project.Params.SpDeleteSuffix)))
            {
                confirm =
                    MessageBox.Show(
                        @"Your SP headings have changed. Do you wish to update your business objects to reflect these changes?",
                        @"SP Naming", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            SaveInfo();
            GeneratorController.Current.ReloadPropertyGrid();
            if (confirm == DialogResult.Yes)
            {
                foreach (var info in Project.CslaObjects)
                {
                    info.SetProcedureNames();
                }
            }
        }

        private void CmdUndoClick(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void CmdExportClick(object sender, EventArgs e)
        {
            using (var fileSave = new OpenFileDialog())
            {
                fileSave.Title = @"Export project settings - Select an existing file or type a new file name";
                fileSave.Filter = @"CSLA Gen files (*.xml) | *.xml";
                fileSave.DefaultExt = "xml";
                fileSave.Multiselect = false;
                fileSave.CheckFileExists = false;
                fileSave.CheckPathExists = true;
                fileSave.AddExtension = true;
                var result = fileSave.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

                Application.DoEvents();
                ExportParams(fileSave.FileName);
            }
        }

        private void CmdGetDefaultClick(object sender, EventArgs e)
        {
            ImportParams(ConfigTools.DefaultXml);
        }

        private void CmdSetDefaultClick(object sender, EventArgs e)
        {
            ExportParams(ConfigTools.DefaultXml);
        }

        private void CmdResetToFactoryClick(object sender, EventArgs e)
        {
            ImportParams(Application.StartupPath + @"\Factory.xml");
        }

        private void CmdImportClick(object sender, EventArgs e)
        {
            using (var fileLoad = new OpenFileDialog())
            {
                fileLoad.Title = @"Import project settings - Select an existing file";
                fileLoad.Filter = @"CSLA Gen files (*.xml) | *.xml";
                fileLoad.DefaultExt = "xml";
                fileLoad.CheckFileExists = true;
                fileLoad.CheckPathExists = true;
                fileLoad.Multiselect = false;
                var result = fileLoad.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

                Application.DoEvents();
                ImportParams(fileLoad.FileName);
            }
        }

        private void ImportParams(string filename)
        {
            var currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CslaGeneratorUnit unit;
                using (var fs = File.Open(filename, FileMode.Open, FileAccess.Read))
                {
                    var s = new XmlSerializer(typeof(CslaGeneratorUnit));
                    unit = (CslaGeneratorUnit) s.Deserialize(fs);
                }
                if (unit != null)
                {
                    Project.Params = unit.Params;
                    Project.GenerationParams = unit.GenerationParams;
                    Project.ProjectName = unit.ProjectName;
                    Project.TargetDirectory = unit.TargetDirectory;
                    LoadInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"An error occurred while trying to import: " + Environment.NewLine + ex.Message,
                    @"Import Error");
            }
            finally
            {
                Cursor.Current = currentCursor;
            }
        }

        internal void ExportParams(string fileName)
        {
            if (!ApplyProjectProperties())
                return;

            var privateUnit = new CslaGeneratorUnit();
            privateUnit.GenerationParams = _genParams.Clone();
            privateUnit.Params = _projParams.Clone();
            privateUnit.ProjectName = GeneratorController.Current.CurrentUnit.ProjectName;
            privateUnit.TargetDirectory = GeneratorController.Current.CurrentUnit.TargetDirectory;
            FileStream fs = null;
            var tempFile = Path.GetTempPath() + Guid.NewGuid() + ".cslagenerator";
            var success = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fs = File.Open(tempFile, FileMode.Create);
                var s = new XmlSerializer(typeof(CslaGeneratorUnit));
                s.Serialize(fs, privateUnit);
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"An error occurred while trying to export: " + Environment.NewLine + ex.Message,
                    @"Export Error");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

            if (success)
            {
                File.Delete(fileName);
                File.Move(tempFile, fileName);
            }
        }

        private void GenerationParametersBindingSourceCurrentItemChanged(object sender, EventArgs e)
        {
            if (IsDirty)
                TabText = @"Project Properties *";
            else
                TabText = @"Project Properties";

            chkSynchronous.Enabled = !_genParams.ForceSync;
            chkAsynchronous.Enabled = !_genParams.ForceAsync;
            cboGenerateAuthorization.Enabled = true;
            chkUsesCslaAuthorizationProvider.Enabled =
                _genParams.GenerateAuthorization != AuthorizationLevel.None &&
                _genParams.GenerateAuthorization != AuthorizationLevel.Custom;
            chkGenerateDTO.Enabled = UseDal;
            chkGenerateDalInterface.Enabled = UseDal;
            chkGenerateDalObject.Enabled = UseDal;
            txtDalInterfaceNamespace.Enabled = UseDal;
            txtDalObjectNamespace.Enabled = UseDal && !_genParams.ForceDalObjectNamespace;
            chkGenerateDatabaseClass.Enabled = !UseDal;
            txtDalName.Enabled = UseDal;
            txtDatabase.Enabled = false;
            txtDatabaseConnection.Enabled = true;
            txtUtilitiesFolder.Enabled = !_genParams.SeparateNamespaces;
            chkWinForms.Enabled = true;
            chkWPF.Enabled = true;
            chkSilverlight.Enabled = true;
            chkSilverlightUseServices.Enabled = true;
            chkGenerateQueriesWithSchema.Enabled = true;
            chkUsePublicPropertyInfo.Enabled = true;
            chkUseChildFactory.Enabled = true;
            chkSpOneFile.Enabled = _genParams.GenerateSprocs;
        }

        internal bool IsDirty
        {
            get { return _genParams.Dirty || _projParams.Dirty; }
        }

        private bool UseDal
        {
            get { return (_genParams.UseDal); }
        }

        internal bool ApplyProjectProperties()
        {
            if (IsDirty)
            {
                var result =
                    MessageBox.Show(
                        @"There are unsaved changes in the project properties tab. Would you like to apply them now?",
                        @"CslaGenerator", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        cmdApply.PerformClick();
                        break;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        internal bool ValidateOptions()
        {
            var result = true;

            if (!_genParams.GenerateWinForms && !_genParams.GenerateWPF && _genParams.SilverlightUsingServices && UseDal)
            {
                result = false;
                MessageBox.Show(@"Must select at least one of these options:" + Environment.NewLine +
                                @"- Windows Forms" + Environment.NewLine +
                                @"- WPF",
                    @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!_genParams.GenerateWinForms && !_genParams.GenerateWPF && _genParams.GenerateSilverlight4)
            {
                result = false;
                MessageBox.Show(@"Must select at least one of these options:" + Environment.NewLine +
                                @"- Windows Forms" + Environment.NewLine +
                                @"- WPF",
                    @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!_genParams.GenerateWinForms && !_genParams.GenerateWPF && !_genParams.SilverlightUsingServices)
            {
                result = false;
                MessageBox.Show(@"Must select at least one of these options:" + Environment.NewLine +
                                @"- Windows Forms" + Environment.NewLine +
                                @"- WPF" + Environment.NewLine +
                                @"- Silverlight using services",
                    @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!_genParams.GenerateAsynchronous && !_genParams.GenerateSynchronous &&
                (_genParams.GenerateWinForms || _genParams.GenerateWPF))
            {
                result = false;
                MessageBox.Show(@"Must select either Synchronous or Asynchronous server methods.", @"CslaGenerator",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        #region Manage state

        internal void GetState()
        {
            TabPage mainTabPage = null;
            TabPage subTabPage = null;

            foreach (var control1 in Controls)
            {
                if (control1.GetType() == typeof(TabControl))
                {
                    var mainTabControl = control1 as TabControl;
                    if (mainTabControl != null)
                    {
                        foreach (var subControl1 in mainTabControl.TabPages)
                        {
                            mainTabPage = subControl1 as TabPage;
                            if (mainTabPage != null && (mainTabPage.ContainsFocus || mainTabPage.Visible))
                            {
                                foreach (var control2 in mainTabPage.Controls)
                                {
                                    if (control2.GetType() == typeof(TabControl))
                                    {
                                        var subTabControl = control2 as TabControl;
                                        if (subTabControl != null)
                                        {
                                            foreach (var subControl2 in subTabControl.TabPages)
                                            {
                                                subTabPage = subControl2 as TabPage;
                                                if (subTabPage != null &&
                                                    (subTabPage.ContainsFocus || subTabPage.Visible))
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    break;
                }
            }

            if (mainTabPage != null)
            {
                GeneratorController.Current.CurrentUnitLayout.ProjectPropertiesMainTab = mainTabPage.Name;
                GeneratorController.Current.CurrentUnitLayout.ProjectPropertiesMainTabHidden = false;
            }
            else
                GeneratorController.Current.CurrentUnitLayout.ProjectPropertiesMainTab = string.Empty;

            if (subTabPage != null)
                GeneratorController.Current.CurrentUnitLayout.ProjectPropertiesSubTab = subTabPage.Name;
            else
                GeneratorController.Current.CurrentUnitLayout.ProjectPropertiesSubTab = string.Empty;
        }

        internal void SetState()
        {
            foreach (var control1 in Controls)
            {
                if (control1.GetType() == typeof(TabControl))
                {
                    var tabControl1 = control1 as TabControl;
                    if (tabControl1 != null)
                    {
                        ScrollControlIntoView(tabControl1);
                        tabControl1.Visible = true;
                        tabControl1.Focus();
                        for (var index1 = 0; index1 < tabControl1.TabPages.Count; index1++)
                        {
                            var tabPage1 = tabControl1.TabPages[index1];
                            if (tabPage1.Name == GeneratorController.Current.CurrentUnitLayout.ProjectPropertiesMainTab)
                            {
                                tabControl1.SelectedIndex = index1;
                                tabPage1.Focus();
                                foreach (var control2 in tabPage1.Controls)
                                {
                                    if (control2.GetType() == typeof(TabControl))
                                    {
                                        var tabControl2 = control2 as TabControl;
                                        if (tabControl2 != null)
                                        {
                                            tabPage1.ScrollControlIntoView(tabControl2);
                                            tabControl2.Visible = true;
                                            tabControl2.Focus();
                                            for (var index2 = 0; index2 < tabControl2.TabPages.Count; index2++)
                                            {
                                                var tabPage2 = tabControl2.TabPages[index2];
                                                if (tabPage2.Name ==
                                                    GeneratorController.Current.CurrentUnitLayout
                                                        .ProjectPropertiesSubTab)
                                                {
                                                    tabControl2.SelectedIndex = index2;
                                                    tabPage2.Focus();
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }

        #endregion

        private void CopyGlobalParametersClick(object sender, EventArgs e)
        {
            _genParams.GenerationDbProviderCollection.Clear();

            foreach (var dbProvider in GeneratorController.Current.GlobalParameters.DbProviderCollection)
            {
                var provider = new GenerationDbProvider();
                provider.DBProviderShortName = dbProvider.DbProviderShortName;
                provider.NamespaceSuffix = dbProvider.DbProviderShortName;
                provider.DBProviderIsActive = true;
                _genParams.GenerationDbProviderCollection.Add(provider);
            }
        }

        private void DbProviderCollectionBindingSourceCurrentItemChanged(object sender, EventArgs e)
        {
            if (IsDirty)
                TabText = @"Project Properties *";
            else
                TabText = @"Project Properties";
        }
    }
}