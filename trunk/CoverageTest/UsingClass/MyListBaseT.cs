using System;
using Csla;
using Csla.Core;

namespace UsingClass
{
    [Serializable]
    public class MyListBase<T, C> : BusinessListBase<T, C>
        where T : MyListBase<T, C>
        where C : IEditableBusinessObject
    {
    }
}