using System;
using Csla;
using Csla.Core;

namespace UsingLibrary
{
    [Serializable]
    public class MyBindingListBase<T, C> : BusinessBindingListBase<T, C>
        where T : MyBindingListBase<T, C>
        where C : IEditableBusinessObject
    {
    }
}