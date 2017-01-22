using System;
using Csla;
using Csla.Core;

namespace UsingClass
{
    [Serializable]
    public class MyBusinessListBase<T, C> : BusinessListBase<T, C>
        where T : MyBusinessListBase<T, C>
        where C : IEditableBusinessObject
    {
    }
}