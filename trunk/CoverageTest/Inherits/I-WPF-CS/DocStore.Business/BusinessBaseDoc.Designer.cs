using System;
using System.Diagnostics.CodeAnalysis;
using Csla;

namespace DocStore.Business
{
    /// <summary>
    /// BusinessBaseDoc.<br/>
    /// This is a generated abstract base class of <see cref="BusinessBaseDoc"/>.
    /// </summary>
    /// <remarks>
    /// This class contains two child collections:<br/>
    /// - <see cref="Contents"/> of type <see cref="DocContentList"/> (1:M relation to <see cref="DocContentInfo"/>)
    /// </remarks>
    [Serializable]
    public abstract partial class BusinessBaseDoc<T> : BusinessBase<T> where T : BusinessBaseDoc<T>
    {
        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Secret"/> property.
        /// </summary>
        [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
        public static readonly PropertyInfo<string> SecretProperty = RegisterProperty<string>(p => p.Secret, "Secret");
        /// <summary>
        /// Gets or sets the Secret.
        /// </summary>
        /// <value>The Secret.</value>
        public string Secret
        {
            get { return GetProperty(SecretProperty); }
            set { SetProperty(SecretProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="ViewContent"/> property.
        /// </summary>
        [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
        public static readonly PropertyInfo<DocContentRO> ViewContentProperty = RegisterProperty<DocContentRO>(p => p.ViewContent, "View Content", RelationshipTypes.Child);
        /// <summary>
        /// Gets the View Content ("parent load" child property).
        /// </summary>
        /// <value>The View Content.</value>
        public DocContentRO ViewContent
        {
            get { return GetProperty(ViewContentProperty); }
            private set { LoadProperty(ViewContentProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="Contents"/> property.
        /// </summary>
        [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
        public static readonly PropertyInfo<DocContentList> ContentsProperty = RegisterProperty<DocContentList>(p => p.Contents, "Contents", RelationshipTypes.Child);
        /// <summary>
        /// Gets the Contents ("parent load" child property).
        /// </summary>
        /// <value>The Contents.</value>
        public DocContentList Contents
        {
            get { return GetProperty(ContentsProperty); }
            private set { LoadProperty(ContentsProperty, value); }
        }

        #endregion
    }
}