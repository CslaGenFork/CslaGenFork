using System;

namespace UsingLibrary
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class AttributableAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236

        public AttributableAttribute()
        {
            // TODO: Implement code here
            //throw new NotImplementedException();
        }
    }
}