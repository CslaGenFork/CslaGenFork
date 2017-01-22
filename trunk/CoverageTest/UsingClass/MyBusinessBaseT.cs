using System;
using Csla;

namespace UsingClass
{
    [Serializable]
    public class MyBusinessBase<T> : BusinessBase<T>
        where T : MyBusinessBase<T>
    {
    }
}