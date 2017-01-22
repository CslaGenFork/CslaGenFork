using System;
using Csla;

namespace UsingLibrary
{
    [Serializable]
    public class MyReadOnlyBase<T> : ReadOnlyBase<T>
        where T : MyReadOnlyBase<T>
    {
    }
}