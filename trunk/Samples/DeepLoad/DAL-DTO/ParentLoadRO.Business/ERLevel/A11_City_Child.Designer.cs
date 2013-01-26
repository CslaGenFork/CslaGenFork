using System;
using Csla;
using ParentLoadRO.DataAccess.ERLevel;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A11_City_Child (read only object).<br/>
    /// This is a generated base class of <see cref="A11_City_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="A10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A11_City_Child : ReadOnlyBase<A11_City_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int city_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets or sets the City Child Name.
        /// </summary>
        /// <value>The City Child Name.</value>
        public string City_Child_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A11_City_Child"/> object from the given A11_City_ChildDto.
        /// </summary>
        /// <param name="data">The <see cref="A11_City_ChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="A11_City_Child"/> object.</returns>
        internal static A11_City_Child GetA11_City_Child(A11_City_ChildDto data)
        {
            A11_City_Child obj = new A11_City_Child();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A11_City_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A11_City_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A11_City_Child"/> object from the given <see cref="A11_City_ChildDto"/>.
        /// </summary>
        /// <param name="data">The A11_City_ChildDto to use.</param>
        private void Fetch(A11_City_ChildDto data)
        {
            // Value properties
            City_Child_Name = data.City_Child_Name;
            // parent properties
            city_ID1 = data.Parent_City_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
