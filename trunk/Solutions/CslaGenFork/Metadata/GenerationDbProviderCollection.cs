using System;
using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for GenerationDbProviderCollection.
    /// </summary>
    [Serializable]
    public class GenerationDbProviderCollection : List<GenerationDbProvider>
    {
        private static GenerationDbProviderCollection _instance;

        private GenerationDbProviderCollection()
        {
            // force to use factory method
        }

        internal static GenerationDbProviderCollection GetInstance()
        {
            if (_instance == null)
                _instance = new GenerationDbProviderCollection();

            return _instance;
        }

        internal GenerationDbProvider GetActive()
        {
            if (!GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
            {
                foreach (var provider in _instance)
                {
                    if (provider.DBProviderIsActive)
                        return provider;
                }
            }
            return null;
        }

        internal void SetActive(GenerationDbProvider dbProvider)
        {
            if (GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
                return;

            foreach (var provider in _instance)
            {
                if (provider == dbProvider)
                    continue;
                provider.DBProviderIsActive = false;
            }
        }

        public bool Contains(string dBProviderShortName)
        {
            return _instance.Find(dBProviderShortName) != null;
        }

        internal bool ContainsNamespace(string dBProviderNamespace)
        {
            return _instance.FindNamespace(dBProviderNamespace) != null;
        }

        private GenerationDbProvider Find(string dBProviderShortName)
        {
            return this.FirstOrDefault(property => property.DBProviderShortName.Equals(dBProviderShortName));
        }

        private GenerationDbProvider FindNamespace(string dBProviderNamespace)
        {
            return this.FirstOrDefault(property => property.NamespaceSuffix.Equals(dBProviderNamespace));
        }
    }
}