using System;
using Csla;

namespace UsingLibrary
{
    [Serializable]
    public class MyReadOnlyListBase<T, C> : ReadOnlyListBase<T, C>
        where T : MyReadOnlyListBase<T, C>
    {
    }
}