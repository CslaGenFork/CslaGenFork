using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.Controls;
using CslaGenerator.Design;
using DBSchemaInfo.Base;

namespace CslaGenerator.Metadata
{
    public enum ObjectRelationType
    {
        OneToMultiple,
        MultipleToMultiple
    }

    /// <summary>
    /// Summary description for AssociativeEntity.
    /// </summary>
    [Serializable]
    [DefaultProperty("ObjectName")]
    public class AssociativeEntity : CslaGeneratorComponent, INotifyPropertyChanged
    {
        #region Private Fields

        private CslaObjectInfoCollection _cslaObjects;
        private string _mainObject;
        private string _objectName = "AssociativeEntity";
        private ObjectRelationType _relationType;
        private string _secondaryObject;
        private string _validationError;

        #endregion

        #region Constructors

        public AssociativeEntity(CslaGeneratorUnit parent)
            : base(parent)
        {
            MainLazyLoad = true;
            SecondaryLazyLoad = true;
            MainLoadingScheme = LoadingScheme.ParentLoad;
            SecondaryLoadingScheme = LoadingScheme.ParentLoad;

            if (parent != null && parent.Params != null)
            {
                Parent = parent;
                _cslaObjects = Parent.CslaObjects;
            }
        }

        public AssociativeEntity()
            : this(null)
        {
        }

        #endregion

        #region Properties

        [Category("01. Relation")]
        [Description("Relation type for this relation.")]
        [UserFriendlyName("Relation Type")]
        public ObjectRelationType RelationType
        {
            get { return _relationType; }
            set
            {
                if (_relationType != value)
                {
                    _relationType = value;
                    if (value == ObjectRelationType.OneToMultiple)
                    {
                        SecondaryObject = string.Empty;
                        SecondaryPropertyName = string.Empty;
                        SecondaryCollectionTypeName = string.Empty;
                        SecondaryItemTypeName = string.Empty;
                        SecondaryLoadParameters.Clear();
                    }
                    OnPropertyChanged("RelationType");
                }
            }
        }

        [Category("01. Relation")]
        [Description("Relation name. This is just a label for user reference and isn't used by CslaGenFork in any way.")]
        [UserFriendlyName("Object Name")]
        public string ObjectName
        {
            get { return _objectName; }
            set
            {
                if (_objectName != value)
                {
                    value = value.Trim().Replace("  ", " ");
                    if (!string.IsNullOrEmpty(value))
                    {
                        _objectName = value;
                        OnPropertyChanged("ObjectName");
                    }
                }
            }
        }

        [Category("02. Primary Entity Definition")]
        [Description("Type name of the primary entity. This must be a root object (editable or read only).")]
        [Editor(typeof(AssociativeEntityTypeEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Primary Object")]
        public string MainObject
        {
            get { return _mainObject; }
            set
            {
                if (_mainObject != value)
                {
                    _mainObject = value;
                    //AutoFillPrimary();
                    if (string.IsNullOrEmpty(value))
                    {
                        MainPropertyName = string.Empty;
                        MainCollectionTypeName = string.Empty;
                        MainItemTypeName = string.Empty;
                        MainLoadParameters.Clear();
                        SecondaryCollectionTypeName = string.Empty;
                        SecondaryItemTypeName = string.Empty;
                    }
                }
            }
        }

        [Category("02. Primary Entity Definition")]
        [Description("The name of the primary entity's property for the child collection.")]
        [UserFriendlyName("Primary Property Name")]
        public string MainPropertyName { get; set; }

        [Category("02. Primary Entity Definition")]
        [Description("The child collection's Type name.")]
        [Editor(typeof(AssociativeEntityTypeEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Primary Collection Type Name")]
        public string MainCollectionTypeName { get; set; }

        [Category("02. Primary Entity Definition")]
        [Description("The item's Type name for the child collection.")]
        [Editor(typeof(AssociativeEntityTypeEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Primary Item Type Name")]
        public string MainItemTypeName { get; set; }

        [Category("03. Primary Entity Options")]
        [Description("The primary entity's properties which are used in Update method, as parameters for Stored Procedures, etc. " +
            "These will used as Criteria properties in the item object.")]
        [Editor(typeof(AssociativeEntityParameterCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ParameterCollectionConverter))]
        [UserFriendlyName("Primary Load Parameters")]
        public ParameterCollection MainLoadParameters { get; set; }

        [Category("03. Primary Entity Options")]
        [Description("The Loading Scheme for the collection." +
        "If set to ParentLoad then the child will be populated by the parent class.\r\n" +
        "If set to SelfLoad the child will load its own data.\r\n" +
        "If set to None then the child will not be populated with data at all (unsupported for CSLA40 targets).")]
        [UserFriendlyName("Primary Loading Scheme")]
        public LoadingScheme MainLoadingScheme { get; set; }

        [Category("03. Primary Entity Options")]
        [Description("Whether or not this object should be lazy loaded. This applies to SelfLoad mode.\r\n" +
            "If set to True, loading of child data is defered until the child object is referenced.\r\n" +
            "If set to False, the child data is loaded when the parent is instantiated.")]
        [UserFriendlyName("Primary Lazy Load")]
        public bool MainLazyLoad { get; set; }

        [Category("04. Secondary Entity Definition")]
        [Description("Type name of the secondary entity. This must be a root object (editable or read only). This ")]
        [Editor(typeof(AssociativeEntityTypeEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Secondary Object")]
        public string SecondaryObject
        {
            get { return _secondaryObject; }
            set
            {
                if (_secondaryObject != value)
                {
                    _secondaryObject = value;
                    if (string.IsNullOrEmpty(value))
                    {
                        SecondaryPropertyName = string.Empty;
                        SecondaryCollectionTypeName = string.Empty;
                        SecondaryItemTypeName = string.Empty;
                        SecondaryLoadParameters.Clear();
                        if (RelationType == ObjectRelationType.MultipleToMultiple)
                        {
                            MainCollectionTypeName = string.Empty;
                            MainItemTypeName = string.Empty;
                        }
                    }
                }
            }
        }

        [Category("04. Secondary Entity Definition")]
        [Description("The name of the secondary entity's property for the child collection.")]
        [UserFriendlyName("Secondary Property Name")]
        public string SecondaryPropertyName { get; set; }

        [Category("04. Secondary Entity Definition")]
        [Description("The child collection's Type name.")]
        [Editor(typeof(AssociativeEntityTypeEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Secondary Collection Type Name")]
        public string SecondaryCollectionTypeName { get; set; }

        [Category("04. Secondary Entity Definition")]
        [Description("The item's Type name for the child collection.")]
        [Editor(typeof(AssociativeEntityTypeEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Secondary Item Type Name")]
        public string SecondaryItemTypeName { get; set; }

        [Category("05. Secondary Entity Options")]
        [Description("The secondary entity's properties which are used in Update method, as parameters for " +
            "Stored Procedures. These will used as Criteria properties in the item object.")]
        [Editor(typeof(AssociativeEntityParameterCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ParameterCollectionConverter))]
        [UserFriendlyName("Secondary Load Parameters")]
        public ParameterCollection SecondaryLoadParameters { get; set; }

        [Category("05. Secondary Entity Options")]
        [Description("The Loading Scheme for the collection." +
        "If set to ParentLoad then the child will be populated by the parent class.\r\n" +
        "If set to SelfLoad the child will load its own data.\r\n" +
        "If set to None then the child will not be populated with data at all (unsupported for CSLA40 targets).")]
        [UserFriendlyName("Secondary Loading Scheme")]
        public LoadingScheme SecondaryLoadingScheme { get; set; }

        [Category("05. Secondary Entity Options")]
        [Description("Whether or not this object should be lazy loaded. This applies to SelfLoad mode.\r\n" +
            "If set to True, loading of child data is defered until the child object is referenced.\r\n" +
            "If set to False, the child data is loaded when the parent is instantiated.")]
        [UserFriendlyName("Secondary Lazy Load")]
        public bool SecondaryLazyLoad { get; set; }

        #endregion

        #region Public methods

        public AssociativeEntity Duplicate(ICatalog catalog)
        {
            var buffer = new MemoryStream();
            var ser = new XmlSerializer(typeof(AssociativeEntity));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            var duplicate = (AssociativeEntity)ser.Deserialize(buffer);
            return duplicate;
        }

        #endregion

        #region Validation methods

        public string Validate()
        {
            if (_cslaObjects == null)
                _cslaObjects = Parent.CslaObjects;

            _validationError = string.Empty;

            if (RelationType == ObjectRelationType.OneToMultiple)
                ValidOneToMultiple();
            else
                ValidMultipleToMultiple();

            return _validationError;
        }

        public void Build()
        {
            if (string.IsNullOrEmpty(_validationError))
            {
                // display start up message to the user
                var sb = new StringBuilder();
                sb.AppendFormat("Starting the build of {0} relation.\r\n", ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());

                if (RelationType == ObjectRelationType.OneToMultiple)
                {
                    var factory = new ObjectRelationsFactory(Parent, this);

                    factory.FacadeObjectInfo = factory.MainObjectInfo;
                    factory.FacadeRootCriteriaProperties = factory.MainRootCriteriaProperties;
                    factory.BuildRelationObjects(new EntityFacade(Parent, RelationType, MainObject,
                                                                  MainPropertyName, MainCollectionTypeName,
                                                                  MainItemTypeName, MainLazyLoad,
                                                                  MainLoadingScheme, MainLoadParameters));
                    factory.PopulateRelationObjects(MainItemTypeName, factory.MainRootCriteriaProperties);
                }
                else
                {
                    var factory = new ObjectRelationsFactory(Parent, this);

                    factory.FacadeObjectInfo = factory.MainObjectInfo;
                    factory.FacadeRootCriteriaProperties = factory.MainRootCriteriaProperties;
                    factory.BuildRelationObjects(new EntityFacade(Parent, RelationType, MainObject,
                                                                  MainPropertyName, MainCollectionTypeName,
                                                                  MainItemTypeName, MainLazyLoad,
                                                                  MainLoadingScheme, MainLoadParameters));

                    factory.FacadeObjectInfo = factory.SecondaryObjectInfo;
                    factory.FacadeRootCriteriaProperties = factory.SecondaryRootCriteriaProperties;
                    factory.BuildRelationObjects(new EntityFacade(Parent, RelationType, SecondaryObject,
                                                                  SecondaryPropertyName, SecondaryCollectionTypeName,
                                                                  SecondaryItemTypeName, SecondaryLazyLoad,
                                                                  SecondaryLoadingScheme, SecondaryLoadParameters));

                    factory.PopulateRelationObjects(MainItemTypeName, factory.MainRootCriteriaProperties);
                    factory.PopulateRelationObjects(SecondaryItemTypeName, factory.SecondaryRootCriteriaProperties);
                }

                // display start up message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Relation build end.\r\n");
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }
        }

        private void ValidOneToMultiple()
        {
            var mainCslaObject = _cslaObjects.Find(MainObject);
            var mainCslaObjectCollection = _cslaObjects.Find(MainCollectionTypeName);
            var mainCslaObjectItem = _cslaObjects.Find(MainItemTypeName);

            if (mainCslaObject == null)
                _validationError += "Primary Object not found." + Environment.NewLine;
            else if (!RelationRulesEngine.IsAllowedEntityObject(mainCslaObject))
                _validationError += MainObject + " isn't allowed to be Primary Object." + Environment.NewLine;

            if (mainCslaObjectCollection == null)
            {
                if (string.IsNullOrEmpty(MainCollectionTypeName))
                    _validationError += "Primary Collection must be filled." + Environment.NewLine;
                else
                {
                    if (RelationType == ObjectRelationType.OneToMultiple)
                        _validationError += "Primary Collection not found." + Environment.NewLine;
                }
            }
            else if (!RelationRulesEngine.IsAllowedEntityCollection(mainCslaObjectCollection))
                _validationError += MainCollectionTypeName + " isn't allowed to be Primary Collection." +
                                    Environment.NewLine;

            if (mainCslaObjectItem == null)
            {
                if (string.IsNullOrEmpty(MainItemTypeName))
                    _validationError += "Primary Collection Item must be filled." + Environment.NewLine;
                else
                {
                    if (RelationType == ObjectRelationType.OneToMultiple)
                        _validationError += "Primary Collection Item not found." + Environment.NewLine;
                }
            }
            else if (!RelationRulesEngine.IsAllowedEntityCollectionItem(mainCslaObjectItem))
                _validationError += MainItemTypeName + " isn't allowed to be Primary Collection Item." +
                                    Environment.NewLine;

            if (mainCslaObjectCollection != null && mainCslaObjectItem != null)
            {
                if (
                    !RelationRulesEngine.IsCompatibleEntityCollectionItemPair(mainCslaObjectCollection,
                                                                              mainCslaObjectItem))
                    _validationError += MainCollectionTypeName + " Collection is not compatible with " +
                                        MainItemTypeName + " Collection Item." + Environment.NewLine;

                if (!IsChildCorrect(_cslaObjects, MainObject, MainCollectionTypeName))
                    _validationError += MainObject + " must be the parent of " + MainCollectionTypeName + "." +
                                        Environment.NewLine;

                if (!IsChildCorrect(_cslaObjects, MainCollectionTypeName, MainItemTypeName))
                    _validationError += MainCollectionTypeName + " must be the parent of " + MainItemTypeName + "." +
                                        Environment.NewLine;

                if (!IsItemCorrect(_cslaObjects, MainCollectionTypeName, MainItemTypeName))
                    _validationError += MainCollectionTypeName + " item must be " + MainItemTypeName +
                                        "." + Environment.NewLine;
            }
        }

        private void ValidMultipleToMultiple()
        {
            ValidOneToMultiple();

            var secondaryCslaObject = _cslaObjects.Find(SecondaryObject);
            var secondaryCslaObjectCollection = _cslaObjects.Find(SecondaryCollectionTypeName);
            var secondaryCslaObjectItem = _cslaObjects.Find(SecondaryItemTypeName);

            if (secondaryCslaObject == null)
                _validationError += "Secondary Object not found." + Environment.NewLine;
            else if (!RelationRulesEngine.IsAllowedEntityObject(secondaryCslaObject))
                _validationError += SecondaryObject + " isn't allowed to be Secondary Object." + Environment.NewLine;

            if (secondaryCslaObjectCollection == null)
            {
                if (string.IsNullOrEmpty(SecondaryCollectionTypeName))
                    _validationError += "Secondary Collection must be filled." + Environment.NewLine;
            }
            else if (!RelationRulesEngine.IsAllowedEntityCollection(secondaryCslaObjectCollection))
                _validationError += SecondaryCollectionTypeName + " isn't allowed to be Secondary Collection." +
                                    Environment.NewLine;

            if (secondaryCslaObjectItem == null)
            {
                if (string.IsNullOrEmpty(SecondaryItemTypeName))
                    _validationError += "Secondary Collection Item must be filled." + Environment.NewLine;
            }
            else if (!RelationRulesEngine.IsAllowedEntityCollectionItem(secondaryCslaObjectItem))
                _validationError += SecondaryItemTypeName + " isn't allowed to be Secondary Collection Item." +
                                    Environment.NewLine;

            if (secondaryCslaObjectCollection != null && secondaryCslaObjectItem != null)
            {
                if (
                    !RelationRulesEngine.IsCompatibleEntityCollectionItemPair(secondaryCslaObjectCollection,
                                                                              secondaryCslaObjectItem))
                    _validationError += SecondaryCollectionTypeName + " Collection is not compatible with " +
                                        SecondaryItemTypeName + " Collection Item." + Environment.NewLine;

                if (!IsChildCorrect(_cslaObjects, SecondaryObject, SecondaryCollectionTypeName))
                    _validationError += SecondaryObject + " must be the parent of " + SecondaryCollectionTypeName + "." +
                                        Environment.NewLine;

                if (!IsChildCorrect(_cslaObjects, SecondaryCollectionTypeName, SecondaryItemTypeName))
                    _validationError += SecondaryCollectionTypeName + " must be the parent of " + SecondaryItemTypeName +
                                        "." + Environment.NewLine;

                if (!IsItemCorrect(_cslaObjects, SecondaryCollectionTypeName, SecondaryItemTypeName))
                    _validationError += SecondaryCollectionTypeName + " item must be " + SecondaryItemTypeName +
                                        "." + Environment.NewLine;
            }

            var mainCslaObject = _cslaObjects.Find(MainObject);
            if (ObjectRelationsFactory.FindAssociativeTable(mainCslaObject, secondaryCslaObject) == null)
                _validationError += "Associative table not found.";
        }

        public static bool IsChildCorrect(CslaObjectInfoCollection cslaObjects, string parentName, string childName)
        {
            var childCandidate = cslaObjects.Find(childName);
            if (parentName == childCandidate.ParentType)
                return true;

            return false;
        }

        public static bool IsItemCorrect(CslaObjectInfoCollection cslaObjects, string collectionName, string itemName)
        {
            var collectionCandidate = cslaObjects.Find(collectionName);
            if (itemName == collectionCandidate.ItemType)
                return true;

            return false;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Events

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public class EntityFacade : CslaGeneratorComponent
        {
            public ObjectRelationType RelationType;
            public string ObjectName;
            public string PropertyName;
            public string CollectionTypeName;
            public string ItemTypeName;
            public bool LazyLoad = true;
            public LoadingScheme LoadingScheme;
            public ParameterCollection LoadParameters;

            #region Constructors

            public EntityFacade(CslaGeneratorUnit parent)
                : base(parent)
            {
                if (parent != null && parent.Params != null)
                {
                    Parent = parent;
                }
            }

            public EntityFacade()
                : this(null)
            {
            }

            public EntityFacade(CslaGeneratorUnit parent, ObjectRelationType relationType, string objectName, string propertyName, string collectionTypeName, string itemTypeName, bool lazyLoad, LoadingScheme loadingScheme, ParameterCollection loadParameters)
                : base(parent)
            {
                RelationType = relationType;
                ObjectName = objectName;
                PropertyName = propertyName;
                CollectionTypeName = collectionTypeName;
                ItemTypeName = itemTypeName;
                LazyLoad = lazyLoad;
                LoadingScheme = loadingScheme;
                LoadParameters = loadParameters;

                if (parent != null && parent.Params != null)
                {
                    Parent = parent;
                }
            }

            #endregion
        }
    }
}