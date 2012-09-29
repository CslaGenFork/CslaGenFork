using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.CodeGen;
using CslaGenerator.Design;
using CslaGenerator.Util;
using DBSchemaInfo.Base;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for MetaCslaObject.
    /// </summary>
    [Serializable]
    [DefaultProperty("ObjectName")]
    public class CslaObjectInfo : CslaGeneratorComponent, INotifyPropertyChanged
    {

        #region Private Fields

        private string _objectName = "CslaObject";
        private string _objectNamespace = String.Empty;
        private bool _generate = true;
        private CodeLanguage _outputLanguage = CodeLanguage.CSharp;
        private TransactionType _transactionType = TransactionType.None;
        private PersistenceType _persistenceType = PersistenceType.SqlConnectionManager;
        private string _dbContextObject = string.Empty;
        private string _commandTimeout = string.Empty;
        private CslaObjectType _objectType = CslaObjectType.EditableRoot;
        private UnitOfWorkFunction _unitOfWorkType;
        private ConstructorVisibility _constructorVisibility = ConstructorVisibility.Default;
        private TypeInfo _inheritedType;
        private TypeInfo _inheritedTypeWinForms;
        private readonly ValuePropertyCollection _valueProperties = new ValuePropertyCollection();
        private readonly ChildPropertyCollection _childProperties = new ChildPropertyCollection();
        private readonly ChildPropertyCollection _childCollectionProperties = new ChildPropertyCollection();
        private readonly UnitOfWorkPropertyCollection _unitOfWorkProperties = new UnitOfWorkPropertyCollection();
        private readonly ConvertValuePropertyCollection _convertValueProperties = new ConvertValuePropertyCollection();
        private readonly UpdateValuePropertyCollection _updateValueProperties = new UpdateValuePropertyCollection();
        private readonly ValuePropertyCollection _inheritedValueProperties = new ValuePropertyCollection();
        private readonly ChildPropertyCollection _inheritedChildProperties = new ChildPropertyCollection();
        private readonly ChildPropertyCollection _inheritedChildCollectionProperties = new ChildPropertyCollection();
        private readonly CriteriaCollection _criteriaObjects = new CriteriaCollection();
        private CriteriaCollection _myCriteriaObjects = new CriteriaCollection();
        private PropertyCollection _equalsProperty = new PropertyCollection();
        private PropertyCollection _hashcodeProperty = new PropertyCollection();
        private PropertyCollection _toStringProperty = new PropertyCollection();
        private PropertyCollection _findMethodsParameters = new PropertyCollection();
        private bool _insertUpdateRunLocal;
        private string _selectProcedureName = String.Empty;
        private string _insertProcedureName = String.Empty;
        private string _updateProcedureName = String.Empty;
        private string _deleteProcedureName = String.Empty;
        private bool _deleteUseTimestamp = false;
        private bool _removeItem = true;
        private string _dbName = String.Empty;
        private string _itemType = String.Empty;
        private bool _containsItem = true;
        private string _updaterType = String.Empty;
        private string _parentType = String.Empty;
        private string _fileName = String.Empty;
        private string _nameColumn = String.Empty;
        private string _valueColumn = String.Empty;
        private bool _lazyLoad;
        private bool _generateSprocs = true;
        private PropertyCollection _parentProperties = new PropertyCollection();
        private BusinessRuleCollection _businessRules = new BusinessRuleCollection();
        private AuthorizationProvider _authzProvider;
        private AuthorizationRule _getAuthzRuleType = new AuthorizationRule();
        private AuthorizationRule _newAuthzRuleType = new AuthorizationRule();
        private AuthorizationRule _updateAuthzRuleType = new AuthorizationRule();
        private AuthorizationRule _deleteAuthzRuleType = new AuthorizationRule();
        private string _getRoles = String.Empty;
        private string _newRoles = String.Empty;
        private string _updateRoles = String.Empty;
        private string _deleteRoles = String.Empty;
        private bool _parentInsertOnly;
        private string _publishToChannel = String.Empty;
        private string _subscribeToChannel = String.Empty;
        private bool _allowNew = true;
        private bool _allowEdit = true;
        private bool _allowRemove = true;
        private bool _generateFactoryMethods = true;
        private bool _generateDataPortalInsert = true;
        private bool _generateDataPortalUpdate = true;
        private bool _generateDataPortalDelete = true;
        private bool _supportUpdateProperties;
        private bool _addParentReference;
        private SimpleCacheResults _simpleCacheOptions = SimpleCacheResults.None;
        private List<string> _invalidateCache = new List<string>();
        private bool _useCustomLoading;
        private bool _checkRulesOnFetch = true;
        private bool _generateDataAccessRegion = true;
        private string _folder = String.Empty;
        private string[] _implements = new string[] { };
        private string[] _attributes = new string[] { };
        private string _classSummary = String.Empty;
        private string _classRemarks = String.Empty;
        private string[] _namespaces = new string[] { };
        private bool _dataSetLoadingScheme;
        private bool _cacheResults = true;

        #endregion

        #region Constructors

        public CslaObjectInfo(CslaGeneratorUnit parent)
            : base(parent)
        {
            _inheritedType = new TypeInfo(this);
            _inheritedType.TypeChanged += InheritedType_TypeChanged;

            _inheritedTypeWinForms = new TypeInfo(this);
            _inheritedTypeWinForms.TypeChanged += InheritedTypeWinForms_TypeChanged;

            _valueProperties.ItemChanged += vp_ItemChanged;
            if (parent != null && parent.Params != null)
            {
                _dbName = parent.Params.DefaultDataBase;
                _transactionType = parent.Params.DefaultTransactionType;
                _persistenceType = parent.Params.DefaultPersistenceType;
                _dbContextObject = parent.Params.DefaultDatabaseContextObject;
                _objectNamespace = parent.Params.DefaultNamespace;
                _folder = parent.Params.DefaultFolder;
            }
            _criteriaObjects.SetParent(this);
        }

        public CslaObjectInfo()
            : this(null)
        {
        }

        #endregion

        #region Public Properties

        #region 00. Generate Options

        [Category("00. Generate Options")]
        [Description("Whether or not this object should be generated.")]
        [UserFriendlyName("Generate Object")]
        public bool Generate
        {
            get { return _generate; }
            set
            {
                if (_generate == value)
                    return;
                _generate = value;
                OnPropertyChanged("Generate");
            }
        }

        [Category("00. Generate Options")]
        [Description("Whether or not to generate factory methods for this object. If False these methods are not generated so that you can write your custom factory methods. Note that the generation option \"Generate child factory methods\" bypasses factory methods except for root objects/collections.")]
        [UserFriendlyName("Generate Factory Methods")]
        public bool GenerateFactoryMethods
        {
            get { return _generateFactoryMethods; }
            set { _generateFactoryMethods = value; }
        }

        [Category("00. Generate Options")]
        [Description("Whether or not to generate DataPortal_ / Child_ methods. If False these methods are not generated so that you can write your custom data access region.")]
        [UserFriendlyName("Generate Data Access Region")]
        public bool GenerateDataAccessRegion
        {
            get { return _generateDataAccessRegion; }
            set { _generateDataAccessRegion = value; }
        }

        [Category("00. Generate Options")]
        [Description("Whether or not to generate DataPortal_ / Child_ Insert method.")]
        [UserFriendlyName("Generate Insert() Method")]
        public bool GenerateDataPortalInsert
        {
            get
            {
                if (ObjectType == CslaObjectType.ReadOnlyCollection ||
                    ObjectType == CslaObjectType.ReadOnlyObject ||
                    ObjectType == CslaObjectType.NameValueList ||
                    ObjectType == CslaObjectType.UnitOfWork)
                    return false;
                return _generateDataPortalInsert;
            }
            set { _generateDataPortalInsert = value; }
        }

        [Category("00. Generate Options")]
        [Description("Whether or not to generate DataPortal_ / Child_ Update method.")]
        [UserFriendlyName("Generate Update() Method")]
        public bool GenerateDataPortalUpdate
        {
            get
            {
                if (ObjectType == CslaObjectType.ReadOnlyCollection ||
                    ObjectType == CslaObjectType.ReadOnlyObject ||
                    ObjectType == CslaObjectType.NameValueList ||
                    ObjectType == CslaObjectType.UnitOfWork)
                    return false;
                return _generateDataPortalUpdate;
            }
            set { _generateDataPortalUpdate = value; }
        }

        [Category("00. Generate Options")]
        [Description("Whether or not to generate DataPortal_ / Child_ Delete & DeleteSelf methods.")]
        [UserFriendlyName("Generate Delete() and DeleteSelf() Methods")]
        public bool GenerateDataPortalDelete
        {
            get
            {
                if (ObjectType == CslaObjectType.ReadOnlyObject ||
                    ObjectType == CslaObjectType.NameValueList ||
                    ObjectType == CslaObjectType.UnitOfWork)
                    return false;
                return _generateDataPortalDelete;
            }
            set { _generateDataPortalDelete = value; }
        }

        [Category("00. Generate Options")]
        [Description("Whether or not to generate stored procedures for this object.")]
        [UserFriendlyName("Generate Stored Procedures")]
        public bool GenerateSprocs
        {
            get { return _generateSprocs; }
            set { _generateSprocs = value; }
        }

        [Category("00. Generate Options")]
        [Description("Set to true if you have child objects that have children themselves. You should do this for all the objects that are going to be loaded.")]
        [UserFriendlyName("DataSet Loading Scheme")]
        public bool DataSetLoadingScheme
        {
            get { return _dataSetLoadingScheme; }
            set { _dataSetLoadingScheme = value; }
        }

        [Category("00. Generate Options")]
        [Description("Whether or not to generate DataPortal_ / Child_ Fetch methods. If True these methods are not generated so that you can create a custom loading scheme.")]
        [UserFriendlyName("Use Custom Loading")]
        public bool UseCustomLoading
        {
            get { return _useCustomLoading; }
            set { _useCustomLoading = value; }
        }

        [Category("00. Generate Options")]
        [Description("Whether or not to check rules on DataPortal_ / Child_ Fetch methods. This invokes all business (validation) rules for the business type.")]
        [UserFriendlyName("Check Rules On Fetch")]
        public bool CheckRulesOnFetch
        {
            get { return _checkRulesOnFetch; }
            set { _checkRulesOnFetch = value; }
        }

        [Category("00. Generate Options")]
        [Description("Whether or not to generate Saved Event support. If True, Read Only Collections can subscribe to this event in order to update themselves locally without a database round trip.")]
        [UserFriendlyName("Support Update Properties")]
        public bool SupportUpdateProperties
        {
            get { return _supportUpdateProperties; }
            set { _supportUpdateProperties = value; }
        }

        #endregion

        #region 01. Common Options

        [Category("01. Common Options")]
        [Description("The type of Csla object to create, e.g EditableRoot, EditableChild, etc...")]
        [UserFriendlyName("Csla Object Type")]
        public CslaObjectType ObjectType
        {
            get { return _objectType; }
            set
            {
                CslaObjectType temp = _objectType;
                _objectType = value;
                if (_inheritedType.Type != String.Empty)
                {
                    try
                    {
                        //ValidateType(_inheritedType.GetInheritedType());
                    }
                    catch (Exception e)
                    {
                        _objectType = temp;
                        throw e;
                    }
                }
                OnPropertyChanged("ObjectType");
            }
        }

        [Category("01. Common Options")]
        [Description("The type of Unit of Work to create: Creator, Getter, Updater, Deleter")]
        [UserFriendlyName("Unit of Work Type")]
        public UnitOfWorkFunction UnitOfWorkType
        {
            get { return _unitOfWorkType; }
            set
            {
                if (_unitOfWorkType != value)
                {
                    _unitOfWorkType = value;
                    OnPropertyChanged("UnitOfWorkType");
                }
            }
        }

        [Category("01. Common Options")]
        [Description("The class name of the Csla object.")]
        [UserFriendlyName("Object Name")]
        public string ObjectName
        {
            get { return _objectName; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_objectName != value)
                {
                    _objectName = value;
                    if (_fileName.Equals(String.Empty))
                        _fileName = value;
                    OnPropertyChanged("ObjectName");
                }
            }
        }

        [Category("01. Common Options")]
        [Description("The Namespace the object will exist in.")]
        [UserFriendlyName("Object Namespace")]
        public string ObjectNamespace
        {
            get { return _objectNamespace; }
            set { _objectNamespace = PropertyHelper.Tidy(value); }
        }

        [Category("01. Common Options")]
        [Description("Class Summary documentation for the object. This shows before the automatic Csla stereotype.\r\n" +
            "Clear, close and re-open to fetch the table descriptions.")]
        [Editor(typeof(XmlCommentEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Class Summary")]
        public string ClassSummary
        {
            get { return _classSummary; }
            set { _classSummary = PropertyHelper.TidyXML(value); }
        }

        [Category("01. Common Options")]
        [Description("Class Remarks documentation for the object. This shows before the automatic remarks.")]
        [Editor(typeof(XmlCommentEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Class Remarks")]
        public string ClassRemarks
        {
            get { return _classRemarks; }
            set { _classRemarks = PropertyHelper.TidyXML(value); }
        }

        [Category("01. Common Options")]
        [Description("The Namespaces this class uses (\"using\" in C# or \"Imports\" in VB). Write one namespace per line.")]
        [UserFriendlyName("Namespaces")]
        public string[] Namespaces
        {
            get { return _namespaces; }
            set { _namespaces = PropertyHelper.Tidy(value); }
        }

        [Category("01. Common Options")]
        [Description("The attributes you want to add to this class.")]
        [UserFriendlyName("Attributes")]
        public string[] Attributes
        {
            get { return _attributes; }
            set { _attributes = PropertyHelper.TidyAllowSpaces(value); }
        }

        [Category("01. Common Options")]
        [Description("The interfaces this class implements.")]
        [UserFriendlyName("Interfaces")]
        public string[] Implements
        {
            get { return _implements; }
            set { _implements = PropertyHelper.Tidy(value); }
        }

        [Category("01. Common Options")]
        [Description("The type that this object inherits from. You can either select an object defined in the current project or an object defined in another assembly.\r\n" + 
            "The object you inherit from must inherit from a valid Csla base object.")]
        [Editor(typeof(ObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(TypeInfoConverter))]
        [UserFriendlyName("Inherited Type")]
        public TypeInfo InheritedType
        {
            get { return _inheritedType; }
            set
            {
                if (!ReferenceEquals(value, _inheritedType))
                {
                    if (_inheritedType != null)
                        _inheritedType.TypeChanged -= InheritedType_TypeChanged;
                    _inheritedType = value;
                    _inheritedType.TypeChanged += InheritedType_TypeChanged;
                    OnPropertyChanged("InheritedType");
                }
            }
        }

        [Category("01. Common Options")]
        [Description("For Windows Forms, the type that this object inherits from. You can either select an object defined in the current project or an object defined in another assembly.\r\n" + 
            "The object you inherit from must inherit from a valid Csla base object.")]
        [Editor(typeof(ObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(TypeInfoConverter))]
        [UserFriendlyName("Inherited Type for WinForms")]
        public TypeInfo InheritedTypeWinForms
        {
            get { return _inheritedTypeWinForms; }
            set
            {
                if (!ReferenceEquals(value, _inheritedTypeWinForms))
                {
                    if (_inheritedTypeWinForms != null)
                        _inheritedTypeWinForms.TypeChanged -= InheritedTypeWinForms_TypeChanged;
                    _inheritedTypeWinForms = value;
                    _inheritedTypeWinForms.TypeChanged += InheritedTypeWinForms_TypeChanged;
                }
            }
        }

        [Category("01. Common Options")]
        [Description("Wheter the class constructor is private, protected, etc. The default is \"private\".")]
        [UserFriendlyName("Constructor's Visibility")]
        public ConstructorVisibility ConstructorVisibility
        {
            get { return _constructorVisibility; }
            set { _constructorVisibility = value; }
        }

        [Category("01. Common Options")]
        [Description("The folder name for the object.")]
        [UserFriendlyName("Output Folder")]
        public string Folder
        {
            get { return _folder; }
            set { _folder = PropertyHelper.TidyAllowSpaces(value); }
        }

        [Category("01. Common Options")]
        [Description("The name of the generated file for the object. If no file extension is given, it defaults according to the Output Code Language for this object.")]
        [UserFriendlyName("File Name")]
        public string FileName
        {
            get { return _fileName; }
            set 
            {
                _fileName = PropertyHelper.TidyAllowSpaces(value);
                if (_objectName.Equals(String.Empty))
                    _objectName = PropertyHelper.Tidy(value);
            }
        }

        [Browsable(false)]
        public CodeLanguage OutputLanguage
        {
            get { return Parent.GenerationParams.OutputLanguage; }
            set { _outputLanguage = value; }
        }

        #endregion

        #region 02. Business Properties

        [Category("02. Business Properties")]
        [Description("The Unit of Work collection properties (specify here the root objects to handle as a unit).")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Unit of Work Properties")]
        public UnitOfWorkPropertyCollection UnitOfWorkProperties
        {
            get { return _unitOfWorkProperties; }
        }

        [Category("02. Business Properties")]
        [Description("The child collection properties of the object (specify here the child collections).")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Child Collection Properties")]
        public ChildPropertyCollection ChildCollectionProperties
        {
            get { return _childCollectionProperties; }
        }

        [Category("02. Business Properties")]
        [Description("The non-collection child properties of the object (specify here the child objects).")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Non-collection Child Properties")]
        public ChildPropertyCollection ChildProperties
        {
            get { return _childProperties; }
        }

        [Category("02. Business Properties")]
        [Description("If this object inherits from another type, this property will store the child collection properties it inherits. You cannot add or remove inherited properties, but you can modify them.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Inherited Child Collection Properties")]
        public ChildPropertyCollection InheritedChildCollectionProperties
        {
            get { return _inheritedChildCollectionProperties; }
        }

        [Category("02. Business Properties")]
        [Description("If this object inherits from another type, this property will store the non-collection child properties it inherits.You cannot add or remove inherited properties, but you can modify them.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Inherited Child Properties")]
        public ChildPropertyCollection InheritedChildProperties
        {
            get { return _inheritedChildProperties; }
        }

        [Category("02. Business Properties")]
        [Description("Value properties that convert to/from other properties of the same object.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Converted Value Properties")]
        public ConvertValuePropertyCollection ConvertValueProperties
        {
            get { return _convertValueProperties; }
        }

        [Category("02. Business Properties")]
        [Description("Value properties of this object that are updated when another object saves itself.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Updated Value Properties")]
        public UpdateValuePropertyCollection UpdateValueProperties
        {
            get { return _updateValueProperties; }
        }

        [Category("02. Business Properties")]
        [Description("If this object inherits from another type, this property will store the business properties it inherits. You cannot add or remove inherited properties, but you can modify them.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Inherited Value Properties")]
        public ValuePropertyCollection InheritedValueProperties
        {
            get { return _inheritedValueProperties; }
        }

        [Category("02. Business Properties")]
        [Description("The business properties of the object.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Value Properties")]
        public ValuePropertyCollection ValueProperties
        {
            get { return _valueProperties; }
        }

        #endregion

        #region 03. Criteria

        [Category("03. Criteria")]
        [Description("The Criteria classes that are used by this object.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Criteria Objects")]
        public CriteriaCollection CriteriaObjects
        {
            get { return _criteriaObjects; }
        }

        #endregion

        #region 04. Child Object Options

        [Category("04. Child Object Options")]
        [Description("The object type of the of this object's parent (specify the collection name for an item, or object name for a collection).")]
        [UserFriendlyName("Parent Type")]
        [Editor(typeof(ParentTypeEditor), typeof(UITypeEditor))]
        public string ParentType
        {
            get { return _parentType; }
            set
            {
                if (_parentType != ObjectName) //make sure we don't set ourselves as parent, just in case.
                    _parentType = value;
                else
                    _parentType = string.Empty;
            }
        }

        [Category("04. Child Object Options")]
        [Description("Parent properties which are used in DataPortal_Update, as parameters for Stored Procedures.")]
        [Editor(typeof(ParentPropertyCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(PropertyCollectionConverter))]
        [UserFriendlyName("Parent Properties")]
        public PropertyCollection ParentProperties
        {
            get { return _parentProperties; }
            set { _parentProperties = value; }
        }

        /// <summary>
        /// Prevents the parent property form participating in updates or deletes.
        /// </summary>
        /*[Category("04. Child Object Options")]
        [Description("The Parent properties are used only in inserts and aren't used in updates or deletes.\r\n" +
            "Set it to true when the child has its own ID that is used on updates and deletes.")]
        [UserFriendlyName("No Parent on updates/deletes")]*/
        [Browsable(false)]
        public bool ParentInsertOnly
        {
            get { return _parentInsertOnly; }
            set { _parentInsertOnly = value; }
        }

        /// <summary>
        /// Prevents the parent property form participating in updates or deletes.
        /// </summary>
        [Category("04. Child Object Options")]
        [Description("The Parent properties are used in inserts and may be also used in updates or deletes.\r\n" +
            "Use \"InsertOnly\" when the child has its own ID that is used on updates and deletes. " +
            "Use \"InsertUpdateDelete\" when the child has no ID of its own.")]
        [UserFriendlyName("Parent Properties Usage")]
        [XmlIgnore]
        public ParentPropertiesUsage UseParentProperties
        {
            get { return _parentInsertOnly ? ParentPropertiesUsage.InsertOnly : ParentPropertiesUsage.InsertUpdateDelete; }
            set
            {
                if (value == ParentPropertiesUsage.InsertOnly)
                    _parentInsertOnly = true;
                else
                    _parentInsertOnly = false;
            }
        }

        [Category("04. Child Object Options")]
        [Description("Whether or not this object should be \"lazy loaded\".  \"Lazy loading\" means the child object data " +
            "isn't loaded when the parent object data is loaded but is defered until the child object is referenced.\r\n" +
            "It must be set the same way in the parent object.")]
        [UserFriendlyName("Lazy Load")]
        public bool LazyLoad
        {
            get { return _lazyLoad; }
            set { _lazyLoad = value; }
        }

        #endregion

        #region 05. Collection Options

        [Category("05. Collection Options")]
        [Description("The type name of the objects the collection will hold.")]
        [UserFriendlyName("Item Type")]
        [Editor(typeof(ItemTypeEditor), typeof(UITypeEditor))]
        public string ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }

        [Category("05. Collection Options")]
        [Description("Defines whether you want to generate the collection Contains && ContainsDeleted methods or not.")]
        [UserFriendlyName("Use Contains Methods")]
        public bool ContainsItem
        {
            get { return _containsItem; }
            set { _containsItem = value; }
        }

        [Category("05. Collection Options")]
        [Description("For each parameter you select, a find method will be created which uses that parameter to find an item in the collection.")]
        [Editor(typeof(FMPropertyCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(PropertyCollectionConverter))]
        [UserFriendlyName("Find Methods Parameters")]
        public PropertyCollection FindMethodsParameters
        {
            get { return _findMethodsParameters; }
            set { _findMethodsParameters = value; }
        }

        [Category("05. Collection Options")]
        [Description("The type name of that will update the items of this collection.")]
        [UserFriendlyName("Updater Type")]
        [Editor(typeof(UpdaterTypeEditor), typeof(UITypeEditor))]
        public string UpdaterType
        {
            get { return _updaterType; }
            set { _updaterType = value; }
        }

        [Category("05. Collection Options")]
        [Description("Whether the collection allows adding new items through BindingList Methods. " +
            "If true, \"New Roles\" authz rules can restrict user rights.")]
        [UserFriendlyName("Allow New")]
        public bool AllowNew
        {
            get
            {
                if (ObjectType == CslaObjectType.ReadOnlyCollection ||
                    ObjectType == CslaObjectType.ReadOnlyObject ||
                    ObjectType == CslaObjectType.NameValueList)
                    return false;
                return _allowNew;
            }
            set { _allowNew = value; }
        }

        [Category("05. Collection Options")]
        [Description("Whether the collection allows editing items through BindingList Methods. " +
            "If true, \"Update Roles\" authz rules can restrict user rights.")]
        [UserFriendlyName("Allow Edit")]
        public bool AllowEdit
        {
            get
            {
                if (ObjectType == CslaObjectType.ReadOnlyCollection ||
                    ObjectType == CslaObjectType.ReadOnlyObject ||
                    ObjectType == CslaObjectType.NameValueList)
                    return false;
                return _allowEdit;
            }
            set { _allowEdit = value; }
        }

        [Category("05. Collection Options")]
        [Description("Whether the collection allows removing items through BindingList Methods. " +
            "If true, \"Delete Roles\" authz rules can restrict user rights.")]
        [UserFriendlyName("Allow Remove")]
        public bool AllowRemove
        {
            get
            {
                if (ObjectType == CslaObjectType.ReadOnlyCollection ||
                    ObjectType == CslaObjectType.ReadOnlyObject ||
                    ObjectType == CslaObjectType.NameValueList)
                    return false;
                return _allowRemove;
            }
            set { _allowRemove = value; }
        }

        [Category("05. Collection Options")]
        [Description("Create a reference to the parent collection. This option is only available for collection items.\r\n"+
            "When targeting CSLA40 this option is honoured for DynamicEditableRoot and ReadOnlyObjects.")]
        [UserFriendlyName("Add Parent Reference")]
        public bool AddParentReference
        {
            get { return _addParentReference; }
            set { _addParentReference = value; }
        }

        [Category("05. Collection Options")]
        [Description("Cache the results of the fetch operation for the list.\r\nFactory uses a static field that isn't transferred from server to client side.\r\nDataPortal avoids duplicate hits on the database.")]
        [UserFriendlyName("Cache Results Options")]
        public SimpleCacheResults SimpleCacheOptions
        {
            get { return _simpleCacheOptions; }
            set { _simpleCacheOptions = value; }
        }

        [Category("05. Collection Options")]
        [Description("The type names where the cache will be invalidated on Insert, Update and Delete operations.")]
        [UserFriendlyName("Invalidate Cache Types")]
        [Editor(typeof(InvalidateCacheTypeCollectionEditor), typeof(UITypeEditor))]
        public List<string> InvalidateCache
        {
            get { return _invalidateCache; }
            set { _invalidateCache = value; }
        }

        #endregion

        #region 06. NameValueList Info

        [Category("06. NameValueList Info")]
        [Description("Name of the column that are used as the key column in a NameValue List.")]
        [Editor(typeof(PropertyNameEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Key Column")]
        public string ValueColumn
        {
            get { return _valueColumn; }
            set { _valueColumn = value; }
        }

        [Category("06. NameValueList Info")]
        [Description("Name of the column that are used as the value column in a NameValue List.")]
        [Editor(typeof(PropertyNameEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Value Column")]
        public string NameColumn
        {
            get { return _nameColumn; }
            set { _nameColumn = value; }
        }

        [Category("06. NameValueList Info")]
        [Description("Whether to cache the results of the fetch operation for the name value list or not. This will also generate an InvalidateAll method to clear the cache.")]
        [UserFriendlyName("Cache Results")]
        public bool CacheResults
        {
            get { return _cacheResults; }
            set { _cacheResults = value; }
        }

        #endregion

        #region 07. Data Access Options

        [Category("07. Data Access Options")]
        [Description("Name of the database alias used to get the connection string from configuration file.")]
        [UserFriendlyName("Database Name")]
        public string DbName
        {
            get { return _dbName; }
            set { _dbName = PropertyHelper.Tidy(value); }
        }

        /// <summary>
        /// Persistence type to use for data access.
        /// </summary>
        [Category("07. Data Access Options")]
        [Description("Persistence type to use for data storage. When using DAL, SqlConnectionUnshared type is invalid.")]
        [UserFriendlyName("Persistence Type")]
        public PersistenceType PersistenceType
        {
            get
            {
                if (GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
                    if (_persistenceType == PersistenceType.SqlConnectionUnshared)
                        return PersistenceType.SqlConnectionManager;
                
                return _persistenceType;
            }
            set
            {
                if (GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
                    if (_persistenceType == PersistenceType.SqlConnectionUnshared)
                        value=  PersistenceType.SqlConnectionManager;

                _persistenceType = value;
            }
        }

        /// <summary>
        /// Database context object.
        /// </summary>
        [Category("07. Data Access Options")]
        [Description("Database context object for use with LinqContext and EFContext persistence types.")]
        [UserFriendlyName("Database Context Object")]
        public string DbContextObject
        {
            get { return _dbContextObject; }
            set { _dbContextObject = PropertyHelper.Tidy(value); }
        }

        /// <summary>
        /// Command Timeout.
        /// </summary>
        [Category("07. Data Access Options")]
        [Description("The time (in seconds) to wait for the command to execute. If not set will use the default value of 30 seconds.")]
        [UserFriendlyName("Command Timeout")]
        public string CommandTimeout
        {
            get
            {
                if (_commandTimeout == "0")
                    return string.Empty;
                return _commandTimeout;
            }
            set
            { _commandTimeout = PropertyHelper.TidyInteger(value); }
        }

        /// <summary>
        /// Transaction type to use for data access.
        /// </summary>
        [Category("07. Data Access Options")]
        [Description("Transaction type to use for data access. When using DAL, ADO type is invalid.")]
        [UserFriendlyName("Transaction Type")]
        public TransactionType TransactionType
        {
            get
            {
                if (GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
                    if (_transactionType == TransactionType.ADO)
                        return TransactionType.TransactionScope;

                return _transactionType;
            }
            set
            {
                if (value == TransactionType.TransactionalAttribute)
                {
                    _transactionType = TransactionType.TransactionScope;
                }
                else if (GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
                {
                    if (value == TransactionType.ADO)
                        _transactionType = TransactionType.TransactionScope;
                }
                else
                    _transactionType = value;
            }
        }

        /// <summary>
        /// The type of the Criteria object to be passed to the GetObject method.
        /// </summary>
        [Category("07. Data Access Options")]
        [Description("The type of the Criteria object to be passed to the GetObject method.")]
        //[Editor(typeof(CriteriaTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(CriteriaTypeConverter))]
        [UserFriendlyName("GetObject Criteria Type")]
        public Criteria GetObjectCriteriaType
        {
            get
            {
                return null;
                //if (_getObjectCriteriaType != null)
                //{
                //    //This is done for backwards compatibility
                //    _getObjectCriteriaTypeName = _getObjectCriteriaType.Name;
                //    _getObjectCriteriaType = null;
                //}
                //return _criteriaObjects.Find(_getObjectCriteriaTypeName);
            }
            set
            {
                //if (value == null)
                //    _getObjectCriteriaTypeName = String.Empty;
                //else
                if (value != null)
                {
                    //_getObjectCriteriaTypeName = value.Name;
                    Criteria c = _criteriaObjects.Find(value.Name);
                    if (c != null)
                    {
                        c.GetOptions.Factory = true;
                        c.GetOptions.DataPortal = true;
                        c.GetOptions.ProcedureName = _selectProcedureName;
                        c.GetOptions.Procedure = true;
                    }
                }
            }
        }

        #endregion

        #region 08. Insert & Update Options

        // Show 08. Stored Procedure Names for pre CSLA4 targets

        [Category("08. Insert & Update Options")]
        [Description("Whether DataPortal_Insert and DataPortal_Update should run on the client.\r\n" +
            "For Editable Child object it refers also to Child_DeleteSelf")]
        [UserFriendlyName("RunLocal")]
        public bool InsertUpdateRunLocal
        {
            get { return _insertUpdateRunLocal; }
            set { _insertUpdateRunLocal = value; }
        }

        /// <summary>
        /// Name of the insert procedure.
        /// </summary>
        [Category("08. Insert & Update Options")]
        [Description("Name of the insert procedure.")]
        [UserFriendlyName("Insert Procedure Name")]
        public string InsertProcedureName
        {
            get
            {
                if (ObjectType == CslaObjectType.ReadOnlyCollection ||
                    ObjectType == CslaObjectType.ReadOnlyObject ||
                    ObjectType == CslaObjectType.NameValueList)
                    return string.Empty;
                return _insertProcedureName;
            }
            set { _insertProcedureName = PropertyHelper.Tidy(value); }
        }

        /// <summary>
        /// Name of the select procedure.
        /// </summary>
        [Category("08. Insert & Update Options")]
        [Description("Name of the select procedure.")]
        [UserFriendlyName("Select Procedure Name")]
        public string SelectProcedureName
        {
            get { return _selectProcedureName; }
            set
            {
                //_selectProcedureName = value;
                if (!String.IsNullOrEmpty(value))
                    foreach (Criteria c in _criteriaObjects)
                        if (c.GetOptions.Procedure && string.IsNullOrEmpty(c.GetOptions.ProcedureName))
                            c.GetOptions.ProcedureName = PropertyHelper.Tidy(value);

            }
        }

        /// <summary>
        /// Name of the update procedure.
        /// </summary>
        [Category("08. Insert & Update Options")]
        [Description("Name of the update procedure.")]
        [UserFriendlyName("Update Procedure Name")]
        public string UpdateProcedureName
        {
            get
            {
                if (ObjectType == CslaObjectType.ReadOnlyCollection ||
                    ObjectType == CslaObjectType.ReadOnlyObject ||
                    ObjectType == CslaObjectType.NameValueList)
                    return string.Empty;
                return _updateProcedureName;
            }
            set { _updateProcedureName = PropertyHelper.Tidy(value); }
        }

        /// <summary>
        /// Name of the delete procedure.
        /// </summary>
        [Category("08. Insert & Update Options")]
        [Description("Name of the delete procedure. This is used only for Editable Child objects.")]
        [UserFriendlyName("Delete Procedure Name")]
        public string DeleteProcedureName
        {
            get
            {
                if (ObjectType == CslaObjectType.ReadOnlyCollection ||
                    ObjectType == CslaObjectType.ReadOnlyObject ||
                    ObjectType == CslaObjectType.NameValueList)
                    return string.Empty;
                return _deleteProcedureName;
            }
            set
            {
                if (_objectType == CslaObjectType.EditableChild ||
                    _objectType == CslaObjectType.EditableSwitchable)
                    _deleteProcedureName = PropertyHelper.Tidy(value);
                else
                {
                    if (!String.IsNullOrEmpty(value))
                        foreach (var c in _criteriaObjects)
                            if (c.DeleteOptions.Procedure && string.IsNullOrEmpty(c.DeleteOptions.ProcedureName))
                                c.DeleteOptions.ProcedureName = PropertyHelper.Tidy(value);
                }
            }
        }

        [Category("08. Insert & Update Options")]
        [Description("Defines whether you want to use the timestamp property on Child_SelfDelete method or not. "+
            "This is used only for Editable Child objects.")]
        [UserFriendlyName("Use timestamp on Delete")]
        public bool DeleteUseTimestamp
        {
            get { return _deleteUseTimestamp; }
            set { _deleteUseTimestamp = value; }
        }

        [Category("08. Insert & Update Options")]
        [Description("Defines whether you want to generate the collection Remove method or not. " +
            "This is used only for Editable Child objects that are collection items.")]
        [UserFriendlyName("Use Remove Method")]
        public bool RemoveItem
        {
            get { return _removeItem; }
            set { _removeItem = value; }
        }

        #endregion

        #region 09. System.Object Overrides

        /// <summary>
        /// The properties that are used to create the object's hashcode.
        /// If multiple properties are selected the results of their GetHashCode
        /// methods are xor'd.  If none are selected, GetHashCode method is not overridden
        /// </summary>
        [Category("09. System.Object Overrides")]
        [Description("The properties that are used to create the object's hashcode.  If multiple properties are selected the results of their GetHashCode methods are xor'd.  If none are selected, GetHashCode method is not overridden")]
        [Editor(typeof(PropertyCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(PropertyCollectionConverter))]
        [UserFriendlyName("Hashcode Property")]
        public PropertyCollection HashcodeProperty
        {
            get { return _hashcodeProperty; }
            set { _hashcodeProperty = value; }
        }

        /// <summary>
        /// The properties that are used to check object equivalence.
        /// If none are selected, Equals method is not overridden
        /// </summary>
        [Category("09. System.Object Overrides")]
        [Description("The properties that are used to check object equivalence.  If none are selected, Equals method is not overridden")]
        [Editor(typeof(PropertyCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(PropertyCollectionConverter))]
        [UserFriendlyName("Equals Property")]
        public PropertyCollection EqualsProperty
        {
            get { return _equalsProperty; }
            set { _equalsProperty = value; }
        }

        /// <summary>
        /// The properties that are used to create a string from the object's ToString property.
        /// If multiple properties are selected, they are concatenated.
        /// If none are selected, ToString method is not overridden
        /// </summary>
        [Category("09. System.Object Overrides")]
        [Description("The properties that are used to create a string from the object's ToString property.  If multiple properties are selected, they are concatenated.  If none are selected, ToString method is not overridden")]
        [Editor(typeof(PropertyCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(PropertyCollectionConverter))]
        [UserFriendlyName("ToString Property")]
        public PropertyCollection ToStringProperty
        {
            get { return _toStringProperty; }
            set { _toStringProperty = value; }
        }

        #endregion

        #region 10. Business Rules & Authorization

        [Category("10. Business Rules & Authorization")]
        [Description("Collection of business rules (transformation, validation, etc).")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Business Rules Collection")]
        public virtual BusinessRuleCollection BusinessRules
        {
            get { return _businessRules; }
            set
            {
                if (_businessRules != value)
                {
                    _businessRules = value;
                    OnPropertyChanged("BusinessRules");
                }
            }
        }
        
        [Category("10. Business Rules & Authorization")]
        [Description("The Authorization Provider for this property.")]
        [UserFriendlyName("Authorization Provider")]
        public virtual AuthorizationProvider AuthzProvider
        {
            get { return _authzProvider; }
            set
            {
                if (_authzProvider != value)
                {
                    _authzProvider = value;
                    OnPropertyChanged("AuthzProvider");
                }
            }
        }
        
        /// <summary>
        /// Roles to create object. Multiple roles must be separated with ;.
        /// </summary>
        [Category("10. Business Rules & Authorization")]
        [Description("Roles to create object. Use a comma to separate multiple roles.")]
        [UserFriendlyName("New Roles")]
        public string NewRoles
        {
            get { return _newRoles; }
            set { _newRoles = PropertyHelper.TidyAllowSpaces(value).Replace(';', ',').Trim(new[] {'!', ','}); }
        }

        /// <summary>
        /// Roles to retrieve object. Multiple roles must be separated with ;.
        /// </summary>
        [Category("10. Business Rules & Authorization")]
        [Description("Roles to retrieve object. Use a comma to separate multiple roles.")]
        [UserFriendlyName("Get Roles")]
        public string GetRoles
        {
            get { return _getRoles; }
            set { _getRoles = PropertyHelper.TidyAllowSpaces(value).Replace(';', ',').Trim(new[] { '!', ',' }); }
        }

        /// <summary>
        /// Roles to update object. Multiple roles must be separated with ;.
        /// </summary>
        [Category("10. Business Rules & Authorization")]
        [Description("Roles to update object. Use a comma to separate multiple roles.")]
        [UserFriendlyName("Update Roles")]
        public string UpdateRoles
        {
            get { return _updateRoles; }
            set { _updateRoles = PropertyHelper.TidyAllowSpaces(value).Replace(';', ',').Trim(new[] { '!', ',' }); }
        }

        /// <summary>
        /// Roles to delete object. Multiple roles must be separated with ;.
        /// </summary>
        [Category("10. Business Rules & Authorization")]
        [Description("Roles to delete object. Use a comma to separate multiple roles.")]
        [UserFriendlyName("Delete Roles")]
        public string DeleteRoles
        {
            get { return _deleteRoles; }
            set { _deleteRoles = PropertyHelper.TidyAllowSpaces(value).Replace(';', ',').Trim(new[] { '!', ',' }); }
        }

        [Category("10. Business Rules & Authorization")]
        [Description("The Authorization Type that controls create object action. You can either select an object defined in the current project or an object defined in another assembly.")]
        [Editor(typeof(ObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(AuthorizationRuleTypeConverter))]
        [UserFriendlyName("Create Authorization Type")]
        public virtual AuthorizationRule NewAuthzRuleType
        {
            get { return _newAuthzRuleType; }
            set
            {
                if (!ReferenceEquals(value, _newAuthzRuleType))
                {
                    if (_newAuthzRuleType != null)
                    {
                        // _authzProviderType.TypeChanged -= AuthProviderType_TypeChanged;
                        _newAuthzRuleType = value;
                        // _authzProviderType.TypeChanged += AuthProviderType_TypeChanged;
                    }
                }
            }
        }

        [Category("10. Business Rules & Authorization")]
        [Description("The Authorization Type that controls get object action. You can either select an object defined in the current project or an object defined in another assembly.")]
        [Editor(typeof(ObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(AuthorizationRuleTypeConverter))]
        [UserFriendlyName("Get Authorization Type")]
        public virtual AuthorizationRule GetAuthzRuleType
        {
            get { return _getAuthzRuleType; }
            set
            {
                if (!ReferenceEquals(value, _getAuthzRuleType))
                {
                    if (_getAuthzRuleType != null)
                    {
                        // _authzProviderType.TypeChanged -= AuthProviderType_TypeChanged;
                        _getAuthzRuleType = value;
                        // _authzProviderType.TypeChanged += AuthProviderType_TypeChanged;
                    }
                }
            }
        }

        [Category("10. Business Rules & Authorization")]
        [Description("The Authorization Type that controls update object action. You can either select an object defined in the current project or an object defined in another assembly.")]
        [Editor(typeof(ObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(AuthorizationRuleTypeConverter))]
        [UserFriendlyName("Update Authorization Type")]
        public virtual AuthorizationRule UpdateAuthzRuleType
        {
            get { return _updateAuthzRuleType; }
            set
            {
                if (!ReferenceEquals(value, _updateAuthzRuleType))
                {
                    if (_updateAuthzRuleType != null)
                    {
                        // _authzProviderType.TypeChanged -= AuthProviderType_TypeChanged;
                        _updateAuthzRuleType = value;
                        // _authzProviderType.TypeChanged += AuthProviderType_TypeChanged;
                    }
                }
            }
        }

        [Category("10. Business Rules & Authorization")]
        [Description("The Authorization Type that controls delete object action. You can either select an object defined in the current project or an object defined in another assembly.")]
        [Editor(typeof(ObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(AuthorizationRuleTypeConverter))]
        [UserFriendlyName("Delete Authorization Type")]
        public virtual AuthorizationRule DeleteAuthzRuleType
        {
            get { return _deleteAuthzRuleType; }
            set
            {
                if (!ReferenceEquals(value, _deleteAuthzRuleType))
                {
                    if (_deleteAuthzRuleType != null)
                    {
                        // _authzProviderType.TypeChanged -= AuthProviderType_TypeChanged;
                        _deleteAuthzRuleType = value;
                        // _authzProviderType.TypeChanged += AuthProviderType_TypeChanged;
                    }
                }
            }
        }

        #endregion

        #region 11. Active Objects

        [Category("11. Active Objects")]
        [Description("The channel you want to publish events to. Empty if you don't want to publish.")]
        [UserFriendlyName("Publish to channel")]
        public string PublishToChannel
        {
            get { return _publishToChannel; }
            set { _publishToChannel = value; }
        }

        [Category("11. Active Objects")]
        [Description("The channel you want to subscribe to for events. Empty if you don't want to Subscribe to any channel.")]
        [UserFriendlyName("Subscribe to channel")]
        public string SubscribeToChannel
        {
            get { return _subscribeToChannel; }
            set { _subscribeToChannel = value; }
        }

        #endregion

        #region Utility property collections

        /// <summary>
        /// Object's child collection and non collection properties.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public ChildPropertyCollection AllChildProperties
        {
            get { return GetMyChildProperties(); }
        }

        /// <summary>
        /// Object's inherited child collection and non collection properties.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public ChildPropertyCollection AllInheritedChildProperties
        {
            get { return GetInheritedChildProperties(); }
        }

        /// <summary>
        /// Object's value properties and convert value properties.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public ValuePropertyCollection AllValueProperties
        {
            get { return GetMyValueProperties(); }
        }

        /// <summary>
        /// Object's properties that can have rules associated with.
        /// </summary>
        /// <returns>All value properties, inherited value properties and absolutely all child properties.</returns>
        public HaveBusinessRulesCollection AllRulableProperties()
        {
            var allRulableProperties = new HaveBusinessRulesCollection();
            allRulableProperties.AddRange(AllValueProperties); // ValueProperties and ConvertValueProperties
            allRulableProperties.AddRange(InheritedValueProperties); // InheritedValueProperties
            // ChildProperties, ChildCollectionProperties, InheritedChildProperties, InheritedChildCollectionProperties
            allRulableProperties.AddRange(GetAllChildProperties());

            return allRulableProperties;
        }

        #endregion

        [Browsable(false)]
        [XmlIgnore]
        public AuthorizationActions ActionProperty { get; set; }

        [Browsable(false)]
        public bool HasCreateCriteria
        {
            get { return _criteriaObjects.Any(c => c.CreateOptions.DataPortal); }
        }

        [Browsable(false)]
        public bool HasCreateCriteriaFactory
        {
            get { return _criteriaObjects.Any(c => c.CreateOptions.Factory); }
        }

        [Browsable(false)]
        public bool HasGetCriteria
        {
            get { return _criteriaObjects.Any(c => c.GetOptions.DataPortal); }
        }

        [Browsable(false)]
        public bool HasGetCriteriaFactory
        {
            get { return _criteriaObjects.Any(c => c.GetOptions.Factory); }
        }

        [Browsable(false)]
        public bool HasDeleteCriteria
        {
            get { return _criteriaObjects.Any(c => c.DeleteOptions.DataPortal); }
        }

        [Browsable(false)]
        public bool HasDeleteCriteriaFactory
        {
            get { return _criteriaObjects.Any(c => c.DeleteOptions.Factory); }
        }

        [Browsable(false)]
        [XmlIgnore]
        public CriteriaCollection MyCriteriaObjects
        {
            get { return _myCriteriaObjects; }
            set { _myCriteriaObjects = value; }
        }

        [Browsable(false)]
        public bool IsCreator
        {
            get { return UnitOfWorkType == UnitOfWorkFunction.Creator; }
        }

        [Browsable(false)]
        public bool IsGetter
        {
            get { return UnitOfWorkType == UnitOfWorkFunction.Getter; }
        }

        [Browsable(false)]
        public bool IsUpdater
        {
            get { return UnitOfWorkType == UnitOfWorkFunction.Updater; }
        }

        [Browsable(false)]
        public bool IsDeleter
        {
            get { return UnitOfWorkType == UnitOfWorkFunction.Deleter; }
        }

        [Browsable(false)]
        public bool HasNullableProperties
        {
            get
            {
                if (GetAllValueProperties().Any(p => p.Nullable))
                {
                    return true;
                }
                return CriteriaObjects.SelectMany(c => c.Properties).Any(p => p.Nullable);
            }
        }

        #endregion

        #region Event Handlers

        public void InheritedType_TypeChanged(object sender, EventArgs e)
        {
            var t = (TypeInfo)sender;
            if (t.Type != String.Empty)
            {
                //ValidateType(t.GetInheritedType());
            }
            //SetInheritedProperties(t);
            OnPropertyChanged("InheritedType");
        }

        public void InheritedTypeWinForms_TypeChanged(object sender, EventArgs e)
        {
            var t = (TypeInfo)sender;
            if (t.Type != String.Empty)
            {
                //ValidateType(t.GetInheritedType());
            }
            //SetInheritedProperties(t);
        }

        /*public void AuthProviderType_TypeChanged(object sender, EventArgs e)
        {
            var t = (AutzTypeInfo)sender;
            if (t.Type != String.Empty)
            {
                //ValidateType(t.GetInheritedType());
            }
            //SetInheritedProperties(t);
        }*/

        #endregion
        
        #region Private and Internal Methods

        private ValueProperty GetValuePropertyFromInfo(PropertyInfo info)
        {
            var prop = new ValueProperty();
            prop.Name = info.Name;
            prop.PropertyType = TypeHelper.GetTypeCodeEx(info.PropertyType);

            return prop;
        }

        private ChildProperty GetChildPropertyFromInfo(PropertyInfo info)
        {
            var prop = new ChildProperty();
            prop.Name = info.Name;
            prop.TypeName = info.PropertyType.FullName;
            prop.LoadingScheme = LoadingScheme.ParentLoad;
            return prop;
        }

        private UnitOfWorkProperty GetUnitOfWorkPropertyFromInfo(PropertyInfo info)
        {
            var prop = new UnitOfWorkProperty();
            prop.Name = info.Name;
            return prop;
        }

        internal void SetProcedureNames()
        {
            if (Parent == null)
                return;
            if (_objectType == CslaObjectType.UnitOfWork)
                return;
            if (_objectType == CslaObjectType.EditableChild ||
                    _objectType == CslaObjectType.EditableSwitchable ||
                    _objectType == CslaObjectType.DynamicEditableRoot)
            {
                _deleteProcedureName =
                    Parent.Params.SpGeneralPrefix
                    + Parent.Params.SpDeletePrefix
                    + _objectName
                    + Parent.Params.SpDeleteSuffix
                    + Parent.Params.SpGeneralSuffix;
            }
            if (CslaTemplateHelperCS.IsEditableType(_objectType))
            {
                _insertProcedureName =
                    Parent.Params.SpGeneralPrefix
                    + Parent.Params.SpAddPrefix
                    + _objectName
                    + Parent.Params.SpAddSuffix
                    + Parent.Params.SpGeneralSuffix;
                /*_selectProcedureName =
                    Parent.Params.SpGeneralPrefix
                    + Parent.Params.SpGetPrefix
                    + _objectName
                    + Parent.Params.SpGetSuffix
                    + Parent.Params.SpGeneralSuffix;*/
                _updateProcedureName =
                    Parent.Params.SpGeneralPrefix
                    + Parent.Params.SpUpdatePrefix
                    + _objectName
                    + Parent.Params.SpUpdateSuffix
                    + Parent.Params.SpGeneralSuffix;
            }
            foreach (Criteria c in _criteriaObjects)
            {
                c.SetSprocNames();
            }
        }

        #endregion

        #region Public Methods

        public CslaObjectInfo Duplicate(ICatalog catalog)
        {
            var buffer = new MemoryStream();
            var ser = new XmlSerializer(typeof(CslaObjectInfo));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            var duplicate = (CslaObjectInfo)ser.Deserialize(buffer);
            if (catalog != null)
            {
                duplicate.LoadColumnInfo(catalog);
            }
            duplicate.Parent = Parent;
            return duplicate;
        }

        public void LoadColumnInfo(ICatalog catalog)
        {
            foreach (ValueProperty prop in ValueProperties)
            {
                prop.DbBindColumn.LoadColumn(catalog);
            }

            foreach (ValueProperty prop in InheritedValueProperties)
            {
                prop.DbBindColumn.LoadColumn(catalog);
            }
            foreach (Criteria c in _criteriaObjects)
            {
                foreach (CriteriaProperty p in c.Properties)
                {
                    p.DbBindColumn.LoadColumn(catalog);
                    if (p.DbBindColumn.Column == null)
                    {
                        ValueProperty vProp = ValueProperties.Find(p.Name);
                        if (vProp != null)
                        {
                            p.DbBindColumn = vProp.DbBindColumn;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets all value properties database boundable (it doesn't check whether they are actually bound).
        /// </summary>
        /// <returns>A ValuePropertyCollection with all ValueProperties and InheritedValueProperties.</returns>
        public ValuePropertyCollection GetDatabaseBoundValueProperties()
        {
            var allDatabaseBoundValueProperties = new ValuePropertyCollection();

            allDatabaseBoundValueProperties.AddRange(_valueProperties);
            allDatabaseBoundValueProperties.AddRange(_inheritedValueProperties);

            return allDatabaseBoundValueProperties;
        }

        /// <summary>
        /// Gets value properties and inherited value properties.
        /// </summary>
        /// <returns>A ValuePropertyCollection with ValueProperties and InheritedValueProperties.</returns>
        public ValuePropertyCollection GetAllValueProperties()
        {
            var allValueProperties = new ValuePropertyCollection();

            allValueProperties.AddRange(_valueProperties);
            allValueProperties.AddRange(_inheritedValueProperties);

            return allValueProperties;
        }

        /// <summary>
        /// Gets the value properties correspondent to the parent properties of the child object.
        /// </summary>
        /// <returns>A ValuePropertyCollection with parent's ValueProperties of the child's parent properties.</returns>
        public ValuePropertyCollection GetParentValueProperties()
        {
            var parentValueProperties = new ValuePropertyCollection();
            if (!_parentType.Equals(string.Empty))
            {
                CslaObjectInfo parent = FindParent(this);
                if (parent != null)
                {
                    foreach (Property p in _parentProperties)
                    {
                        ValueProperty prop = parent.GetAllValueProperties().Find(p.Name);
                        if (prop != null)
                            parentValueProperties.Add(prop);
                    }
                }
            }

            return parentValueProperties;
        }

        /// <summary>
        /// Finds the parent of a CslaObjectInfo (object or collection).
        /// </summary>
        /// <param name="info">The CslaObjectInfo.</param>
        /// <returns>
        /// The parent CslaObjectInfo.
        /// </returns>
        public CslaObjectInfo FindParent(CslaObjectInfo info)
        {
            if (!_parentType.Equals(string.Empty))
            {
                var parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
                if (parentInfo != null)
                {
                    if (parentInfo.ItemType == info.ObjectName)
                        return FindParent(parentInfo);

                    if (parentInfo.GetAllChildProperties().FindType(info.ObjectName) != null)
                        return parentInfo;

                    /*if (parentInfo.GetCollectionChildProperties().FindType(info.ObjectName) != null)
                        return parentInfo;*/
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the child collection and non collection properties.
        /// </summary>
        /// <returns>A ChildPropertyCollection with ChildProperties and ChildCollectionProperties.</returns>
        public ChildPropertyCollection GetMyChildProperties()
        {
            var myChildProperties = new ChildPropertyCollection();

            myChildProperties.AddRange(_childProperties);
            myChildProperties.AddRange(_childCollectionProperties);

            return myChildProperties;
        }

        /// <summary>
        /// Gets the value properties and convert value properties.
        /// </summary>
        /// <returns>A ValuePropertyCollection with ValueProperties and ConvertValueProperties.</returns>
        public ValuePropertyCollection GetMyValueProperties()
        {
            var myValueProperties = new ValuePropertyCollection();

            myValueProperties.AddRange(_valueProperties);
            myValueProperties.AddRange(ConvertToValuePropertyCollection(_convertValueProperties));

            return myValueProperties;
        }

        /// <summary>
        /// Converts a ConvertValuePropertyCollection to ValuePropertyCollection.
        /// </summary>
        /// <param name="convertValuePropertyCollection">The ConvertValuePropertyCollection to convert.</param>
        /// <returns>A ValuePropertyCollection with the converted ConvertValueProperties.</returns>
        private ValuePropertyCollection ConvertToValuePropertyCollection(ConvertValuePropertyCollection convertValuePropertyCollection)
        {
            var valuePropertyCollection = new ValuePropertyCollection();
            foreach (ConvertValueProperty convertValueProperty in convertValuePropertyCollection)
            {
                ValueProperty valueProperty = convertValueProperty;
                valuePropertyCollection.Add(valueProperty);
            }
            return valuePropertyCollection;
        }

        /// <summary>
        /// Gets the inherited child collection and non collection properties.
        /// </summary>
        /// <returns>A ChildPropertyCollection with InheritedChildProperties and InheritedChildProperties.</returns>
        public ChildPropertyCollection GetInheritedChildProperties()
        {
            var inheritedChildProperties = new ChildPropertyCollection();

            inheritedChildProperties.AddRange(_inheritedChildProperties);
            inheritedChildProperties.AddRange(_inheritedChildCollectionProperties);

            return inheritedChildProperties;
        }

        /// <summary>
        /// Gets all child properties: collection and non-collection, including inherited.
        /// </summary>
        /// <returns>A ChildPropertyCollection with absolutely all ChildProperties.</returns>
        public ChildPropertyCollection GetAllChildProperties()
        {
            var allChildProperties = new ChildPropertyCollection();

            allChildProperties.AddRange(_childProperties);
            allChildProperties.AddRange(_childCollectionProperties);
            allChildProperties.AddRange(_inheritedChildProperties);
            allChildProperties.AddRange(_inheritedChildCollectionProperties);

            return allChildProperties;
        }

        /// <summary>
        /// Gets the non collection child and inherited child properties.
        /// </summary>
        /// <returns>A ChildPropertyCollection with ChildProperties and InheritedChildProperties.</returns>
        public ChildPropertyCollection GetNonCollectionChildProperties()
        {
            var nonCollectionChildProps = new ChildPropertyCollection();

            nonCollectionChildProps.AddRange(_childProperties);
            nonCollectionChildProps.AddRange(_inheritedChildProperties);

            return nonCollectionChildProps;
        }

        /// <summary>
        /// Gets the collection child and inherited collection child properties.
        /// </summary>
        /// <returns>A ChildPropertyCollection with ChildCollectionProperties and InheritedChildCollectionProperties.</returns>
        public ChildPropertyCollection GetCollectionChildProperties()
        {
            var collectionChildProps = new ChildPropertyCollection();

            collectionChildProps.AddRange(_childCollectionProperties);
            collectionChildProps.AddRange(_inheritedChildCollectionProperties);

            return collectionChildProps;
        }

        #endregion

        private void vp_ItemChanged(ValueProperty sender, PropertyNameChangedEventArgs e)
        {
            foreach (var c in _criteriaObjects)
            {
                HandleNameChanged(c.Properties, e);
            }
            HandleNameChanged(_toStringProperty, e);
            HandleNameChanged(_equalsProperty, e);
            HandleNameChanged(_hashcodeProperty, e);
        }

        private void HandleNameChanged(PropertyCollection col, PropertyNameChangedEventArgs e)
        {
            foreach (var p in col)
            {
                if (p.Name.Equals(e.OldName))
                    p.Name = e.NewName;
            }
        }

        private void HandleNameChanged(CriteriaPropertyCollection col, PropertyNameChangedEventArgs e)
        {
            foreach (var p in col)
            {
                if (p.Name.Equals(e.OldName))
                    p.Name = e.NewName;
            }
        }

        #region System.Object Overrides

        public override string ToString()
        {
            return _objectName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            if (obj.GetType().Equals(typeof(CslaObjectInfo)))
                return _objectName.Equals(((CslaObjectInfo)obj).ObjectName);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _objectName.GetHashCode();
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (propertyName == "InheritedType")
            {
                if (_inheritedType.ObjectName == string.Empty && _inheritedType.Type == string.Empty)
                {
                    _inheritedTypeWinForms.ObjectName = string.Empty;
                    _inheritedTypeWinForms.Type = string.Empty;
                }
            }
            if (propertyName == "ObjectName")
                SetProcedureNames();
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
