using System;
using Csla;
using Csla.Core;
using Csla.Serialization.Mobile;

namespace UsingLibrary
{
    [Serializable]
    public class MyDynamicBindingListBase<T> : DynamicBindingListBase<T>
        where T : IEditableBusinessObject, IUndoableObject, ISavable, IMobileObject, IBusinessObject
    {
    }
}