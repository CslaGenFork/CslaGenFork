using System;
using Csla;

namespace UsingClass
{
    [Serializable]
    public class GenericObjectBase<T> : BusinessBase<T>
        where T : GenericObjectBase<T>
    {
    }
}