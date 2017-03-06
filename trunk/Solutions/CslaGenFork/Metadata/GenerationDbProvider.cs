using System;
using System.ComponentModel;
using CslaGenerator.Controls;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for GenerationDbProvider.
    /// </summary>
    [Serializable]
    public class GenerationDbProvider : INotifyPropertyChanged
    {
        #region Fields and Properties

        private string _dbProviderShortName = string.Empty;
        private string _namespaceSuffix = string.Empty;

        // must be false so only-one-active rule always apply.
        private bool _dbProviderIsActive;

        internal GenerationDbProviderCollection Parent
        {
            get { return ProjectProperties.GenParams.GenerationDbProviderCollection; }
        }

        public string DBProviderShortName
        {
            get { return _dbProviderShortName; }
            set
            {
                if (_dbProviderShortName == value)
                    return;
                if (Parent.Contains(value))
                    return;

                _dbProviderShortName = value;
                OnPropertyChanged("DBProviderShortName");
            }
        }

        public string NamespaceSuffix
        {
            get { return _namespaceSuffix; }
            set
            {
                if (_namespaceSuffix == value)
                    return;
                if (Parent.ContainsNamespace(value))
                    return;

                _namespaceSuffix = value;
                OnPropertyChanged("DBProviderNamespace");
            }
        }

        public bool DBProviderIsActive
        {
            get { return _dbProviderIsActive; }
            set
            {
                if (_dbProviderIsActive == value)
                    return;
                if (value)
                    Parent.SetActive(this);

                _dbProviderIsActive = value;
                OnPropertyChanged("DBProviderIsActive");
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            Parent.Dirty = true;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}