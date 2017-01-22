using System;
using Csla;

namespace UsingClass
{
    [Serializable]
    public class MyObjectBase<T> : BusinessBase<T>
        where T : MyObjectBase<T>
    {
    }
}