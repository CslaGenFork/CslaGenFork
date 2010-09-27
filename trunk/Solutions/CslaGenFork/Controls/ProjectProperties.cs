using System;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using System.IO;
using System.Xml.Serialization;

namespace CslaGenerator.Controls
{
    public partial class ProjectProperties : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public ProjectProperties()
        {
            InitializeComponent();
            DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            FillComboBox(cboOutputLanguage, typeof(CodeLanguage));
            FillComboBox(cboUIEnvironment, typeof(UIEnvironment));
            FillComboBox(cboTarget, typeof(TargetFramework));
            FillComboBox(cboGenerateAuthorization, typeof(Authorization));
            FillComboBox(cboHeaderVerbosity, typeof(HeaderVerbosity));
            FillComboBox(cboTransactionType, typeof(TransactionType));
            FillComboBox(cboPersistenceType, typeof(PersistenceType));
            FillComboBox(cboCreateTimestampPropertyMode, typeof(PropertyDeclaration));
//            FillComboBox(cboPropertyMode, typeof(CslaPropertyMode));
            FillComboBox(cboCreateReadOnlyObjectsPropertyMode, typeof(PropertyDeclaration));
            foreach (TabPage tab in tabControl1.TabPages)
                foreach (Control ctl in tab.Controls)
                    foreach (Binding b in ctl.DataBindings)
                        b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        }


        void FillComboBox(ComboBox cbo, Type enumType)
        {
            foreach (string str in Enum.GetNames(enumType))
            {
                cbo.Items.Add(str);
            }
            cbo.Tag = enumType;
            cbo.DataBindings[0].Parse += new ConvertEventHandler(EnumDropDown_Parse);
        }

        void EnumDropDown_Parse(object sender, ConvertEventArgs e)
        {
            Binding binding = (Binding)sender;
            ComboBox cbo = (ComboBox)binding.Control;
            Type t = (Type)cbo.Tag;
            e.Value = Enum.Parse(t, e.Value.ToString());

        }

        private CslaGeneratorUnit mProject
        {
            get
            {
                return GeneratorController.Current.CurrentUnit;
            }
        }

        private GenerationParameters genParams = null;
        private ProjectParameters projParams = null;

        public void LoadInfo()
        {
            genParams = mProject.GenerationParams.Clone();
            projParams = mProject.Params.Clone();
            generationParametersBindingSource.DataSource = genParams;
            projectParametersBindingSource.DataSource = projParams;
        }

        public void SaveInfo()
        {
            if (genParams.Dirty)
                mProject.GenerationParams = genParams.Clone();
            if (projParams.Dirty)
                mProject.Params = projParams.Clone();
            LoadInfo();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            DialogResult confirm = DialogResult.No;
            if (!(projParams.SpGeneralPrefix.Equals(mProject.Params.SpGeneralPrefix) &&
                projParams.SpGetPrefix.Equals(mProject.Params.SpGetPrefix) &&
                projParams.SpAddPrefix.Equals(mProject.Params.SpAddPrefix) &&
                projParams.SpUpdatePrefix.Equals(mProject.Params.SpUpdatePrefix) &&
                projParams.SpDeletePrefix.Equals(mProject.Params.SpDeletePrefix) &&
                projParams.SpGeneralSuffix.Equals(mProject.Params.SpGeneralSuffix) &&
                projParams.SpGetSuffix.Equals(mProject.Params.SpGetSuffix) &&
                projParams.SpAddSuffix.Equals(mProject.Params.SpAddSuffix) &&
                projParams.SpUpdateSuffix.Equals(mProject.Params.SpUpdateSuffix) &&
                projParams.SpDeleteSuffix.Equals(mProject.Params.SpDeleteSuffix)))
            {
                confirm = MessageBox.Show("Your SP headings have changed. Do you wish to update your business objects to reflect these changes?", "SP Naming", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            SaveInfo();
            GeneratorController.Current.ReloadPropertyGrid();
            if (confirm == DialogResult.Yes)
            {
                foreach (Metadata.CslaObjectInfo info in this.mProject.CslaObjects)
                {
                    info.SetProcedureNames();
                }
            }
        }

        private void cmdUndo_Click(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileSave = new OpenFileDialog();
            fileSave.Title = "Export project settings - Select an existing file or type a new file name";
            fileSave.Filter = "CSLA Gen files (*.xml) | *.xml";
            fileSave.DefaultExt = "xml";
            fileSave.Multiselect = false;
            fileSave.CheckFileExists = false;
            fileSave.CheckPathExists = true;
            fileSave.AddExtension = true;
            DialogResult result = fileSave.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            Application.DoEvents();
            ExportParams(fileSave.FileName);
        }

        private void cmdGetDefault_Click(object sender, EventArgs e)
        {
            ImportParams(Application.StartupPath + @"\Default.xml");
        }

        private void cmdSetDefault_Click(object sender, EventArgs e)
        {
            ExportParams(Application.StartupPath + @"\Default.xml");
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileLoad = new OpenFileDialog();
            fileLoad.Title = "Import project settings - Select an existing file";
            fileLoad.Filter = "CSLA Gen files (*.xml) | *.xml";
            fileLoad.DefaultExt = "xml";
            fileLoad.CheckFileExists = true;
            fileLoad.CheckPathExists = true;
            fileLoad.Multiselect = false;
            DialogResult result = fileLoad.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            Application.DoEvents();
            ImportParams(fileLoad.FileName);            
        }

        private void ImportParams(string filename)
        {
            Cursor _currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            CslaGeneratorUnit _unit = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    XmlSerializer s = new XmlSerializer(typeof(CslaGeneratorUnit));
                    _unit = (CslaGeneratorUnit)s.Deserialize(fs);
                }
                if (_unit != null)
                {
                    mProject.Params = _unit.Params;
                    mProject.GenerationParams = _unit.GenerationParams;
                    LoadInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to import: " + Environment.NewLine + ex.Message, "Import Error");
            }
            finally
            {
                Cursor.Current = _currentCursor;
            }
        }

        public void ExportParams(string fileName)
        {
            if (!ApplyProjectProperties())
                return;

            var privateUnit = new CslaGeneratorUnit();
            privateUnit.GenerationParams = genParams.Clone();
            privateUnit.Params = projParams.Clone();
            FileStream fs = null;
            string tempFile = Path.GetTempPath() + Guid.NewGuid() + ".cslagenerator";
            bool success = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fs = File.Open(tempFile, FileMode.Create);
                XmlSerializer s = new XmlSerializer(typeof(CslaGeneratorUnit));
                s.Serialize(fs, privateUnit);
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to export: " + Environment.NewLine + ex.Message, "Export Error");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                fs.Close();
            }

            if (success)
            {
                File.Delete(fileName);
                File.Move(tempFile, fileName);
            }
        }

        private void generationParametersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (IsDirty)
                TabText = "Project Properties*";
            else
                TabText = "Project Properties";
        }

        public bool IsDirty
        {
            get
            {
                return (genParams.Dirty || projParams.Dirty);
            }
        }

        internal bool ApplyProjectProperties()
        {
            if (IsDirty)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes in the project properties tab. Would you like to apply them now?", "CslaGenerator", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
    }
}
