using System;
using Csla;
using Csla.Core;

namespace UsingLibrary
{
    [Serializable]
    public class MyBusinessBindingListBase<T, C> : BusinessListBase<T, C>
        where T : MyBusinessBindingListBase<T, C>
        where C : IEditableBusinessObject
    {
    }
}