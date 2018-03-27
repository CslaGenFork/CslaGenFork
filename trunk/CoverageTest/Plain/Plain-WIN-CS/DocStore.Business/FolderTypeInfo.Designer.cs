//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    FolderTypeInfo
// ObjectType:  FolderTypeInfo
// CSLAType:    ReadOnlyObject

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace DocStore.Business
{

    /// <summary>
    /// Folder type basic information (read only object).<br/>
    /// This is a generated <see cref="FolderTypeInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="FolderTypeList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class FolderTypeInfo : ReadOnlyBase<FolderTypeInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="FolderTypeID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> FolderTypeIDProperty = RegisterProperty<int>(p => p.FolderTypeID, "Folder Type ID", -1);
        /// <summary>
        /// Gets the Folder Type ID.
        /// </summary>
        /// <value>The Folder Type ID.</value>
        public int FolderTypeID
        {
            get { return GetProperty(FolderTypeIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FolderTypeName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FolderTypeNameProperty = RegisterProperty<string>(p => p.FolderTypeName, "Folder Type Name");
        /// <summary>
        /// Gets the Folder Type Name.
        /// </summary>
        /// <value>The Folder Type Name.</value>
        public string FolderTypeName
        {
            get { return GetProperty(FolderTypeNameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="IsActive"/> property.
        /// </summary>
        public static readonly PropertyInfo<bool> IsActiveProperty = RegisterProperty<bool>(p => p.IsActive, "IsActive");
        /// <summary>
        /// Gets the active or deleted state.
        /// </summary>
        /// <value><c>true</c> if IsActive; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return GetProperty(IsActiveProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="FolderTypeInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="FolderTypeInfo"/> object.</returns>
        internal static FolderTypeInfo GetFolderTypeInfo(SafeDataReader dr)
        {
            FolderTypeInfo obj = new FolderTypeInfo();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderTypeInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FolderTypeInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (FolderTypeInfo), new IsInRole(AuthorizationActions.GetObject, "User"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can retrieve FolderTypeInfo's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(FolderTypeInfo));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="FolderTypeInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(FolderTypeIDProperty, dr.GetInt32("FolderTypeID"));
            LoadProperty(FolderTypeNameProperty, dr.GetString("FolderTypeName"));
            LoadProperty(IsActiveProperty, dr.GetBoolean("IsActive"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
