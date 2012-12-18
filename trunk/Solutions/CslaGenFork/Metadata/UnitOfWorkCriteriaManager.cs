using System.Collections.Generic;
using System.Linq;
using CslaGenerator.CodeGen;

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

        #region Fetch criteria methods

        internal static List<CriteriaCollection> GetAllCriteria(CslaObjectInfo info)
        {
            if (info.IsUpdater)
                return null;

            var mergeType = CriteriaMergeType.None;
            if (info.UnitOfWorkType == UnitOfWorkFunction.Creator || info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter)
                mergeType |= CriteriaMergeType.Create;
            if (info.UnitOfWorkType == UnitOfWorkFunction.Getter || info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter)
                mergeType |= CriteriaMergeType.Get;
            if (info.UnitOfWorkType == UnitOfWorkFunction.Deleter)
                mergeType |= CriteriaMergeType.Delete;

            _result = new List<CriteriaCollection>();
            foreach (var prop in info.UnitOfWorkProperties)
            {
                _criteriaCache = new List<Criteria>();
                var targetInfo = info.Parent.CslaObjects.Find(prop.TypeName);
                foreach (var crit in targetInfo.CriteriaObjects)
                {
                    if (mergeType.HasFlag(CriteriaMergeType.Create) && crit.IsCreator && prop.ObjectCreator)
                        _criteriaCache.Add(crit);
                    else if (mergeType.HasFlag(CriteriaMergeType.Create) && crit.IsGetter && !prop.ObjectCreator)
                        _criteriaCache.Add(crit);
                    else if (mergeType.HasFlag(CriteriaMergeType.Get) && crit.IsGetter)
                        _criteriaCache.Add(crit);
                    else if (mergeType.HasFlag(CriteriaMergeType.Delete) && crit.IsDeleter)
                        _criteriaCache.Add(crit);
                }
                if (_criteriaCache.Count == 0)
                    continue;

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
                var index = (crit*limit);
                for (var round = 0; round < limit; round++)
                {
                    _result[index + round].Add(_criteriaCache[crit]);
                }
            }
        }

        #endregion

        #region Use criteria methods

        internal static List<string> Bachibouzouk()
        {
            var result = new List<string>();


            return result;
        }

        #endregion
    }
}
