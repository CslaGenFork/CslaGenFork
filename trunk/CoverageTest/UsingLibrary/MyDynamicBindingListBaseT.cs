using System;
using Csla;
using Csla.Core;

namespace UsingClass
{
    [Serializable]
    public class MyDynamicBindingListBase<T> : DynamicBindingListBase<T>
        where T : IEditableBusinessObject, IUndoableObject, ISavable, IBusinessObject
    {
    }
}