using System;
using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for GenerationDbProvider.
    /// </summary>
    [Serializable]
    public class GenerationDbProvider : INotifyPropertyChanged
    {
        #region Fields and Properties

        private string _dbProviderShortName;
        private string _namespaceSuffix;
        private bool _dbProviderIsActive;

        private GenerationDbProviderCollection Parent
        {
            get { return GenerationDbProviderCollection.GetInstance(); }
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
            /*if (!string.IsNullOrEmpty(propertyName))
            {
                if (propertyName == "TargetFramework")
                    SetCsla4Options();
                if (propertyName == "GenerateWinForms")
                    SetServerInvocationOptions();
                if (propertyName == "GenerateWPF")
                    SetServerInvocationOptions();
                if (propertyName == "GenerateSilverlight4")
                {
                    if (_generateSilverlight)
                    {
                        _silverlightUsingServices = false;
                    }
                    SetServerInvocationOptions();
                }
                if (propertyName == "SilverlightUsingServices")
                {
                    if (_silverlightUsingServices)
                    {
                        _generateSilverlight = false;
                    }
                    SetServerInvocationOptions();
                }
                if (propertyName == "GenerateSynchronous")
                    SetServerInvocationOptions();
                if (propertyName == "GenerateAsynchronous")
                    SetServerInvocationOptions();
                if (propertyName == "GenerateAuthorization")
                {
                    if (_generateAuthorization == AuthorizationLevel.None ||
                        _generateAuthorization == AuthorizationLevel.Custom)
                        _usesCslaAuthorizationProvider = false;
                }
            }*/

            Dirty = true;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        [Browsable(false)]
        internal bool Dirty { get; set; }

        #endregion

        #region Clone

        internal GenerationDbProvider Clone()
        {
            GenerationDbProvider obj = null;
            try
            {
                obj = (GenerationDbProvider) Util.ObjectCloner.CloneShallow(this);
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