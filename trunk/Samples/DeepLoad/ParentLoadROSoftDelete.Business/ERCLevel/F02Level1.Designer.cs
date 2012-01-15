using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F02Level1 (read only object).<br/>
    /// This is a generated base class of <see cref="F02Level1"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="F03Level11Objects"/> of type <see cref="F03Level11Coll"/> (1:M relation to <see cref="F04Level11"/>)<br/>
    /// This class is an item of <see cref="F01Level1Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F02Level1 : ReadOnlyBase<F02Level1>
    {

        #region ParentList Property

        /// <summary>
        /// Maintains metadata about <see cref="ParentList"/> property.
        /// </summary>
        public static readonly PropertyInfo<F01Level1Coll> ParentListProperty = RegisterProperty<F01Level1Coll>(p => p.ParentList);
        /// <summary>
        /// Provide access to the parent list reference for use in child object code.
        /// </summary>
        /// <value>The parent list reference.</value>
        public F01Level1Coll ParentList
        {
            get { return ReadProperty(ParentListProperty); }
            internal set { LoadProperty(ParentListProperty, value); }
        }

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_IDProperty = RegisterProperty<int>(p => p.Level_1_ID, "Level_1 ID", -1);
        /// <summary>
        /// Gets the Level_1 ID.
        /// </summary>
        /// <value>The Level_1 ID.</value>
        public int Level_1_ID
        {
            get { return GetProperty(Level_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_NameProperty = RegisterProperty<string>(p => p.Level_1_Name, "Level_1 Name");
        /// <summary>
        /// Gets the Level_1 Name.
        /// </summary>
        /// <value>The Level_1 Name.</value>
        public string Level_1_Name
        {
            get { return GetProperty(Level_1_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F03Level11SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F03Level11Child> F03Level11SingleObjectProperty = RegisterProperty<F03Level11Child>(p => p.F03Level11SingleObject, "B3 Level11 Single Object");
        /// <summary>
        /// Gets the F03 Level11 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The F03 Level11 Single Object.</value>
        public F03Level11Child F03Level11SingleObject
        {
            get { return GetProperty(F03Level11SingleObjectProperty); }
            private set { LoadProperty(F03Level11SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F03Level11ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F03Level11ReChild> F03Level11ASingleObjectProperty = RegisterProperty<F03Level11ReChild>(p => p.F03Level11ASingleObject, "B3 Level11 ASingle Object");
        /// <summary>
        /// Gets the F03 Level11 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The F03 Level11 ASingle Object.</value>
        public F03Level11ReChild F03Level11ASingleObject
        {
            get { return GetProperty(F03Level11ASingleObjectProperty); }
            private set { LoadProperty(F03Level11ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F03Level11Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<F03Level11Coll> F03Level11ObjectsProperty = RegisterProperty<F03Level11Coll>(p => p.F03Level11Objects, "B3 Level11 Objects");
        /// <summary>
        /// Gets the F03 Level11 Objects ("parent load" child property).
        /// </summary>
        /// <value>The F03 Level11 Objects.</value>
        public F03Level11Coll F03Level11Objects
        {
            get { return GetProperty(F03Level11ObjectsProperty); }
            private set { LoadProperty(F03Level11ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F02Level1"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F02Level1"/> object.</returns>
        internal static F02Level1 GetF02Level1(SafeDataReader dr)
        {
            F02Level1 obj = new F02Level1();
            obj.Fetch(dr);
            obj.LoadProperty(F03Level11ObjectsProperty, new F03Level11Coll());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F02Level1"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F02Level1()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F02Level1"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_IDProperty, dr.GetInt32("Level_1_ID"));
            LoadProperty(Level_1_NameProperty, dr.GetString("Level_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        internal void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            while (dr.Read())
            {
                var child = F03Level11Child.GetF03Level11Child(dr);
                var obj = ParentList.FindF02Level1ByParentProperties(child.cParentID1);
                obj.LoadProperty(F03Level11SingleObjectProperty, child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F03Level11ReChild.GetF03Level11ReChild(dr);
                var obj = ParentList.FindF02Level1ByParentProperties(child.cParentID2);
                obj.LoadProperty(F03Level11ASingleObjectProperty, child);
            }
            dr.NextResult();
            var f03Level11Coll = F03Level11Coll.GetF03Level11Coll(dr);
            f03Level11Coll.LoadItems(ParentList);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F05Level111ReChild.GetF05Level111ReChild(dr);
                var obj = f03Level11Coll.FindF04Level11ByParentProperties(child.cMarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F05Level111Child.GetF05Level111Child(dr);
                var obj = f03Level11Coll.FindF04Level11ByParentProperties(child.cMarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f05Level111Coll = F05Level111Coll.GetF05Level111Coll(dr);
            f05Level111Coll.LoadItems(f03Level11Coll);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F07Level1111Child.GetF07Level1111Child(dr);
                var obj = f05Level111Coll.FindF06Level111ByParentProperties(child.cLarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F07Level1111ReChild.GetF07Level1111ReChild(dr);
                var obj = f05Level111Coll.FindF06Level111ByParentProperties(child.cLarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f07Level1111Coll = F07Level1111Coll.GetF07Level1111Coll(dr);
            f07Level1111Coll.LoadItems(f05Level111Coll);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F09Level11111Child.GetF09Level11111Child(dr);
                var obj = f07Level1111Coll.FindF08Level1111ByParentProperties(child.cNarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F09Level11111ReChild.GetF09Level11111ReChild(dr);
                var obj = f07Level1111Coll.FindF08Level1111ByParentProperties(child.cNarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f09Level11111Coll = F09Level11111Coll.GetF09Level11111Coll(dr);
            f09Level11111Coll.LoadItems(f07Level1111Coll);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F11Level111111Child.GetF11Level111111Child(dr);
                var obj = f09Level11111Coll.FindF10Level11111ByParentProperties(child.cQarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F11Level111111ReChild.GetF11Level111111ReChild(dr);
                var obj = f09Level11111Coll.FindF10Level11111ByParentProperties(child.cQarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f11Level111111Coll = F11Level111111Coll.GetF11Level111111Coll(dr);
            f11Level111111Coll.LoadItems(f09Level11111Coll);
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
