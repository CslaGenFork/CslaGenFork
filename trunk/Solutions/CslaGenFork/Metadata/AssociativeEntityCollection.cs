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
                entity.RelationType = ObjectRelationType.OneToMany;
                entity.ObjectName = mainObject.ObjectName;
                entity.MainObject = mainObject.ObjectName;
                entity.MainLazyLoad = false;
                entity.SecondaryLazyLoad = false;

                var mainCriteriaInfo = typeof(CslaObjectInfo).GetProperty("CriteriaObjects");
                var mainCriteriaObjects = mainCriteriaInfo.GetValue(mainObject, null);
                foreach (var crit in (CriteriaCollection)mainCriteriaObjects)
                {
                    foreach (var prop in crit.Properties)
                    {
                        entity.MainLoadProperties.Add(CriteriaProperty.Clone(prop));
                    }
                }

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
                    entity.RelationType = ObjectRelationType.ManyToMany;
                    entity.ObjectName = mainObject.ObjectName + secondaryObject.ObjectName;
                    entity.MainLazyLoad = false;
                    entity.SecondaryLazyLoad = false;

                    entity.MainObject = mainObject.ObjectName;
                    entity.MainPropertyName = secondaryObject.ObjectName + entity.Parent.Params.ORBChildPropertySuffix;
                    entity.MainItemTypeName = mainObject.ObjectName + secondaryObject.ObjectName;
                    entity.MainCollectionTypeName = entity.MainItemTypeName + entity.Parent.Params.ORBCollectionSuffix;

                    var mainCriteriaInfo = typeof(CslaObjectInfo).GetProperty("CriteriaObjects");
                    var mainCriteriaObjects = mainCriteriaInfo.GetValue(mainObject, null);
                    foreach (var crit in (CriteriaCollection)mainCriteriaObjects)
                    {
                        foreach (var prop in crit.Properties)
                        {
                            entity.MainLoadProperties.Add(CriteriaProperty.Clone(prop));
                        }
                    }

                    entity.SecondaryObject = secondaryObject.ObjectName;
                    entity.SecondaryPropertyName = mainObject.ObjectName + entity.Parent.Params.ORBChildPropertySuffix;
                    entity.SecondaryItemTypeName = secondaryObject.ObjectName + mainObject.ObjectName;
                    entity.SecondaryCollectionTypeName = entity.SecondaryItemTypeName +
                                                         entity.Parent.Params.ORBCollectionSuffix;

                    var secondaryCriteriaInfo = typeof(CslaObjectInfo).GetProperty("CriteriaObjects");
                    var secondaryCriteriaObjects = secondaryCriteriaInfo.GetValue(secondaryObject, null);
                    foreach (var crit in (CriteriaCollection)secondaryCriteriaObjects)
                    {
                        foreach (var prop in crit.Properties)
                        {
                            entity.SecondaryLoadProperties.Add(CriteriaProperty.Clone(prop));
                        }
                    }

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