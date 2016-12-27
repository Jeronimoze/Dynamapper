using System;

namespace Dynamapper.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class StoredAs : Attribute
    {
        public StoredAs(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}
