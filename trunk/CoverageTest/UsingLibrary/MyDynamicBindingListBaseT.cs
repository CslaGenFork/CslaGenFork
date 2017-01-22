using System;
using Csla;
using Csla.Core;

namespace UsingLibrary
{
    [Serializable]
    public class MyDynamicBindingListBase<T> : DynamicBindingListBase<T>
        where T : IEditableBusinessObject, IUndoableObject, ISavable, IBusinessObject
    {
    }
}