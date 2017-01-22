using System;
using Csla;

namespace UsingClass
{
    [Serializable]
    public class MyReadOnlyBase<T> : ReadOnlyBase<T>
        where T : MyReadOnlyBase<T>
    {
    }
}