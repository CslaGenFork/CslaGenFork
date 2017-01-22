//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocContentRO
// ObjectType:  DocContentRO
// CSLAType:    ReadOnlyObject

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using UsingLibrary;

namespace DocStore.Business
{

    /// <summary>
    /// Document files (read only object).<br/>
    /// This is a generated base class of <see cref="DocContentRO"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="Doc"/> collection.
    /// </remarks>
    [Serializable]
    public partial class DocContentRO : ReadOnlyBase<DocContentRO>, IHaveInterface, IHaveGenericInterface<DocContentRO>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocContentID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> DocContentIDProperty = RegisterProperty<int>(p => p.DocContentID, "Doc Content ID", -1);
        /// <summary>
        /// Gets the Doc Content ID.
        /// </summary>
        /// <value>The Doc Content ID.</value>
        public int DocContentID
        {
            get { return GetProperty(DocContentIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Version"/> property.
        /// </summary>
        public static readonly PropertyInfo<short> VersionProperty = RegisterProperty<short>(p => p.Version, "Version");
        /// <summary>
        /// Gets the Version.
        /// </summary>
        /// <value>The Version.</value>
        public short Version
        {
            get { return GetProperty(VersionProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FileSize"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> FileSizeProperty = RegisterProperty<int>(p => p.FileSize, "File Size");
        /// <summary>
        /// Gets the File Size.
        /// </summary>
        /// <value>The File Size.</value>
        public int FileSize
        {
            get { return GetProperty(FileSizeProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FileType"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FileTypeProperty = RegisterProperty<string>(p => p.FileType, "File Type");
        /// <summary>
        /// Gets the File Type.
        /// </summary>
        /// <value>The File Type.</value>
        public string FileType
        {
            get { return GetProperty(FileTypeProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CheckInDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CheckInDateProperty = RegisterProperty<SmartDate>(p => p.CheckInDate, "Check In Date");
        /// <summary>
        /// Check-in date
        /// </summary>
        /// <value>The Check In Date.</value>
        public string CheckInDate
        {
            get { return GetPropertyConvert<SmartDate, string>(CheckInDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CheckInUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CheckInUserIDProperty = RegisterProperty<int>(p => p.CheckInUserID, "Check In User ID");
        /// <summary>
        /// Check-in user ID
        /// </summary>
        /// <value>The Check In User ID.</value>
        public int CheckInUserID
        {
            get { return GetProperty(CheckInUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CheckInComment"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> CheckInCommentProperty = RegisterProperty<string>(p => p.CheckInComment, "Check In Comment");
        /// <summary>
        /// Check-in comment
        /// </summary>
        /// <value>The Check In Comment.</value>
        public string CheckInComment
        {
            get { return GetProperty(CheckInCommentProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CheckOutDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CheckOutDateProperty = RegisterProperty<SmartDate>(p => p.CheckOutDate, "Check Out Date", new SmartDate(true));
        /// <summary>
        /// Check-out date
        /// </summary>
        /// <value>The Check Out Date.</value>
        public string CheckOutDate
        {
            get { return GetPropertyConvert<SmartDate, string>(CheckOutDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CheckOutUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int?> CheckOutUserIDProperty = RegisterProperty<int?>(p => p.CheckOutUserID, "Check Out User ID", null);
        /// <summary>
        /// Check-out user ID
        /// </summary>
        /// <value>The Check Out User ID.</value>
        public int? CheckOutUserID
        {
            get { return GetProperty(CheckOutUserIDProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="DocContentRO"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="DocContentRO"/> object.</returns>
        internal static DocContentRO GetDocContentRO(SafeDataReader dr)
        {
            DocContentRO obj = new DocContentRO();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocContentRO"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocContentRO()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocContentRO"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DocContentIDProperty, dr.GetInt32("DocContentID"));
            LoadProperty(VersionProperty, dr.GetInt16("Version"));
            LoadProperty(FileSizeProperty, dr.GetInt32("FileSize"));
            LoadProperty(FileTypeProperty, dr.GetString("FileType"));
            LoadProperty(CheckInDateProperty, dr.GetSmartDate("CheckInDate", true));
            LoadProperty(CheckInUserIDProperty, dr.GetInt32("CheckInUserID"));
            LoadProperty(CheckInCommentProperty, dr.GetString("CheckInComment"));
            LoadProperty(CheckOutDateProperty, dr.IsDBNull("CheckOutDate") ? null : dr.GetSmartDate("CheckOutDate", true));
            LoadProperty(CheckOutUserIDProperty, (int?)dr.GetValue("CheckOutUserID"));
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
