using System;
using Csla;
using Csla.Core;
using Csla.Serialization.Mobile;

namespace UsingClass
{
    [Serializable]
    public class MyDynamicListBase<T> : DynamicListBase<T>
        where T : IEditableBusinessObject, IUndoableObject, ISavable, IMobileObject, IBusinessObject
    {
    }
}