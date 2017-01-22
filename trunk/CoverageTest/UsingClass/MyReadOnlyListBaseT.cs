using System;
using Csla;

namespace UsingClass
{
    [Serializable]
    public class MyReadOnlyListBase<T, C> : ReadOnlyListBase<T, C>
        where T : MyReadOnlyListBase<T, C>
    {
    }
}