using System;
using System.Collections.Generic;
using System.Text;

namespace CslaGenerator.Metadata
{
    public class DecoratorArgumentCollection : List<DecoratorArgument>
    {
        public void Add(string name, string value)
        {
            Add(new DecoratorArgument(name, value));
        }
        public void Add(string name, string value, bool addQuotes)
        {
            Add(new DecoratorArgument(name, value,addQuotes));
        }
    }
}
