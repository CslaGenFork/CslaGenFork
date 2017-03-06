using System;
using System.ComponentModel;
using System.Linq;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for DbProviderCollection.
    /// </summary>
    [Serializable]
    public class DbProviderCollection : BindingList<DbProvider>
    {
        [Browsable(false)]
        internal bool Dirty { get; set; }

        protected override void InsertItem(int index, DbProvider item)
        {
            Dirty = true;
            base.InsertItem(index, item);
        }

        protected override void ClearItems()
        {
            Dirty = true;
            base.ClearItems();
        }

        public bool Contains(string dBProviderShortName)
        {
            return FindShortName(dBProviderShortName) != null;
        }

        internal bool ContainsName(string dBProviderName)
        {
            return FindName(dBProviderName) != null;
        }

        private DbProvider FindName(string dBProviderName)
        {
            return this.FirstOrDefault(dBProvider => dBProvider.Name.Equals(dBProviderName));
        }

        private DbProvider FindShortName(string dBProviderShortName)
        {
            return this.FirstOrDefault(dBProvider => dBProvider.DbProviderShortName.Equals(dBProviderShortName));
        }
    }
}