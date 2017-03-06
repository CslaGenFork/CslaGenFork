using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
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
        string _codeEncodingDisplayName = string.Empty;
        string _sprocEncoding = DefaultEncoding;
        string _sprocEncodingDisplayName = string.Empty;
        bool _overwriteExtendedFile;
        bool _recompileTemplates;
        DbProviderCollection _dbProviderCollection = new DbProviderCollection();

        #endregion

        #region Properties

        public string CodeEncoding
        {
            get { return _codeEncoding; }
            set
            {
                if (_codeEncoding == value)
                    return;
                _codeEncoding = ValidateEncoding(value);
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
                _sprocEncoding = ValidateEncoding(value);
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
        public DbProviderCollection DbProviderCollection
        {
            get { return _dbProviderCollection; }
            set
            {
                if (_dbProviderCollection == value)
                    return;
                _dbProviderCollection = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Constructor

        public GlobalParameters()
        {
            OnPropertyChanged("CodeEncoding");
            OnPropertyChanged("SprocEncoding");
        }

        #endregion

        #region Encoding helper methods

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

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
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

        private bool _dirty;

        [Browsable(false)]
        internal bool Dirty
        {
            get { return _dirty || _dbProviderCollection.Dirty; }
            set
            {
                _dirty = value;
                _dbProviderCollection.Dirty = _dirty;
            }
        }

        #endregion

        #region Clone

        internal GlobalParameters Clone()
        {
            GlobalParameters obj = null;
            try
            {
                obj = (GlobalParameters) ObjectCloner.CloneDeep(this);
                obj.Dirty = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obj;
        }

        #endregion
    }
}