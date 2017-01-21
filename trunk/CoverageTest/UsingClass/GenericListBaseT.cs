using System;
using Csla;
using Csla.Core;

namespace UsingClass
{
    [Serializable]
    public class GenericListBase<T, C> : BusinessListBase<T, C>
        where T : GenericListBase<T, C>
        where C : IEditableBusinessObject
    {
    }
}