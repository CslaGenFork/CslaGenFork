using System;
using Csla;

namespace UsingLibrary
{
    [Serializable]
    public class MyBusinessBase<T> : BusinessBase<T>
        where T : MyBusinessBase<T>
    {
    }
}