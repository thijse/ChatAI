using System.Collections.Generic;
using System.Dynamic;

namespace ChatAI.Utilities
{
    public class DynamicDictionary : DynamicObject
    {
        // The inner dictionary.
        Dictionary<string, object> dictionary = new();

        // This property returns the number of elements
        // in the inner dictionary.
        public int Count
        {
            get{ return dictionary.Count; }
        }

        // If you try to get a value of a property
        // not defined in the class, this method is called.
        public override bool TryGetMember( GetMemberBinder binder, out object value)
        {
            return GetEntry(binder.Name, out value);
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return SetEntry(binder.Name, value);
        }


        // Set the property value by index.
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            return SetEntry((string)indexes[0], value);
        }

        // Get the property value by index.
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object value)
        {
            return GetEntry((string)indexes[0], out value);
        }

        private bool SetEntry(string index, object value)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            dictionary[index.ToLower()] = value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }

        private bool GetEntry(string index, out object value)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            return dictionary.TryGetValue(index.ToLower(), out value);
        }
    }
}
