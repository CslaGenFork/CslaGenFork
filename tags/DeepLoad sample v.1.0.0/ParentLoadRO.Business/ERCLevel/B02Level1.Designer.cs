using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B02Level1 (read only object).<br/>
    /// This is a generated base class of <see cref="B02Level1"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B03Level11Objects"/> of type <see cref="B03Level11Coll"/> (1:M relation to <see cref="B04Level11"/>)<br/>
    /// This class is an item of <see cref="B01Level1Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B02Level1 : ReadOnlyBase<B02Level1>
    {

        #region ParentList Property

        /// <summary>
        /// Maintains metadata about <see cref="ParentList"/> property.
        /// </summary>
        public static readonly PropertyInfo<B01Level1Coll> ParentListProperty = RegisterProperty<B01Level1Coll>(p => p.ParentList);
        /// <summary>
        /// Provide access to the parent list reference for use in child object code.
        /// </summary>
        /// <value>The parent list reference.</value>
        public B01Level1Coll ParentList
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
        /// Maintains metadata about child <see cref="B03Level11SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B03Level11Child> B03Level11SingleObjectProperty = RegisterProperty<B03Level11Child>(p => p.B03Level11SingleObject, "B3 Level11 Single Object");
        /// <summary>
        /// Gets the B03 Level11 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B03 Level11 Single Object.</value>
        public B03Level11Child B03Level11SingleObject
        {
            get { return GetProperty(B03Level11SingleObjectProperty); }
            private set { LoadProperty(B03Level11SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B03Level11ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B03Level11ReChild> B03Level11ASingleObjectProperty = RegisterProperty<B03Level11ReChild>(p => p.B03Level11ASingleObject, "B3 Level11 ASingle Object");
        /// <summary>
        /// Gets the B03 Level11 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B03 Level11 ASingle Object.</value>
        public B03Level11ReChild B03Level11ASingleObject
        {
            get { return GetProperty(B03Level11ASingleObjectProperty); }
            private set { LoadProperty(B03Level11ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B03Level11Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B03Level11Coll> B03Level11ObjectsProperty = RegisterProperty<B03Level11Coll>(p => p.B03Level11Objects, "B3 Level11 Objects");
        /// <summary>
        /// Gets the B03 Level11 Objects ("parent load" child property).
        /// </summary>
        /// <value>The B03 Level11 Objects.</value>
        public B03Level11Coll B03Level11Objects
        {
            get { return GetProperty(B03Level11ObjectsProperty); }
            private set { LoadProperty(B03Level11ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B02Level1"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B02Level1"/> object.</returns>
        internal static B02Level1 GetB02Level1(SafeDataReader dr)
        {
            B02Level1 obj = new B02Level1();
            obj.Fetch(dr);
            obj.LoadProperty(B03Level11ObjectsProperty, new B03Level11Coll());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B02Level1"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B02Level1()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B02Level1"/> object from the given SafeDataReader.
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
                var child = B03Level11Child.GetB03Level11Child(dr);
                var obj = ParentList.FindB02Level1ByParentProperties(child.cParentID1);
                obj.LoadProperty(B03Level11SingleObjectProperty, child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = B03Level11ReChild.GetB03Level11ReChild(dr);
                var obj = ParentList.FindB02Level1ByParentProperties(child.cParentID2);
                obj.LoadProperty(B03Level11ASingleObjectProperty, child);
            }
            dr.NextResult();
            var b03Level11Coll = B03Level11Coll.GetB03Level11Coll(dr);
            b03Level11Coll.LoadItems(ParentList);
            dr.NextResult();
            while (dr.Read())
            {
                var child = B05Level111ReChild.GetB05Level111ReChild(dr);
                var obj = b03Level11Coll.FindB04Level11ByParentProperties(child.cMarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = B05Level111Child.GetB05Level111Child(dr);
                var obj = b03Level11Coll.FindB04Level11ByParentProperties(child.cMarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var b05Level111Coll = B05Level111Coll.GetB05Level111Coll(dr);
            b05Level111Coll.LoadItems(b03Level11Coll);
            dr.NextResult();
            while (dr.Read())
            {
                var child = B07Level1111Child.GetB07Level1111Child(dr);
                var obj = b05Level111Coll.FindB06Level111ByParentProperties(child.cLarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = B07Level1111ReChild.GetB07Level1111ReChild(dr);
                var obj = b05Level111Coll.FindB06Level111ByParentProperties(child.cLarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var b07Level1111Coll = B07Level1111Coll.GetB07Level1111Coll(dr);
            b07Level1111Coll.LoadItems(b05Level111Coll);
            dr.NextResult();
            while (dr.Read())
            {
                var child = B09Level11111Child.GetB09Level11111Child(dr);
                var obj = b07Level1111Coll.FindB08Level1111ByParentProperties(child.cNarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = B09Level11111ReChild.GetB09Level11111ReChild(dr);
                var obj = b07Level1111Coll.FindB08Level1111ByParentProperties(child.cNarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var b09Level11111Coll = B09Level11111Coll.GetB09Level11111Coll(dr);
            b09Level11111Coll.LoadItems(b07Level1111Coll);
            dr.NextResult();
            while (dr.Read())
            {
                var child = B11Level111111Child.GetB11Level111111Child(dr);
                var obj = b09Level11111Coll.FindB10Level11111ByParentProperties(child.cQarentID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = B11Level111111ReChild.GetB11Level111111ReChild(dr);
                var obj = b09Level11111Coll.FindB10Level11111ByParentProperties(child.cQarentID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var b11Level111111Coll = B11Level111111Coll.GetB11Level111111Coll(dr);
            b11Level111111Coll.LoadItems(b09Level11111Coll);
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
