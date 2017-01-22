using System;
using Csla;

namespace UsingLibrary
{
    [Serializable]
    public class MyReadOnlyBindingListBase<T, C> : ReadOnlyBindingListBase<T, C>
        where T : MyReadOnlyBindingListBase<T, C>
    {
    }
}