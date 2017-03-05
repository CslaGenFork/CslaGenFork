using System;
using System.ComponentModel;
using System.Linq;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for GenerationDbProviderCollection.
    /// </summary>
    [Serializable]
    public class GenerationDbProviderCollection : BindingList<GenerationDbProvider>
    {
        [Browsable(false)]
        internal bool Dirty { get; set; }

        protected override object AddNewCore()
        {
            Dirty = true;
            return base.AddNewCore();
        }

        protected override void RemoveItem(int index)
        {
            Dirty = true;
            base.RemoveItem(index);
        }

        internal GenerationDbProvider GetActive()
        {
            if (!GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
            {
                foreach (var provider in this)
                {
                    if (provider.DBProviderIsActive)
                        return provider;
                }
            }
            return null;
        }

        internal int GetActiveCount()
        {
            return this.Count(provider => provider.DBProviderIsActive);
        }

        internal void SetActive(GenerationDbProvider dbProvider)
        {
            if (GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
                return;

            foreach (var provider in this)
            {
                if (provider == dbProvider)
                    continue;
                provider.DBProviderIsActive = false;
            }
        }

        public bool Contains(string dBProviderShortName)
        {
            return Find(dBProviderShortName) != null;
        }

        internal bool ContainsNamespace(string dBProviderNamespace)
        {
            return FindNamespace(dBProviderNamespace) != null;
        }

        private GenerationDbProvider Find(string dBProviderShortName)
        {
            return this.FirstOrDefault(dBProvider => dBProvider.DBProviderShortName.Equals(dBProviderShortName));
        }

        private GenerationDbProvider FindNamespace(string dBProviderNamespace)
        {
            return this.FirstOrDefault(dBProvider => dBProvider.NamespaceSuffix.Equals(dBProviderNamespace));
        }
    }
}