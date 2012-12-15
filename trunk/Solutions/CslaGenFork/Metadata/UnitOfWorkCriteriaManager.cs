using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class UnitOfWorkCriteriaManager
    {
        private static List<CriteriaCollection> _result;
        private static List<Criteria> _criteriaCache;

        internal static CriteriaCollection Clone(CriteriaCollection criteriaCollection)
        {
            var newCriteriaCollection = new CriteriaCollection();

            foreach (var crit in criteriaCollection)
            {
                newCriteriaCollection.Add(Criteria.Clone(crit));
            }

            return newCriteriaCollection;
        }

        internal static List<CriteriaCollection> GetAllCriteria(CslaObjectInfo info, CriteriaMergeType mergeType)
        {
            if (info.IsUpdater)
                return null;

            _result = new List<CriteriaCollection>();
            foreach (var prop in info.UnitOfWorkProperties)
            {
                _criteriaCache = new List<Criteria>();
                var targetInfo = info.Parent.CslaObjects.Find(prop.TypeName);
                foreach (var crit in targetInfo.CriteriaObjects)
                {
                    if ((mergeType == CriteriaMergeType.Create && !crit.IsCreator) ||
                        (mergeType == CriteriaMergeType.Get && !crit.IsGetter) ||
                        (mergeType == CriteriaMergeType.Delete && !crit.IsDeleter))
                        continue;

                    _criteriaCache.Add(crit);
                }
                PrepareCriteriaList();
                AssignCriteria();
            }
            return _result;
        }

        private static void PrepareCriteriaList()
        {
            if (_result.Count == 0)
            {
                for (var crit = 0; crit < _criteriaCache.Count; crit++)
                {
                    _result.Add(new CriteriaCollection());
                }
            }
            else
            {
                if (_criteriaCache.Count > 1)
                {
                    var newCriteriaCollectionList = new List<CriteriaCollection>();
                    for (var crit = 1; crit < _criteriaCache.Count; crit++)
                    {
                        /*foreach (var criteriaCollection in _result)
                        {
                            newCriteriaCollectionList.Add(Clone(criteriaCollection));
                        }*/
                        /*newCriteriaCollectionList.AddRange(_result.Select(criteriaCollection => Clone(criteriaCollection)));*/
                        newCriteriaCollectionList.AddRange(_result.Select(Clone));
                    }
                    _result.AddRange(newCriteriaCollectionList);
                }
            }
        }

        private static void AssignCriteria()
        {
            var limit = _result.Count/_criteriaCache.Count;
            for (var crit = 0; crit < _criteriaCache.Count; crit++)
            {
                for (var round = 0; round < limit; round++)
                {
                    var index = (crit*limit) + crit + round;
                    if (index >= _result.Count)
                        index -= limit;
                    _result[index].Add(_criteriaCache[crit]);
                }
            }
        }
    }
}
