        using System;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing.Design;
        using System.IO;
        using System.Reflection;
        using System.Xml.Serialization;
        using CslaGenerator.Design;
        using CslaGenerator.Util;
        using CslaGenerator.Attributes;
        using DBSchemaInfo.Base;
        using System.Drawing;

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
            private CslaObjectType _objectType = CslaObjectType.EditableRoot;
            private ConstructorVisibility _constructorVisibility = ConstructorVisibility.Default;
            private TypeInfo _inheritedType;
            private ValuePropertyCollection _valueProperties = new ValuePropertyCollection();
            private ChildPropertyCollection _childProperties = new ChildPropertyCollection();
            private ChildPropertyCollection _childCollectionProperties = new ChildPropertyCollection();
            private ConvertValuePropertyCollection _convertValueProperties = new ConvertValuePropertyCollection();
            private UpdateValuePropertyCollection _updateValueProperties = new UpdateValuePropertyCollection();
            private ValuePropertyCollection _inheritedValueProperties;
            private ChildPropertyCollection _inheritedChildProperties;
            private ChildPropertyCollection _inheritedChildCollectionProperties;
            private CriteriaCollection _criteriaObjects = new CriteriaCollection();
            private PropertyCollection _equalsProperty = new PropertyCollection();
            private PropertyCollection _hashcodeProperty = new PropertyCollection();
            private PropertyCollection _toStringProperty = new PropertyCollection();
            private PropertyCollection _findMethodsParameters = new PropertyCollection();
            private string _selectProcedureName = String.Empty;
            private string _insertProcedureName = String.Empty;
            private string _updateProcedureName = String.Empty;
            private string _deleteProcedureName = String.Empty;
            private string _dbName = String.Empty;
            private string _itemType = String.Empty;
            private string _updaterType = String.Empty;
            private string _parentType = String.Empty;
            private string _fileName = String.Empty;
            private string _nameColumn = String.Empty;
            private string _valueColumn = String.Empty;
            private bool _lazyLoad = false;
            private bool _generateSprocs = true;
            private PropertyCollection _parentProperties = new PropertyCollection();
            private string _getRoles = String.Empty;
            private string _newRoles = String.Empty;
            private string _updateRoles = String.Empty;
            private string _deleteRoles = String.Empty;
            private bool _parentInsertOnly = false;
            private string _publishToChannel = String.Empty;
            private string _subscribeToChannel = String.Empty;
            private bool _allowNew = true;
            private bool _allowEdit = true;
            private bool _allowRemove = true;
            private bool _generateFactoryMethods = true;
            private bool _generateDataPortalInsert = true;
            private bool _generateDataPortalUpdate = true;
            private bool _supportUpdateProperties = false;
            private bool _addParentReference = false;
            private bool _useCustomLoading = false;
            private bool _checkRulesOnFetch = true;
            private bool _generateDataAccessRegion = true;
            private string _folder = String.Empty;
            private string[] _implements = new string[] { };
            private string[] _attributes = new string[] { };
            private string _classSummary = String.Empty;
            private string[] _namespaces = new string[] { };
            private bool _dataSetLoadingScheme = false;
            private bool _cacheResults = true;

            #endregion

            #region Constructors

            public CslaObjectInfo(CslaGeneratorUnit parent) : base(parent)
            {
                _inheritedType = new TypeInfo(this);
                _inheritedType.TypeChanged += new EventHandler(InheritedType_TypeChanged);

                _inheritedValueProperties = new ValuePropertyCollection(); //.ReadOnly(new ValuePropertyCollection());
                _inheritedChildProperties = new ChildPropertyCollection(); //.ReadOnly(new ChildPropertyCollection());
                _inheritedChildCollectionProperties = new ChildPropertyCollection(); //.ReadOnly(new ChildPropertyCollection());

                _valueProperties.ItemChanged += new PropertyNameChanged(vp_ItemChanged);
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

            public CslaObjectInfo() : this(null)
            {
            }

            #endregion

            #region Public Properties

            #region 00. Generate Options

            /// <summary>
            /// Whether or not this object should be generated when project is run in master template.
            /// </summary>
            [Category("00. Generate Options")]
            [Description("Whether or not this object should be generated when project is run in master template.")]
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

            /// <summary>
            /// Whether or not to generate factory methods for this object when it is run in the master template.
            /// </summary>
            [Category("00. Generate Options")]
            [Description("Whether or not to generate factory methods for this object when it is run in the master template.")]
            [UserFriendlyName("Generate Factory Methods")]
            public bool GenerateFactoryMethods
            {
                get { return _generateFactoryMethods; }
                set { _generateFactoryMethods = value; }
            }

            [Category("00. Generate Options")]
            [Description("Whether or not to generate DataPortal_* methods. If False these methods are not generated so that you can create your custom data access region.")]
            [UserFriendlyName("Generate Data Access Region")]
            public bool GenerateDataAccessRegion
            {
                get { return _generateDataAccessRegion; }
                set { _generateDataAccessRegion = value; }
            }

            [Category("00. Generate Options")]
            [Description("Whether or not to generate DataPortal_Insert method. If False these method is not generated so that you can create your custom data access region.")]
            [UserFriendlyName("Generate Insert() Method")]
            public bool GenerateDataPortalInsert
            {
                get { return _generateDataPortalInsert; }
                set { _generateDataPortalInsert = value; }
            }

            [Category("00. Generate Options")]
            [Description("Whether or not to generate DataPortal_Update method. If False these method is not generated so that you can create your custom data access region.")]
            [UserFriendlyName("Generate Update() Method")]
            public bool GenerateDataPortalUpdate
            {
                get { return _generateDataPortalUpdate; }
                set { _generateDataPortalUpdate = value; }
            }

            /// <summary>
            /// Whether or not to generate stored procedures for this object when it is run in the master template.
            /// </summary>
            [Category("00. Generate Options")]
            [Description("Whether or not to generate stored procedures for this object when it is run in the master template.")]
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

            /// <summary>
            /// Whether or not to generate (DataPortal_)Fetch methods. If True these methods are not generated so that you can create a custom loading scheme.
            /// </summary>
            [Category("00. Generate Options")]
            [Description("Whether or not to generate (DataPortal_)Fetch methods. If True these methods are not generated so that you can create a custom loading scheme.")]
            [UserFriendlyName("Use Custom Loading")]
            public bool UseCustomLoading
            {
                get { return _useCustomLoading; }
                set { _useCustomLoading = value; }
            }

            /// <summary>
            /// Whether or not to check rules on (DataPortal_)Fetch methods. This invokes all business (validation) rules for the business type.
            /// </summary>
            [Category("00. Generate Options")]
            [Description("Whether or not to check rules on (DataPortal_)Fetch methods. This invokes all business (validation) rules for the business type.")]
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

            /// <summary>
            /// The type of Csla object to create, e.g EditableRoot, EditableChild, etc...
            /// </summary>
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

            /// <summary>
            /// The class name of the Csla object.
            /// </summary>
            [Category("01. Common Options")]
            [Description("The class name of the Csla object.")]
            [UserFriendlyName("Object Name")]
            public string ObjectName
            {
                get { return _objectName; }
                set
                {
                    if (_objectName != value)
                    {
                        _objectName = value;
                        if (_fileName.Equals(String.Empty))
                            _fileName = value;
                        OnPropertyChanged("ObjectName");
                    }
                }
            }

            /// <summary>
            /// The Namespace the object will exist in.
            /// </summary>
            [Category("01. Common Options")]
            [Description("The Namespace the object will exist in.")]
            [UserFriendlyName("Object Namespace")]
            public string ObjectNamespace
            {
                get { return _objectNamespace; }
                set
                {
                    value = value.Trim().Replace("  ", " ").Replace(' ', '_');
                    _objectNamespace = value;
                }
            }

            /// <summary>
            /// The class summary documentation for the object.
            /// </summary>
            [Category("01. Common Options")]
            [Description("Class Summary documentation for the object. This shows on the first line, replacing the default object name.")]
            [Editor(typeof(XmlCommentEditor), typeof(UITypeEditor))]
            [UserFriendlyName("Class Summary")]
            public string ClassSummary
            {
                get { return _classSummary; }
                set
                {
                    value = value.Trim().Replace("  ", " ").Replace("\n\n", "\n").Replace("\n", "\r\n");
                    _classSummary = value;
                }
            }

            [Category("01. Common Options")]
            [Description("The Namespaces this class uses (\"using\" in C# or \"Imports\" in VB).")]
            [UserFriendlyName("Namespaces")]
            public string[] Namespaces
            {
                get { return _namespaces; }
                set
                {
                    if (value != null)
                        _namespaces = value;
                }
            }

            /// <summary>
            /// Gets or sets the attributes you want to add to this class.
            /// </summary>
            /// <value>The attributes.</value>
            [Category("01. Common Options")]
            [Description("The attributes you want to add to this class.")]
            [UserFriendlyName("Attributes")]
            public string[] Attributes
            {
                get { return _attributes; }
                set
                {
                    if (value != null)
                        _attributes = value;
                }
            }

            [Category("01. Common Options")]
            [Description("The interfaces this class implements.")]
            [UserFriendlyName("Interfaces")]
            public string[] Implements
            {
                get { return _implements; }
                set
                {
                    if (value != null)
                        _implements = value;
                }
            }

            /// <summary>
            /// The type that this object inherits from.  You can either select
            /// an object defined in the current project or an object defined
            /// in another assembly.  The object you inherit from must inherit
            /// from a valid Csla base object.
            /// </summary>
            [Category("01. Common Options")]
            [Description("The type that this object inherits from.  You can either select an object defined in the current project or an object defined in another assembly.  The object you inherit from must inherit from a valid Csla base object.")]
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
                            _inheritedType.TypeChanged -= new EventHandler(InheritedType_TypeChanged);
                        _inheritedType = value;
                        _inheritedType.TypeChanged += new EventHandler(InheritedType_TypeChanged);
                        //SetInheritedProperties(_inheritedType);
                    }
                }
            }

            /// <summary>
            /// Wheter the constructor is private, protected, etc... Defaults to private.
            /// </summary>
            [Category("01. Common Options")]
            [Description("Wheter the constructor is private, protected, etc.\r\nDefaults to private.")]
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
                set { _folder = value; }
            }

            /// <summary>
            /// The name of the source file for the object.
            /// If no file extension is given, it default to .cs.
            /// </summary>
            [Category("01. Common Options")]
            [Description("The name of the source file for the object. If no file extension is given, it defaults according to the Output Code Language for this object.")]
            [UserFriendlyName("File Name")]
            public string FileName
            {
                get { return _fileName; }
                set
                {
                    _fileName = value;
                    if (_objectName.Equals(String.Empty))
                        _objectName = value;
                }
            }

            /// <summary>
            /// The code language that the object should be generated in.
            /// </summary>
/*            [Category("01. Common Options")]
            [Description("The code language that the object should be generated in.")]
            [UserFriendlyName("Output Code Language")]*/
            [Browsable(false)]
            public CodeLanguage OutputLanguage
            {
                get { return Parent.GenerationParams.OutputLanguage; }
                set { _outputLanguage = value; }
            }

            #endregion

            #region 02. Business Properties

            /// <summary>
            /// The child collection properties of the object.
            /// </summary>
            [Category("02. Business Properties")]
            [Description("The child collection properties of the object (specify here the child collections).")]
            [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
            [UserFriendlyName("Child Collection Properties")]
            public ChildPropertyCollection ChildCollectionProperties
            {
                get { return _childCollectionProperties; }
            }

            /// <summary>
            /// The non-collection child properties of the object.
            /// </summary>
            [Category("02. Business Properties")]
            [Description("The non-collection child properties of the object (specify here the child objects).")]
            [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
            [UserFriendlyName("Non-collection Child Properties")]
            public ChildPropertyCollection ChildProperties
            {
                get { return _childProperties; }
            }

            /// <summary>
            /// If this object inherits from another type, this
            /// property will store the child collection properties it inherits.
            /// You cannot add or remove inherited properties, but you
            /// can modify them.
            /// </summary>
            [Category("02. Business Properties")]
            [Description("If this object inherits from another type, this property will store the child collection properties it inherits. You cannot add or remove inherited properties, but you can modify them.")]
            [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
            [UserFriendlyName("Inherited Child Collection Properties")]
            public ChildPropertyCollection InheritedChildCollectionProperties
            {
                get { return _inheritedChildCollectionProperties; }
            }

            /// <summary>
            /// If this object inherits from another type, this
            /// property will store the non-collection child properties it inherits.
            /// You cannot add or remove inherited properties, but you
            /// can modify them.
            /// </summary>
            [Category("02. Business Properties")]
            [Description("If this object inherits from another type, this property will store the non-collection child properties it inherits.You cannot add or remove inherited properties, but you can modify them.")]
            [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
            [UserFriendlyName("Inherited Child Properties")]
            public ChildPropertyCollection InheritedChildProperties
            {
                get { return _inheritedChildProperties; }
            }

            /// <summary>
            /// Child properties that convert to/from other properties of the same object.
            /// </summary>
            // Hide AllChildProperties
            [Browsable(false)]
            public ChildPropertyCollection AllChildProperties
            {
                get { return GetMyChildProperties(); }
            }

            /// <summary>
            /// Value properties that convert to/from other properties of the same object.
            /// </summary>
            [Category("02. Business Properties")]
            [Description("Value properties that convert to/from other properties of the same object.")]
            [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
            [UserFriendlyName("Convert Value Properties")]
            public ConvertValuePropertyCollection ConvertValueProperties
            {
                get { return _convertValueProperties; }
            }

            /// <summary>
            /// Value properties of this object that are updated when another object saves itself.
            /// </summary>
            [Category("02. Business Properties")]
            [Description("Value properties of this object that are updated when another object saves itself.")]
            [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
            [UserFriendlyName("Update Value Properties")]
            public UpdateValuePropertyCollection UpdateValueProperties
            {
                get { return _updateValueProperties; }
            }

            /// <summary>
            /// If this object inherits from another type, this
            /// property will store the business properties it inherits.
            /// You cannot add or remove inherited properties, but you
            /// can modify them.
            /// </summary>
            [Category("02. Business Properties")]
            [Description("If this object inherits from another type, this property will store the business properties it inherits. You cannot add or remove inherited properties, but you can modify them.")]
            [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
            [UserFriendlyName("Inherited Value Properties")]
            public ValuePropertyCollection InheritedValueProperties
            {
                get { return _inheritedValueProperties; }
            }

            /// <summary>
            /// The business properties of the object.
            /// NOTE: When adding BrokenRules, use the property name
            /// to create your AssertExpression, e.g., Amount > 0
            /// </summary>
            [Category("02. Business Properties")]
            [Description("The business properties of the object. NOTE: When adding BrokenRules, use the property name to create your AssertExpression, e.g., Amount > 0")]
            [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
            [UserFriendlyName("Value Properties")]
            public ValuePropertyCollection ValueProperties
            {
                get { return _valueProperties; }
            }

            /// <summary>
            /// Value properties that convert to/from other properties of the same object.
            /// </summary>
            // Hide AllValueProperties
            [Browsable(false)]
            public ValuePropertyCollection AllValueProperties
            {
                get { return GetMyValueProperties(); }
            }

            #endregion

            #region 03. Criteria

            /// <summary>
            /// The Criteria classes that will be nested in the object.
            /// </summary>
            [Category("03. Criteria")]
            [Description("The Criteria classes that will be nested in the object.")]
            [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
            [UserFriendlyName("Criteria Objects")]
            public CriteriaCollection CriteriaObjects
            {
                get { return _criteriaObjects; }
            }

            #endregion

            #region 04. Child Object Options

            /// <summary>
            /// The object type of the of this object's parent.
            /// </summary>
            [Category("04. Child Object Options")]
            [Description("The object type of the of this object's parent (specify the collection name for an item, or object name for a collection).")]
            [UserFriendlyName("Parent Type")]
            [Editor(typeof(ParentTypeEditor), typeof(UITypeEditor))]
            public string ParentType
            {
                get { return _parentType; }
                set
                {
                    if (_parentType != this.ObjectName) //make sure we don't set ourselves as parent, just in case.
                        _parentType = value;
                    else
                        _parentType = string.Empty;
                }
            }

            /// <summary>
            /// Parent properties which are used in Update method, as parameters for Stored Procedures.
            /// </summary>
            [Category("04. Child Object Options")]
            [Description("Parent properties which are used in Update method, as parameters for Stored Procedures.")]
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
            [Category("04. Child Object Options")]
            [Description("The parent only does inserts. Prevents the parent property from participating in updates or deletes.")]
            [UserFriendlyName("Parent Insert Only")]
            public bool ParentInsertOnly
            {
                get { return _parentInsertOnly; }
                set { _parentInsertOnly = value; }
            }

            /// <summary>
            /// Whether or not this object should be "lazy loaded" when it is a child.
            /// "lazy loading" is when the child objects are not loaded when the parent
            /// object is loaded and are only loaded when they are referenced.
            /// </summary>
            [Category("04. Child Object Options")]
            [Description("Whether or not this object should be \"lazy loaded\" when it is a child.  \"Lazy loading\" means the child objects are not loaded when the parent object is loaded and are only loaded when they are referenced.")]
            [UserFriendlyName("Lazy Load")]
            public bool LazyLoad
            {
                get { return _lazyLoad; }
                set { _lazyLoad = value; }
            }

            #endregion

            #region 05. Collection Options

            /// <summary>
            /// The type name of the objects the collection will hold.
            /// </summary>
            [Category("05. Collection Options")]
            [Description("The type name of the objects the collection will hold.")]
            [UserFriendlyName("Item Type")]
            [Editor(typeof(ItemTypeEditor), typeof(UITypeEditor))]
            public string ItemType
            {
                get { return _itemType; }
                set { _itemType = value; }
            }

            /// <summary>
            /// For each parameter you select, a find method will be created
            /// which uses that parameter to find an object in the collection.
            /// </summary>
            [Category("05. Collection Options")]
            [Description("For each parameter you select, a find method will be created which uses that parameter to find an object in the collection.")]
            [Editor(typeof(FMPropertyCollectionEditor), typeof(UITypeEditor))]
            [TypeConverter(typeof(PropertyCollectionConverter))]
            [UserFriendlyName("Find Methods Parameters")]
            public PropertyCollection FindMethodsParameters
            {
                get { return _findMethodsParameters; }
                set { _findMethodsParameters = value; }
            }

            /// <summary>
            /// The type name of the object that will update this collection.
            /// </summary>
            [Category("05. Collection Options")]
            [Description("The type name of the object that will update objects of this collection.")]
            [UserFriendlyName("Updater Type")]
            [Editor(typeof(UpdaterTypeEditor), typeof(UITypeEditor))]
            public string UpdaterType
            {
                get { return _updaterType; }
                set { _updaterType = value; }
            }

            [Category("05. Collection Options")]
            [Description("Whether the collection allows adding new items through BindingList Methods. "+
                "If true, \"New Roles\" authz rules can restrict user rights.")]
            [UserFriendlyName("Allow New")]
            public bool AllowNew
            {
                get { return _allowNew; }
                set { _allowNew = value; }
            }

            [Category("05. Collection Options")]
            [Description("Whether the collection allows editing items through BindingList Methods. " +
                "If true, \"Update Roles\" authz rules can restrict user rights.")]
            [UserFriendlyName("Allow Edit")]
            public bool AllowEdit
            {
                get { return _allowEdit; }
                set { _allowEdit = value; }
            }

            [Category("05. Collection Options")]
            [Description("Whether the collection allows removing items through BindingList Methods. " +
                "If true, \"Delete Roles\" authz rules can restrict user rights.")]
            [UserFriendlyName("Allow Remove")]
            public bool AllowRemove
            {
                get { return _allowRemove; }
                set { _allowRemove = value; }
            }

            [Category("05. Collection Options")]
            [Description("Create a parent reference. This option is only available for child collections. When targeting CSLA40 this option is ignored ")]
            [UserFriendlyName("Add Parent Reference")]
            public bool AddParentReference
            {
                get { return _addParentReference; }
                set { _addParentReference = value; }
            }

            #endregion

            #region 06. NameValueList Info

            /// <summary>
            /// Name of the column that will be used as the name column in a NameValue List.
            /// </summary>
            [Category("06. NameValueList Info")]
            [Description("Name of the column that will be used as the value column in a NameValue List.")]
            [Editor(typeof(PropertyNameEditor), typeof(UITypeEditor))]
            [UserFriendlyName("Value Column")]
            public string NameColumn
            {
                get { return _nameColumn; }
                set { _nameColumn = value; }
            }

            /// <summary>
            /// Name of the column that will be used as the value column in a NameValue List.
            /// </summary>
            [Category("06. NameValueList Info")]
            [Description("Name of the column that will be used as the key column in a NameValue List.")]
            [Editor(typeof(PropertyNameEditor), typeof(UITypeEditor))]
            [UserFriendlyName("Key Column")]
            public string ValueColumn
            {
                get { return _valueColumn; }
                set { _valueColumn = value; }
            }

            /// <summary>
            /// Whether to cache the results of the fetch operation for the name value list or not.
            /// </summary>
            [Category("06. NameValueList Info")]
            [Description("Whether to cache the results of the fetch operation for the name value list or not. This will also generate an InvalidateAll method to clear the cache.")]
            [Editor(typeof(PropertyNameEditor), typeof(UITypeEditor))]
            [UserFriendlyName("Cache Results")]
            public bool CacheResults
            {
                get { return _cacheResults; }
                set { _cacheResults = value; }
            }

            #endregion

            #region 07. Data Access Options

            /// <summary>
            /// Name of the database alias used to get connection string from configuration file.
            /// </summary>
            [Category("07. Data Access Options")]
            [Description("Name of the database alias used to get connection string from configuration file.")]
            [UserFriendlyName("Database Name")]
            public string DbName
            {
                get { return _dbName; }
                set
                {
                    value = value.Trim().Replace("  ", " ").Replace(' ', '_');
                    _dbName = value;
                }
            }

            /// <summary>
            /// Persistence type to use for data access.
            /// </summary>
            [Category("07. Data Access Options")]
            [Description("Persistence type to use for data storage.")]
            [UserFriendlyName("Persistence Type")]
            public PersistenceType PersistenceType
            {
                get { return _persistenceType; }
                set { _persistenceType = value; }
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
                set { _dbContextObject = value; }
            }

            /// <summary>
            /// Transaction type to use for data access.
            /// </summary>
            [Category("07. Data Access Options")]
            [Description("Transaction type to use for data access.")]
            [UserFriendlyName("Transaction Type")]
            public TransactionType TransactionType
            {
                get { return _transactionType; }
                set
                {
                    if (value == TransactionType.TransactionalAttribute)
                        _transactionType = TransactionType.TransactionScope;
                    else
                        _transactionType = value;
                }
            }

            /// <summary>
            /// The type of the Criteria object to be passed to the DeleteObject method.
            /// </summary>
            [Category("07. Data Access Options")]
            [Description("The type of the Criteria object to be passed to the DeleteObject method.")]
            [Editor(typeof(CriteriaTypeEditor), typeof(UITypeEditor))]
            [TypeConverter(typeof(CriteriaTypeConverter))]
            [UserFriendlyName("Delete Object Criteria Type")]
            public Criteria DeleteObjectCriteriaType
            {
                get
                {
                    return null;
                    //if (_deleteObjectCriteriaType != null)
                    //{
                    //    //This is done for backwards compatibility
                    //    _deleteObjectCriteriaTypeName = _deleteObjectCriteriaType.Name;
                    //    _deleteObjectCriteriaType = null;
                    //}
                    //return _criteriaObjects.Find(_deleteObjectCriteriaTypeName);
                }
                set
                {
                    //if (value == null)
                    //    _deleteObjectCriteriaTypeName = String.Empty;
                    //else
                    //    _deleteObjectCriteriaTypeName = value.Name;
                    if (value != null)
                    {
                        Criteria c = _criteriaObjects.Find(value.Name);
                        if (c != null)
                        {
                            c.DeleteOptions.Factory = true;
                            c.DeleteOptions.DataPortal = true;
                            c.DeleteOptions.ProcedureName = _deleteProcedureName;
                            c.DeleteOptions.Procedure = true;
                        }
                    }
                }
            }

            /// <summary>
            /// The type of the Criteria object to be passed to the GetObject method.
            /// </summary>
            [Category("07. Data Access Options")]
            [Description("The type of the Criteria object to be passed to the GetObject method.")]
            [Editor(typeof(CriteriaTypeEditor), typeof(UITypeEditor))]
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

            /// <summary>
            /// The type of the Criteria object to be passed to the NewObject method.
            /// </summary>
            [Category("07. Data Access Options")]
            [Description("The type of the Criteria object to be passed to the NewObject method.")]
            [Editor(typeof(CriteriaTypeEditor), typeof(UITypeEditor))]
            [TypeConverter(typeof(CriteriaTypeConverter))]
            [UserFriendlyName("NewObject Criteria Type")]
            public Criteria NewObjectCriteriaType
            {
                get
                {
                    return null;
                    //if (_newObjectCriteriaType != null)
                    //{
                    //    //This is done for backwards compatibility
                    //    _newObjectCriteriaTypeName = _newObjectCriteriaType.Name;
                    //    _newObjectCriteriaType = null;
                    //}
                    //return _criteriaObjects.Find(_newObjectCriteriaTypeName);
                }
                set
                {
                    //if (value == null)
                    //    _newObjectCriteriaTypeName = String.Empty;
                    //else
                    //    _newObjectCriteriaTypeName = value.Name;
                    if (value != null)
                    {
                        Criteria c = _criteriaObjects.Find(value.Name);
                        if (c != null)
                        {
                            c.CreateOptions.Factory = true;
                            c.CreateOptions.DataPortal = true;
                            c.CreateOptions.RunLocal = true;
                        }
                    }
                }
            }

            #endregion

            #region 08. Stored Procedure Names

            /// <summary>
            /// Name of the insert procedure.
            /// </summary>
            [Category("08. Stored Procedure Names")]
            [Description("Name of the insert procedure.")]
            [UserFriendlyName("Insert Procedure Name")]
            public string InsertProcedureName
            {
                get { return _insertProcedureName; }
                set { _insertProcedureName = value; }
            }

            /// <summary>
            /// Name of the select procedure.
            /// </summary>
            [Category("08. Stored Procedure Names")]
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
                                c.GetOptions.ProcedureName = value;

                }
            }

            /// <summary>
            /// Name of the update procedure.
            /// </summary>
            [Category("08. Stored Procedure Names")]
            [Description("Name of the update procedure.")]
            [UserFriendlyName("Update Procedure Name")]
            public string UpdateProcedureName
            {
                get { return _updateProcedureName; }
                set { _updateProcedureName = value; }
            }

            /// <summary>
            /// Name of the delete procedure.
            /// </summary>
            [Category("08. Stored Procedure Names")]
            [Description("Name of the delete procedure.")]
            [UserFriendlyName("Delete Procedure Name")]
            public string DeleteProcedureName
            {
                get { return _deleteProcedureName; }
                set
                {
                    if (_objectType == CslaObjectType.EditableChild ||
                        _objectType == CslaObjectType.EditableSwitchable ||
                        _objectType == CslaObjectType.DynamicEditableRoot)
                        _deleteProcedureName = value;
                    else
                    {
                        if (!String.IsNullOrEmpty(value))
                            foreach (Criteria c in _criteriaObjects)
                                if (c.DeleteOptions.Procedure && string.IsNullOrEmpty(c.DeleteOptions.ProcedureName))
                                    c.DeleteOptions.ProcedureName = value;
                    }
                }
            }

            #endregion

            #region 09. System.Object Overrides

            /// <summary>
            /// The properties that will be used to create the object's hashcode.
            /// If multiple properties are selected the results of their GetHashCode
            /// methods are xor'd.  If none are selected, GetHashCode method is not overridden
            /// </summary>
            [Category("09. System.Object Overrides")]
            [Description("The properties that will be used to create the object's hashcode.  If multiple properties are selected the results of their GetHashCode methods are xor'd.  If none are selected, GetHashCode method is not overridden")]
            [Editor(typeof(PropertyCollectionEditor), typeof(UITypeEditor))]
            [TypeConverter(typeof(PropertyCollectionConverter))]
            [UserFriendlyName("Hashcode Property")]
            public PropertyCollection HashcodeProperty
            {
                get { return _hashcodeProperty; }
                set { _hashcodeProperty = value; }
            }

            /// <summary>
            /// The properties that will be used to check object equivalence.
            /// If none are selected, Equals method is not overridden
            /// </summary>
            [Category("09. System.Object Overrides")]
            [Description("The properties that will be used to check object equivalence.  If none are selected, Equals method is not overridden")]
            [Editor(typeof(PropertyCollectionEditor), typeof(UITypeEditor))]
            [TypeConverter(typeof(PropertyCollectionConverter))]
            [UserFriendlyName("Equals Property")]
            public PropertyCollection EqualsProperty
            {
                get { return _equalsProperty; }
                set { _equalsProperty = value; }
            }

            /// <summary>
            /// The properties that will be used to create a string from the object's ToString property.
            /// If multiple properties are selected, they are concatenated.
            /// If none are selected, ToString method is not overridden
            /// </summary>
            [Category("09. System.Object Overrides")]
            [Description("The properties that will be used to create a string from the object's ToString property.  If multiple properties are selected, they are concatenated.  If none are selected, ToString method is not overridden")]
            [Editor(typeof(PropertyCollectionEditor), typeof(UITypeEditor))]
            [TypeConverter(typeof(PropertyCollectionConverter))]
            [UserFriendlyName("ToString Property")]
            public PropertyCollection ToStringProperty
            {
                get { return _toStringProperty; }
                set { _toStringProperty = value; }
            }

            #endregion

            #region 10. Authorization

            /// <summary>
            /// Roles to create object. Multiple roles must be separated with ;.
            /// </summary>
            [Category("10. Authorization")]
            [Description("Roles to create object. Multiple roles must be separated with \";\". Use no prefix to allow or use prefix \"!\" to deny.")]
            [UserFriendlyName("New Roles")]
            public string NewRoles
            {
                get { return _newRoles; }
                set { _newRoles = value; }
            }

            /// <summary>
            /// Roles to retrieve object. Multiple roles must be separated with ;.
            /// </summary>
            [Category("10. Authorization")]
            [Description("Roles to retrieve object. Multiple roles must be separated with \";\". Use no prefix to allow or use prefix \"!\" to deny.")]
            [UserFriendlyName("Get Roles")]
            public string GetRoles
            {
                get { return _getRoles; }
                set { _getRoles = value; }
            }

            /// <summary>
            /// Roles to update object. Multiple roles must be separated with ;.
            /// </summary>
            [Category("10. Authorization")]
            [Description("Roles to update object. Multiple roles must be separated with \";\". Use no prefix to allow or use prefix \"!\" to deny.")]
            [UserFriendlyName("Update Roles")]
            public string UpdateRoles
            {
                get { return _updateRoles; }
                set { _updateRoles = value; }
            }

            /// <summary>
            /// Roles to delete object. Multiple roles must be separated with ;.
            /// </summary>
            [Category("10. Authorization")]
            [Description("Roles to delete object. Multiple roles must be separated with \";\". Use no prefix to allow or use prefix \"!\" to deny.")]
            [UserFriendlyName("Delete Roles")]
            public string DeleteRoles
            {
                get { return _deleteRoles; }
                set { _deleteRoles = value; }
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

            [Browsable(false)]
            public bool HasGetCriteria
            {
                get
                {
                    foreach (Criteria c in _criteriaObjects)
                    {
                        if (c.GetOptions.DataPortal || c.GetOptions.Factory)
                            return true;
                    }
                    return false;
                }
            }

            [Browsable(false)]
            public bool HasNullableProperties
            {
                get
                {
                    foreach (ValueProperty p in GetAllValueProperties())
                    {
                        if (p.Nullable)
                            return true;
                    }
                    foreach (Criteria c in CriteriaObjects)
                    {
                        foreach (Property p in c.Properties)
                        {
                            if (p.Nullable)
                                return true;
                        }
                    }
                    return false;
                }
            }

            #endregion

            #region Event Handlers

            public void InheritedType_TypeChanged(object sender, EventArgs e)
            {
                TypeInfo t = (TypeInfo)sender;
                if (t.Type != String.Empty)
                {
                    //ValidateType(t.GetInheritedType());
                }
                //SetInheritedProperties(t);
            }

            #endregion

            #region Private Methods

            //private void ValidateType(Type t)
            //{
            //    if (t == null)
            //    {
            //        _inheritedType.Type = null;

            //    }
            //    else if (t.IsSubclassOf(typeof(Csla.BusinessBase)))
            //    {
            //        if (_objectType != CslaObjectType.EditableChild &&
            //            _objectType != CslaObjectType.EditableRoot &&
            //            _objectType != CslaObjectType.EditableSwitchable)
            //        {
            //            _objectType = CslaObjectType.EditableRoot;
            //            throw new InvalidOperationException("Object inherits from BusinessBase. It must therefore have a type of EditableRoot, EditableChild, or EditableSwitchable.");
            //        }
            //    }
            //    else if (t.IsSubclassOf(typeof(Csla.BusinessCollectionBase)))
            //    {
            //        if (_objectType != CslaObjectType.EditableChildCollection &&
            //            _objectType != CslaObjectType.EditableRootCollection)
            //        {
            //            _objectType = CslaObjectType.EditableRootCollection;
            //            throw new InvalidOperationException("Object inherits from BusinessCollectionBase. It must therefore have a type of EditableRootCollection or EditableChildCollection.");
            //        }
            //    }
            //    else if (t.IsSubclassOf(typeof(Csla.ReadOnlyBase)))
            //    {
            //        if (_objectType != CslaObjectType.ReadOnlyObject)
            //        {
            //            _objectType = CslaObjectType.ReadOnlyObject;
            //            throw new InvalidOperationException("Object inherits from ReadOnlyBase. It must therefore have a type of ReadOnlyObject.");
            //        }
            //    }
            //    else if (t.IsSubclassOf(typeof(Csla.ReadOnlyCollectionBase)))
            //    {
            //        if (_objectType != CslaObjectType.ReadOnlyCollection)
            //        {
            //            _objectType = CslaObjectType.ReadOnlyCollection;
            //            throw new InvalidOperationException("Object inherits from ReadOnlyBase. It must therefore have a type of ReadOnlyCollection.");
            //        }
            //    }
            //    else
            //    {
            //        _inheritedType.Type = null;
            //        throw new InvalidOperationException("Object must inherit from a valid Csla object.");
            //    }
            //}

            //private void SetInheritedProperties(TypeInfo typeInfo)
            //{
            //    ValuePropertyCollection valueProps = new ValuePropertyCollection();
            //    ChildPropertyCollection childProps = new ChildPropertyCollection();
            //    ChildPropertyCollection childCollProps = new ChildPropertyCollection();

            //    if (typeInfo.Type != String.Empty)
            //    {
            //        Type type = typeInfo.GetInheritedType();
            //        PropertyInfo[] props = type.GetProperties();
            //        for (int i = 0; i < props.Length; i++)
            //        {
            //            if (props[i].PropertyType.IsSubclassOf(typeof(Csla.BusinessBase)) ||
            //                props[i].PropertyType.IsSubclassOf(typeof(Csla.ReadOnlyBase)))
            //            {
            //                childProps.Add(GetChildPropertyFromInfo(props[i]));
            //            }
            //            else if (props[i].PropertyType.IsSubclassOf(typeof(Csla.BusinessCollectionBase)) ||
            //                props[i].PropertyType.IsSubclassOf(typeof(Csla.ReadOnlyCollectionBase)))
            //            {
            //                childCollProps.Add(GetChildPropertyFromInfo(props[i]));
            //            }
            //            else if (props[i].PropertyType.IsPrimitive || props[i].PropertyType == typeof(string))
            //            {
            //                if (props[i].Name != "IsDeleted" && props[i].Name != "IsDirty" &&
            //                    props[i].Name != "IsNew" && props[i].Name != "IsValid" &&
            //                    props[i].Name != "IsSavable" && props[i].Name != "BrokenRulesString" &&
            //                    props[i].Name != "Count" && props[i].Name != "IsChild")
            //                {
            //                    valueProps.Add(GetValuePropertyFromInfo(props[i]));
            //                }
            //            }
            //        }
            //    }
            //    else if (typeInfo.ObjectMetadata != null)
            //    {
            //        do
            //        {
            //            foreach (ValueProperty prop in typeInfo.ObjectMetadata.ValueProperties)
            //            {
            //                valueProps.Add((ValueProperty)prop.Clone());
            //            }
            //            foreach (ChildProperty prop in typeInfo.ObjectMetadata.ChildProperties)
            //            {
            //                childProps.Add((ChildProperty)prop.Clone());
            //            }
            //            foreach (ChildProperty prop in typeInfo.ObjectMetadata.ChildCollectionProperties)
            //            {
            //                childCollProps.Add((ChildProperty)prop.Clone());
            //            }
            //            typeInfo = typeInfo.ObjectMetadata.InheritedType;
            //        } while (typeInfo.ObjectMetadata != null);
            //    }

            //    _inheritedValueProperties = valueProps; //ValuePropertyCollection.ReadOnly(valueProps);
            //    _inheritedChildProperties = childProps; //ChildPropertyCollection.ReadOnly(childProps);
            //    _inheritedChildCollectionProperties = childCollProps; //ChildPropertyCollection.ReadOnly(childCollProps);

            //    if (GeneratorController.Schema != null)
            //    {
            //        foreach (ValueProperty prop in _inheritedValueProperties)
            //        {
            //            prop.DbBindColumn.LoadColumn(GeneratorController.Schema);
            //        }
            //    }
            //}

            private ValueProperty GetValuePropertyFromInfo(PropertyInfo info)
            {
                ValueProperty prop = new ValueProperty();
                prop.Name = info.Name;
                prop.PropertyType = TypeHelper.GetTypeCodeEx(info.PropertyType);

                return prop;
            }

            private ChildProperty GetChildPropertyFromInfo(PropertyInfo info)
            {
                ChildProperty prop = new ChildProperty();
                prop.Name = info.Name;
                prop.TypeName = info.PropertyType.FullName;
                prop.LoadingScheme = LoadingScheme.ParentLoad;
                return prop;
            }

            internal void SetProcedureNames()
            {
                if (Parent == null)
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
                foreach (Criteria c in _criteriaObjects)
                {
                    c.SetSprocNames();
                }
            }

            #endregion

            #region Events

            /*[field: NonSerialized]
            public event EventHandler ObjectNameChanged;

            protected void OnObjectNameChanged()
            {
                SetProcedureNames();
                if (ObjectNameChanged != null)
                {
                    ObjectNameChanged(this, EventArgs.Empty);
                }
            }

            [field: NonSerialized]
            public event EventHandler ObjectTypeChanged;

            protected void OnObjectTypeChanged()
            {
                if (ObjectTypeChanged != null)
                {
                    ObjectTypeChanged(this, EventArgs.Empty);
                }
            }

            [field: NonSerialized]
            public event EventHandler SelectProcedureChanged;

            protected void OnSelectProcedureChanged()
            {
                if (SelectProcedureChanged != null)
                {
                    SelectProcedureChanged(this, EventArgs.Empty);
                }
            }

            [field: NonSerialized]
            public event EventHandler InsertProcedureChanged;

            protected void OnInsertProcedureChanged()
            {
                if (InsertProcedureChanged != null)
                {
                    InsertProcedureChanged(this, EventArgs.Empty);
                }
            }

            [field: NonSerialized]
            public event EventHandler UpdateProcedureChanged;

            protected void OnUpdateProcedureChanged()
            {
                if (UpdateProcedureChanged != null)
                {
                    UpdateProcedureChanged(this, EventArgs.Empty);
                }
            }

            [field: NonSerialized]
            public event EventHandler DeleteProcedureChanged;

            protected void OnDeleteProcedureChanged()
            {
                if (DeleteProcedureChanged != null)
                {
                    DeleteProcedureChanged(this, EventArgs.Empty);
                }
            }*/

            #endregion

            #region Public Methods

            public CslaObjectInfo Duplicate(ICatalog catalog)
            {
                MemoryStream buffer = new MemoryStream();
                XmlSerializer ser = new XmlSerializer(typeof(CslaObjectInfo));
                ser.Serialize(buffer, this);
                buffer.Position = 0;
                CslaObjectInfo duplicate = (CslaObjectInfo)ser.Deserialize(buffer);
                if (catalog != null)
                {
                    duplicate.LoadColumnInfo(catalog);
                }
                duplicate.Parent = base.Parent;
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

            public ValuePropertyCollection GetAllValueProperties()
            {
                ValuePropertyCollection allValueProperties = new ValuePropertyCollection();

                allValueProperties.AddRange(this._valueProperties);
                allValueProperties.AddRange(this._inheritedValueProperties);

                return allValueProperties;
            }

            public ValuePropertyCollection GetParentValueProperties()
            {
                ValuePropertyCollection parentValueProperties = new ValuePropertyCollection();
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

            public CslaObjectInfo FindParent(CslaObjectInfo childInfo)
            {
                //cloned from sp template helper
                CslaObjectInfo info = childInfo.Parent.CslaObjects.Find(childInfo.ParentType);
                if (info != null)
                {
                    if (info.ItemType == childInfo.ObjectName)
                    {
                        return FindParent(info);
                    }
                    else if (info.GetAllChildProperties().FindType(childInfo.ObjectName) != null)
                    {
                        return info;
                    }
                    else if (info.GetCollectionChildProperties().FindType(childInfo.ObjectName) != null)
                    {
                        return info;
                    }
                }
                return null;
            }

            public ChildPropertyCollection GetMyChildProperties()
            {
                ChildPropertyCollection myChildProperties = new ChildPropertyCollection();

                myChildProperties.AddRange(_childProperties);
                myChildProperties.AddRange(_childCollectionProperties);

                return myChildProperties;
            }

            public ValuePropertyCollection GetMyValueProperties()
            {
                ValuePropertyCollection myValueProperties = new ValuePropertyCollection();

                myValueProperties.AddRange(_valueProperties);
                myValueProperties.AddRange(ConvertToValuePropertyCollection(_convertValueProperties));

                return myValueProperties;
            }

            private ValuePropertyCollection ConvertToValuePropertyCollection(ConvertValuePropertyCollection convertValuePropertyCollection)
            {
                ValuePropertyCollection valuePropertyCollection = new ValuePropertyCollection();
                foreach (ConvertValueProperty convertValueProperty in convertValuePropertyCollection)
                {
                    ValueProperty valueProperty = convertValueProperty;
                    valuePropertyCollection.Add(valueProperty);
                }
                return valuePropertyCollection;
            }

            public ChildPropertyCollection GetInheritedChildProperties()
            {
                ChildPropertyCollection inheritedChildProperties = new ChildPropertyCollection();

                inheritedChildProperties.AddRange(this._inheritedChildProperties);
                inheritedChildProperties.AddRange(this._inheritedChildCollectionProperties);

                return inheritedChildProperties;
            }

            public ChildPropertyCollection GetAllChildProperties()
            {
                ChildPropertyCollection allChildProperties = new ChildPropertyCollection();

                allChildProperties.AddRange(this._childProperties);
                allChildProperties.AddRange(this._childCollectionProperties);
                allChildProperties.AddRange(this._inheritedChildProperties);
                allChildProperties.AddRange(this._inheritedChildCollectionProperties);

                return allChildProperties;
            }
            public ChildPropertyCollection GetNonCollectionChildProperties()
            {
                ChildPropertyCollection _myChildProps = new ChildPropertyCollection();

                _myChildProps.AddRange(this._childProperties);
                _myChildProps.AddRange(this._inheritedChildProperties);

                return _myChildProps;
            }
            public ChildPropertyCollection GetCollectionChildProperties()
            {
                ChildPropertyCollection _myChildProps = new ChildPropertyCollection();

                _myChildProps.AddRange(this._childCollectionProperties);
                _myChildProps.AddRange(this._inheritedChildCollectionProperties);

                return _myChildProps;
            }

            #endregion

            private void vp_ItemChanged(ValueProperty sender, PropertyNameChangedEventArgs e)
            {
                foreach (Criteria c in this._criteriaObjects)
                {
                    HandleNameChanged(c.Properties, e);
                }
                HandleNameChanged(_toStringProperty, e);
                HandleNameChanged(_equalsProperty, e);
                HandleNameChanged(_hashcodeProperty, e);
            }
            void HandleNameChanged(PropertyCollection col, PropertyNameChangedEventArgs e)
            {
                foreach (Property p in col)
                {
                    if (p.Name.Equals(e.OldName))
                        p.Name = e.NewName;
                }
            }
            void HandleNameChanged(CriteriaPropertyCollection col, PropertyNameChangedEventArgs e)
            {
                foreach (Property p in col)
                {
                    if (p.Name.Equals(e.OldName))
                        p.Name = e.NewName;
                }
            }
            //void HandleNameChanged(ParameterCollection col, PropertyNameChangedEventArgs e)
            //{
            //    foreach (Parameter p in col)
            //    {
            //        if (p.Property.Name.Equals(e.OldName))
            //            p.Property.Name = e.NewName;
            //        HandleNameChanged(p.Criteria.Properties, e);
            //    }
            //}

            #region System.Object Overrides

            public override string ToString()
            {
                return _objectName;
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(obj,this))
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
                if (propertyName == "ObjectName")
                    SetProcedureNames();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion

        }
    }
