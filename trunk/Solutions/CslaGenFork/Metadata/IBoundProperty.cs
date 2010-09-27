using System;
using System.Collections.Generic;
using System.Text;

namespace CslaGenerator.Metadata
{
    public interface IBoundProperty
    {
        DbBindColumn DbBindColumn { get; set;}
    }
}
