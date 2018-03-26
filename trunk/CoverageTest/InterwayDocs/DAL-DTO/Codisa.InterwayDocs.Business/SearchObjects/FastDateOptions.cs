using System;
using Codisa.InterwayDocs.Business.Properties;
using Csla.Core;

namespace Codisa.InterwayDocs.Business.SearchObjects
{
    [Serializable]
    public class FastDateOptions
    {
        private readonly MobileDictionary<string, string> _optionsDictionary =
            new MobileDictionary<string, string>();

        public MobileDictionary<string, string> GetDictionary()
        {
            if (_optionsDictionary.Count == 0)
                LoadDictionary();

            return _optionsDictionary;
        }

        public void RefreshDictionary()
        {
            _optionsDictionary.Clear();
        }

        private void LoadDictionary()
        {
            _optionsDictionary.Add("Today", Resources.FastDateOptionsToday);
            _optionsDictionary.Add("Yesterday", Resources.FastDateOptionsYesterday);
            _optionsDictionary.Add("Last7Days", Resources.FastDateOptionsLast7Days);
            _optionsDictionary.Add("Last15Days", Resources.FastDateOptionsLast15Days);
            _optionsDictionary.Add("Last30Days", Resources.FastDateOptionsLast30Days);
            _optionsDictionary.Add("Last90Days", Resources.FastDateOptionsLast90Days);
            _optionsDictionary.Add("FreeSearch", Resources.FastDateOptionsFreeSearch);
        }

        public int GetIndex(string key)
        {
            var result = 0;
            foreach (var valuePair in GetDictionary())
            {
                if (valuePair.Key == key)
                    break;

                result++;
            }

            return result;
        }
    }
}