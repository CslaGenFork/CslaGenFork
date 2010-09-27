using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CslaGenerator.Metadata
{

    public class AssociativeEntityCollection : BindingList<AssociativeEntity>
    {
        public AssociativeEntity Find(string name)
        {
            foreach (var e in this)
            {
                if (e.ObjectName.Equals(name))
                    return e;
            }
            return null;
        }

        public List<string> GetAllObjectNames()
        {
            var lst = new List<string>();
            foreach (var obj in this)
                lst.Add(obj.ObjectName);
            return lst;
        }

        public void Add(CslaObjectInfo mainObject)
        {
            if (RelationRulesEngine.IsAllowedEntityObject(mainObject))
            {
                var entity = new AssociativeEntity(GeneratorController.Current.CurrentUnit);
                entity.RelationType = ObjectRelationType.OneToMultiple;
                entity.ObjectName = mainObject.ObjectName;
                entity.MainObject = mainObject.ObjectName;
                entity.MainLazyLoad = false;
                entity.SecondaryLazyLoad = false;

                var mainCriteriaInfo = typeof(CslaObjectInfo).GetProperty("CriteriaObjects");
                var mainCriteriaObjects = mainCriteriaInfo.GetValue(mainObject, null);
                var mainParamCollection = new ParameterCollection();
                foreach (var crit in (CriteriaCollection)mainCriteriaObjects)
                {
                    foreach (var prop in crit.Properties)
                    {
                        mainParamCollection.Add(new Parameter(crit, prop));
                    }
                }
                entity.MainLoadParameters = mainParamCollection;

                Add(entity);
            }
            else
            {
                throw new Exception(mainObject + " isn't a suitable object for this builder.");
            }
        }

        public void Add(CslaObjectInfo mainObject, CslaObjectInfo secondaryObject)
        {
            if (RelationRulesEngine.IsAllowedEntityObject(mainObject))
            {
                if (RelationRulesEngine.IsAllowedEntityObject(secondaryObject))
                {
                    var entity = new AssociativeEntity(GeneratorController.Current.CurrentUnit);
                    entity.RelationType = ObjectRelationType.MultipleToMultiple;
                    entity.ObjectName = mainObject.ObjectName + secondaryObject.ObjectName;
                    entity.MainLazyLoad = false;
                    entity.SecondaryLazyLoad = false;

                    entity.MainObject = mainObject.ObjectName;
                    entity.MainPropertyName = secondaryObject.ObjectName + "s";
                    entity.MainItemTypeName = mainObject.ObjectName + secondaryObject.ObjectName;
                    entity.MainCollectionTypeName = entity.MainItemTypeName + "Coll";

                    var mainCriteriaInfo = typeof(CslaObjectInfo).GetProperty("CriteriaObjects");
                    var mainCriteriaObjects = mainCriteriaInfo.GetValue(mainObject, null);
                    var mainParamCollection = new ParameterCollection();
                    foreach (var crit in (CriteriaCollection)mainCriteriaObjects)
                    {
                        foreach (var prop in crit.Properties)
                        {
                            mainParamCollection.Add(new Parameter(crit, prop));
                        }
                    }
                    entity.MainLoadParameters = mainParamCollection;

                    entity.SecondaryObject = secondaryObject.ObjectName;
                    entity.SecondaryPropertyName = mainObject.ObjectName + "s";
                    entity.SecondaryItemTypeName = secondaryObject.ObjectName + mainObject.ObjectName;
                    entity.SecondaryCollectionTypeName = entity.SecondaryItemTypeName + "Coll";

                    var secondaryCriteriaInfo = typeof(CslaObjectInfo).GetProperty("CriteriaObjects");
                    var secondaryCriteriaObjects = secondaryCriteriaInfo.GetValue(secondaryObject, null);
                    var secondaryParamCollection = new ParameterCollection();
                    foreach (var crit in (CriteriaCollection)secondaryCriteriaObjects)
                    {
                        foreach (var prop in crit.Properties)
                        {
                            secondaryParamCollection.Add(new Parameter(crit, prop));
                        }
                    }
                    entity.SecondaryLoadParameters = secondaryParamCollection;

                    Add(entity);
                }
                else
                {
                    throw new Exception(secondaryObject + " isn't a suitable object for this builder.");
                }
            }
            else
            {
                throw new Exception(mainObject + " isn't a suitable object for this builder.");
            }
        }

    }

}
