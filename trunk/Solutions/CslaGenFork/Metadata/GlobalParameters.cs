using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using CslaGenerator.Design;
using CslaGenerator.Util;

namespace CslaGenerator.Metadata
{
    [Serializable]
    public class GlobalParameters : INotifyPropertyChanged
    {
        #region State Fields

        const string DefaultEncoding = "iso-8859-1";
        string _codeEncoding = DefaultEncoding;
        string _codeEncodingDisplayName = "";
        string _sprocEncoding = DefaultEncoding;
        string _sprocEncodingDisplayName = "";
        bool _overwriteExtendedFile;
        bool _recompileTemplates;
        List<DbProvider> _dbProviders = new List<DbProvider>();
        private bool _dirty;

        #endregion

        #region Properties

        public string CodeEncoding
        {
            get { return _codeEncoding; }
            set
            {
                if (_codeEncoding == value)
                    return;
                _codeEncoding = value;
                OnPropertyChanged("CodeEncoding");
            }
        }

        public string CodeEncodingDisplayName
        {
            get { return _codeEncodingDisplayName; }
        }

        public string SprocEncoding
        {
            get { return _sprocEncoding; }
            set
            {
                if (_sprocEncoding == value)
                    return;
                _sprocEncoding = value;
                OnPropertyChanged("SprocEncoding");
            }
        }

        public string SprocEncodingDisplayName
        {
            get { return _sprocEncodingDisplayName; }
        }

        public bool OverwriteExtendedFile
        {
            get { return _overwriteExtendedFile; }
            set
            {
                if (_overwriteExtendedFile == value)
                    return;
                _overwriteExtendedFile = value;
                OnPropertyChanged("");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether recompile templates in case they changed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if recompile templates; otherwise, <c>false</c>.
        /// </value>
        public bool RecompileTemplates
        {
            get { return _recompileTemplates; }
            set
            {
                if (_recompileTemplates == value)
                    return;
                _recompileTemplates = value;
                OnPropertyChanged("");
            }
        }

        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        public List<DbProvider> DbProviders
        {
            get { return _dbProviders; }
            set
            {
                if (_dbProviders == value)
                    return;
                _dbProviders = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        public GlobalParameters()
        {
            LoadGlobalParameters(false);
        }

        internal void LoadGlobalParameters(bool factory)
        {
            if (factory)
            {
                CodeEncoding = DefaultEncoding;
                SprocEncoding = DefaultEncoding;
                OverwriteExtendedFile = false;
                RecompileTemplates = false;
                SaveGlobalParameters();
            }
            else
                LoadGlobalParameters();

            Dirty = false;
        }

        private void LoadGlobalParameters()
        {
            _codeEncoding = LoadValueForEncoding("CodeEncoding");
            _codeEncodingDisplayName = GetEncodigDescription(_codeEncoding);
            _sprocEncoding = LoadValueForEncoding("SProcEncoding");
            _sprocEncodingDisplayName = GetEncodigDescription(_sprocEncoding);
            _overwriteExtendedFile = LoadValueForOverwriteExtendedFile();
            _recompileTemplates = LoadValueForRecompileTemplates();
        }

        private string LoadValueForEncoding(string key)
        {
            var encoding = ConfigTools.SharedAppConfigGet(key);
            return ValidateEncoding(encoding);
        }

        private string GetEncodigDescription(string encoding)
        {
            var encode = Encoding.GetEncoding(encoding);
            return encode.EncodingName + " / CP " + encode.CodePage;
        }

        private string ValidateEncoding(string encoding)
        {
            if (string.IsNullOrWhiteSpace(encoding))
                return DefaultEncoding;

            try
            {
                var encode = Encoding.GetEncoding(encoding);
            }
            catch (Exception)
            {
                return DefaultEncoding;
            }

            return encoding;
        }

        private static bool LoadValueForOverwriteExtendedFile()
        {
            var result = false;
            var overwriteExtendedFile = ConfigTools.SharedAppConfigGet("OverwriteExtendedFile");

            if (string.IsNullOrWhiteSpace(overwriteExtendedFile))
                return result;

            try
            {
                result = Convert.ToBoolean(overwriteExtendedFile);
            }
            catch (Exception)
            {
            }

            return result;
        }

        private static bool LoadValueForRecompileTemplates()
        {
            var result = false;
            var recompileTemplates = ConfigTools.SharedAppConfigGet("RecompileTemplates");

            if (string.IsNullOrWhiteSpace(recompileTemplates))
                return result;

            try
            {
                result = Convert.ToBoolean(recompileTemplates);
            }
            catch (Exception)
            {
            }

            return result;
        }

        /*internal void Save(string filePath)
        {
            FileStream fs = null;
            var tempFile = Path.GetTempPath() + Guid.NewGuid() + ".cslagenerator";
            var success = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fs = File.Open(tempFile, FileMode.Create);
                var s = new XmlSerializer(typeof(GlobalParameters));
                s.Serialize(fs, this);
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(_mainForm, @"An error occurred while trying to save: " + Environment.NewLine + e.Message,
                    "Save Error");
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
                File.Delete(filePath);
                File.Move(tempFile, filePath);
                _currentFilePath = GetFilePath(filePath);
            }
        }*/

        internal void SaveGlobalParameters()
        {
            CodeEncoding = ValidateEncoding(_codeEncoding);
            ConfigTools.SharedAppConfigChange("CodeEncoding", CodeEncoding);
            SprocEncoding = ValidateEncoding(_sprocEncoding);
            ConfigTools.SharedAppConfigChange("SProcEncoding", SprocEncoding);
            ConfigTools.SharedAppConfigChange("OverwriteExtendedFile", _overwriteExtendedFile.ToString());
            ConfigTools.SharedAppConfigChange("RecompileTemplates", _recompileTemplates.ToString());

            Dirty = false;
        }

        [Browsable(false), XmlIgnore]
        public bool Dirty
        {
            get { return _dirty; }
            set { _dirty = value; }
        }

        internal GlobalParameters Clone()
        {
            GlobalParameters obj = null;
            try
            {
                obj = (GlobalParameters) ObjectCloner.CloneShallow(this);
                obj.Dirty = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obj;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case "CodeEncoding":
                    _codeEncodingDisplayName = GetEncodigDescription(_codeEncoding);
                    break;
                case "SprocEncoding":
                    _sprocEncodingDisplayName = GetEncodigDescription(_sprocEncoding);
                    break;
            }

            Dirty = true;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(""));
        }

        #endregion
    }
}