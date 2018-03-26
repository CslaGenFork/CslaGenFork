using System;
using Csla;

namespace Codisa.InterwayDocs.Business.SearchObjects
{

    /// <summary>
    /// CriteriaDateTypeInfo (read only object).<br/>
    /// This is a generated base class of <see cref="CriteriaDateTypeInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="CriteriaDateTypeList"/> collection.
    /// </remarks>
    [Serializable]
    public class CriteriaDateTypeInfo : ReadOnlyBase<CriteriaDateTypeInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DateTypeName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DateTypeNameProperty = RegisterProperty<string>(p => p.DateTypeName, "Date Type Name");

        /// <summary>
        /// Gets the name of the date type.
        /// </summary>
        /// <value>The name of the date type.</value>
        public string DateTypeName
        {
            get { return GetProperty(DateTypeNameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DateTypeDescription"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DateTypeDescriptionProperty = RegisterProperty<string>(p => p.DateTypeDescription, "Date Type Description");

        /// <summary>
        /// Gets the date type description.
        /// </summary>
        /// <value>The date type description.</value>
        public string DateTypeDescription
        {
            get { return GetProperty(DateTypeDescriptionProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="CriteriaDateTypeInfo" /> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dateTypeName">Name of the date type.</param>
        /// <param name="dateTypeDescription">The date type description.</param>
        /// <returns>
        /// A reference to the fetched <see cref="CriteriaDateTypeInfo" /> object.
        /// </returns>
        internal static CriteriaDateTypeInfo GetCriteriaDateTypeInfo(string dateTypeName, string dateTypeDescription)
        {
            CriteriaDateTypeInfo obj = new CriteriaDateTypeInfo();
            obj.Fetch(dateTypeName, dateTypeDescription);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CriteriaDateTypeInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CriteriaDateTypeInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="CriteriaDateTypeInfo" /> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dateTypeName">Name of the date type.</param>
        /// <param name="dateTypeDescription">The date type description.</param>
        private void Fetch(string dateTypeName, string dateTypeDescription)
        {
            // Value properties
            LoadProperty(DateTypeNameProperty, dateTypeName);
            LoadProperty(DateTypeDescriptionProperty, dateTypeDescription);
        }

        #endregion

    }
}
