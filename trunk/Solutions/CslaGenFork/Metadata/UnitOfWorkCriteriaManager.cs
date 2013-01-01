using System.Collections.Generic;
using System.Linq;
using CslaGenerator.CodeGen;

namespace CslaGenerator.Metadata
{
    public class UnitOfWorkCriteriaManager
    {
        private static List<CriteriaCollection> _buffer;
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

        /// <summary>
        /// Filters and merges the unit of work criteria collection.
        /// Collection is filtered according to the type of criteria and type of the Unit of Work Type under processing.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns>
        /// A single filtered collection of critera.
        /// </returns>
        public static List<CriteriaCollection> GetAllCriteria(CslaObjectInfo info)
        {
            if (info.IsUpdater)
                return null;

            var mergeTypes = new List<CriteriaMergeType>();
            if (info.UnitOfWorkType == UnitOfWorkFunction.Creator ||
                info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter)
                mergeTypes.Add(CriteriaMergeType.Create);

            if (info.UnitOfWorkType == UnitOfWorkFunction.Getter ||
                info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter)
                mergeTypes.Add(CriteriaMergeType.Get);

            if (info.UnitOfWorkType == UnitOfWorkFunction.Deleter)
                mergeTypes.Add(CriteriaMergeType.Delete);

            var result = new List<CriteriaCollection>();

            foreach (var mergeType in mergeTypes)
            {
                _buffer = new List<CriteriaCollection>();
                foreach (var prop in info.UnitOfWorkProperties)
                {
                    _criteriaCache = new List<Criteria>();
                    var targetInfo = info.Parent.CslaObjects.Find(prop.TypeName);
                    var index = 0;
                    foreach (var crit in targetInfo.CriteriaObjects)
                    {
                        if (mergeType.HasFlag(CriteriaMergeType.Create) && crit.IsCreator)
                        {
                            var newCriteria = Criteria.Clone(crit);
                            if (info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter)
                            {
                                index++;
                                newCriteria.GetOptions.Disable();
                                newCriteria.DeleteOptions.Disable();
                                if (newCriteria.Properties.Count == 0)
                                    newCriteria.Properties.AddRange(GetFakeCreateCriteria(targetInfo, index));
                            }
                            _criteriaCache.Add(newCriteria);
                        }
                        else if (mergeType.HasFlag(CriteriaMergeType.Create) && crit.IsGetter && !prop.CreatesObject)
                            _criteriaCache.Add(Criteria.Clone(crit));
                        else if (mergeType.HasFlag(CriteriaMergeType.Get) && crit.IsGetter)
                        {
                            var newCriteria = Criteria.Clone(crit);
                            if (info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter && prop.CreatesObject)
                            {
                                newCriteria.CreateOptions.Disable();
                                newCriteria.DeleteOptions.Disable();
                                foreach (var property in newCriteria.Properties)
                                {
                                    property.UnitOfWorkFactoryParameter = "false";
                                }
                            }
                            _criteriaCache.Add(newCriteria);
                        }
                        else if (mergeType.HasFlag(CriteriaMergeType.Delete) && crit.IsDeleter)
                            _criteriaCache.Add(Criteria.Clone(crit));
                    }
                    if (_criteriaCache.Count == 0)
                        continue;

                    PrepareCriteriaList();
                    AssignCriteria();
                }
                result.AddRange(_buffer);
            }

            return result;
        }

        private static CriteriaPropertyCollection GetFakeCreateCriteria(CslaObjectInfo info, int createIndex)
        {
            var result = new CriteriaPropertyCollection();
            var index = 0;
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.IsGetter && !crit.IsCreator)
                {
                    index++;
                    if (index == createIndex)
                    {
                        var criteriaPropertyCollection = CriteriaPropertyCollection.Clone(crit.Properties);
                        foreach (var criteriaProperty in criteriaPropertyCollection)
                        {
                            criteriaProperty.UnitOfWorkFactoryParameter = "true, " +
                                CslaTemplateHelperCS.GetDataTypeInitExpression(criteriaProperty, criteriaProperty.PropertyType);
                        }
                        result.AddRange(criteriaPropertyCollection);
                        break;
                    }
                }
            }
            return result;
        }

        private static void PrepareCriteriaList()
        {
            if (_buffer.Count == 0)
            {
                for (var crit = 0; crit < _criteriaCache.Count; crit++)
                {
                    _buffer.Add(new CriteriaCollection());
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
                        newCriteriaCollectionList.AddRange(_buffer.Select(Clone));
                    }
                    _buffer.AddRange(newCriteriaCollectionList);
                }
            }
        }

        private static void AssignCriteria()
        {
            var limit = _buffer.Count/_criteriaCache.Count;
            for (var crit = 0; crit < _criteriaCache.Count; crit++)
            {
                var index = (crit*limit);
                for (var round = 0; round < limit; round++)
                {
                    _buffer[index + round].Add(_criteriaCache[crit]);
                }
            }
        }

        #endregion

        #region Output criteria methods

        public class ElementCriteria
        {
            private string _type = string.Empty;
            private string _name = string.Empty;
            private string _namespace = string.Empty;
            private string _parameter = string.Empty;

            public string Type
            {
                get { return _type; }
                internal set { _type = value; }
            }

            public string Name
            {
                get { return _name; }
                internal set { _name = value; }
            }

            public string Namespace
            {
                get { return _namespace; }
                internal set { _namespace = value; }
            }

            public string Parameter
            {
                get { return _parameter; }
                internal set { _parameter = value; }
            }

            public string ParentObject { get; internal set; }
            public PropertyDeclaration DeclarationMode { get; internal set; }
            public bool IsGetter { get; internal set; }
        }

        public class UoWCriteria
        {
            private List<ElementCriteria> _elementCriteriaList = new List<ElementCriteria>();

            public string CriteriaName { get; internal set; }

            public List<ElementCriteria> ElementCriteriaList
            {
                get { return _elementCriteriaList; }
                internal set { _elementCriteriaList = value; }
            }
        }

        public static List<UoWCriteria> CriteriaOutputForm(CslaObjectInfo info, UnitOfWorkFunction function)
        {
            return CriteriaOutputForm(info, function, false);
        }

        public static List<UoWCriteria> CriteriaOutputForm(CslaObjectInfo info, UnitOfWorkFunction function, bool generatingCriteria)
        {
            var result = new List<UoWCriteria>();

            var propertyDeclarationCache = new Dictionary<string, PropertyDeclaration>();
            foreach (var uowProperty in info.UnitOfWorkProperties)
            {
                propertyDeclarationCache[uowProperty.TypeName] = uowProperty.DeclarationMode;
            }

            var criteriaCollectionCounter = 0;
            foreach (var criteriaCollection in info.UnitOfWorkCriteriaObjects)
            {
                var creatorCounter = criteriaCollection.Count(crit => crit.IsCreator);

                if (function == UnitOfWorkFunction.Creator)
                {
                    if (creatorCounter == 0)
                        continue;
                }
                else if (function == UnitOfWorkFunction.Getter)
                {
                    if (creatorCounter != 0)
                        continue;
                }

                var uowCriteria = new UoWCriteria();
                criteriaCollectionCounter++;

                foreach (var crit in criteriaCollection)
                {
                    if (function == UnitOfWorkFunction.Creator && (!crit.IsCreator && (crit.IsGetter &&
                        CslaTemplateHelperCS.IsEditableType(crit.ParentObject.ObjectType))))
                        break;
                    if (function == UnitOfWorkFunction.Getter && !crit.IsGetter)
                        break;
                    if (function == UnitOfWorkFunction.Deleter && !crit.IsDeleter)
                        break;

                    var elementCriteria = new ElementCriteria();
                    elementCriteria.ParentObject = crit.ParentObject.ObjectName;
                    elementCriteria.DeclarationMode = propertyDeclarationCache[elementCriteria.ParentObject];
                    elementCriteria.IsGetter = !CslaTemplateHelperCS.IsEditableType(crit.ParentObject.ObjectType);
                    if (crit.Properties.Count == 0)
                    {
                        uowCriteria.ElementCriteriaList.Add(elementCriteria);
                    }
                    else
                    {
                        elementCriteria.Name = crit.Name;
                        elementCriteria.Namespace = GetElementCriteriaNamesapce(crit);
                        elementCriteria.Type = crit.Name;
                        if (crit.Properties.Count == 1)
                        {
                            elementCriteria.Name = crit.Properties[0].Name;
                            elementCriteria.Type =
                                CslaTemplateHelperCS.GetDataTypeGeneric(crit.Properties[0], crit.Properties[0].PropertyType);
                        }
                        if (generatingCriteria)
                        {
                            var newElementCriteria = new ElementCriteria();
                            foreach (var prop in crit.Properties.Where(prop => !string.IsNullOrEmpty(prop.UnitOfWorkFactoryParameter)))
                            {
                                newElementCriteria.ParentObject = elementCriteria.Parameter;
                                newElementCriteria.DeclarationMode = elementCriteria.DeclarationMode;
                                newElementCriteria.IsGetter = elementCriteria.IsGetter;
                                newElementCriteria.Namespace = elementCriteria.Namespace;
                                newElementCriteria.Type = "bool";
                                newElementCriteria.Name = "Create" + elementCriteria.ParentObject;
                            }
                            uowCriteria.ElementCriteriaList.Add(newElementCriteria);
                        }
                        else
                        {
                            foreach (var prop in crit.Properties.Where(prop => !string.IsNullOrEmpty(prop.UnitOfWorkFactoryParameter)))
                            {
                                if (!string.IsNullOrEmpty(elementCriteria.Parameter))
                                    elementCriteria.Parameter += ", ";
                                elementCriteria.Parameter += prop.UnitOfWorkFactoryParameter;
                            }
                        }
                        uowCriteria.ElementCriteriaList.Add(elementCriteria);
                    }
                }
                var elementCriteriaListCount = uowCriteria.ElementCriteriaList.Count(elementCriteria => !string.IsNullOrEmpty(elementCriteria.Name));
                if ((generatingCriteria && elementCriteriaListCount > 1) ||
                    (!generatingCriteria && elementCriteriaListCount > 0))
                    uowCriteria.CriteriaName = GetNumberedCriteria(info.UnitOfWorkCriteriaObjects.Count, criteriaCollectionCounter);
                else
                    criteriaCollectionCounter--;

                if (uowCriteria.ElementCriteriaList.Count > 0)
                    result.Add(uowCriteria);
            }

            return result;
        }

        private static string GetElementCriteriaNamesapce(Criteria crit)
        {
            var result = crit.ParentObject.ObjectNamespace;
            if (crit.NestedClass)
                result += "." + crit.ParentObject.ObjectName;

            return result;
        }

        private static string GetNumberedCriteria(int total, int number)
        {
            var format = "0";
            if (total > 9)
                format += "#";
            return "Criteria" + number.ToString(format);
        }

        #endregion
    }
}
