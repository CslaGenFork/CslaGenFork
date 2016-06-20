/********************************************************************
*
*  PropertyBag.cs
*  --------------
*  Derived from PropertyBag.cs by Tony Allowatt
*  CodeProject: http://www.codeproject.com/cs/miscctrl/bending_property.asp
*  Last Update: 04/05/2005
*
********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Reflection;
using CslaGenerator.Attributes;
using CslaGenerator.Metadata;

namespace CslaGenerator.Util.PropertyBags
{
    /// <summary>
    /// Represents a collection of custom properties that can be selected into a
    /// PropertyGrid to provide functionality beyond that of the simple reflection
    /// normally used to query an object's properties.
    /// </summary>
    public class CriteriaBag : ICustomTypeDescriptor
    {
        #region PropertySpecCollection class definition

        /// <summary>
        /// Encapsulates a collection of PropertySpec objects.
        /// </summary>
        [Serializable]
        public class PropertySpecCollection : IList
        {
            private readonly ArrayList _innerArray;

            /// <summary>
            /// Initializes a new instance of the PropertySpecCollection class.
            /// </summary>
            public PropertySpecCollection()
            {
                _innerArray = new ArrayList();
            }

            /// <summary>
            /// Gets or sets the element at the specified index.
            /// In C#, this property is the indexer for the PropertySpecCollection class.
            /// </summary>
            /// <param name="index">The zero-based index of the element to get or set.</param>
            /// <value>
            /// The element at the specified index.
            /// </value>
            public PropertySpec this[int index]
            {
                get { return (PropertySpec)_innerArray[index]; }
                set { _innerArray[index] = value; }
            }

            #region IList Members

            /// <summary>
            /// Gets the number of elements in the PropertySpecCollection.
            /// </summary>
            /// <value>
            /// The number of elements contained in the PropertySpecCollection.
            /// </value>
            public int Count
            {
                get { return _innerArray.Count; }
            }

            /// <summary>
            /// Gets a value indicating whether the PropertySpecCollection has a fixed size.
            /// </summary>
            /// <value>
            /// true if the PropertySpecCollection has a fixed size; otherwise, false.
            /// </value>
            public bool IsFixedSize
            {
                get { return false; }
            }

            /// <summary>
            /// Gets a value indicating whether the PropertySpecCollection is read-only.
            /// </summary>
            public bool IsReadOnly
            {
                get { return false; }
            }

            /// <summary>
            /// Gets a value indicating whether access to the collection is synchronized (thread-safe).
            /// </summary>
            /// <value>
            /// true if access to the PropertySpecCollection is synchronized (thread-safe); otherwise, false.
            /// </value>
            public bool IsSynchronized
            {
                get { return false; }
            }

            /// <summary>
            /// Gets an object that can be used to synchronize access to the collection.
            /// </summary>
            /// <value>
            /// An object that can be used to synchronize access to the collection.
            /// </value>
            object ICollection.SyncRoot
            {
                get { return null; }
            }

            /// <summary>
            /// Removes all elements from the PropertySpecCollection.
            /// </summary>
            public void Clear()
            {
                _innerArray.Clear();
            }

            /// <summary>
            /// Returns an enumerator that can iterate through the PropertySpecCollection.
            /// </summary>
            /// <returns>An IEnumerator for the entire PropertySpecCollection.</returns>
            public IEnumerator GetEnumerator()
            {
                return _innerArray.GetEnumerator();
            }

            /// <summary>
            /// Removes the object at the specified index of the PropertySpecCollection.
            /// </summary>
            /// <param name="index">The zero-based index of the element to remove.</param>
            public void RemoveAt(int index)
            {
                _innerArray.RemoveAt(index);
            }

            #endregion

            /// <summary>
            /// Adds a PropertySpec to the end of the PropertySpecCollection.
            /// </summary>
            /// <param name="value">The PropertySpec to be added to the end of the PropertySpecCollection.</param>
            /// <returns>The PropertySpecCollection index at which the value has been added.</returns>
            public int Add(PropertySpec value)
            {
                int index = _innerArray.Add(value);

                return index;
            }

            /// <summary>
            /// Adds the elements of an array of PropertySpec objects to the end of the PropertySpecCollection.
            /// </summary>
            /// <param name="array">The PropertySpec array whose elements should be added to the end of the
            /// PropertySpecCollection.</param>
            public void AddRange(PropertySpec[] array)
            {
                _innerArray.AddRange(array);
            }

            /// <summary>
            /// Determines whether a PropertySpec is in the PropertySpecCollection.
            /// </summary>
            /// <param name="item">The PropertySpec to locate in the PropertySpecCollection. The element to locate
            /// can be a null reference (Nothing in Visual Basic).</param>
            /// <returns>true if item is found in the PropertySpecCollection; otherwise, false.</returns>
            public bool Contains(PropertySpec item)
            {
                return _innerArray.Contains(item);
            }

            /// <summary>
            /// Determines whether a PropertySpec with the specified name is in the PropertySpecCollection.
            /// </summary>
            /// <param name="name">The name of the PropertySpec to locate in the PropertySpecCollection.</param>
            /// <returns>true if item is found in the PropertySpecCollection; otherwise, false.</returns>
            public bool Contains(string name)
            {
                foreach (PropertySpec spec in _innerArray)
                    if (spec.Name == name)
                        return true;

                return false;
            }

            /// <summary>
            /// Copies the entire PropertySpecCollection to a compatible one-dimensional Array, starting at the
            /// beginning of the target array.
            /// </summary>
            /// <param name="array">The one-dimensional Array that is the destination of the elements copied
            /// from PropertySpecCollection. The Array must have zero-based indexing.</param>
            public void CopyTo(PropertySpec[] array)
            {
                _innerArray.CopyTo(array);
            }

            /// <summary>
            /// Copies the PropertySpecCollection or a portion of it to a one-dimensional array.
            /// </summary>
            /// <param name="array">The one-dimensional Array that is the destination of the elements copied
            /// from the collection.</param>
            /// <param name="index">The zero-based index in array at which copying begins.</param>
            public void CopyTo(PropertySpec[] array, int index)
            {
                _innerArray.CopyTo(array, index);
            }

            /// <summary>
            /// Searches for the specified PropertySpec and returns the zero-based index of the first
            /// occurrence within the entire PropertySpecCollection.
            /// </summary>
            /// <param name="value">The PropertySpec to locate in the PropertySpecCollection.</param>
            /// <returns>The zero-based index of the first occurrence of value within the entire PropertySpecCollection,
            /// if found; otherwise, -1.</returns>
            public int IndexOf(PropertySpec value)
            {
                return _innerArray.IndexOf(value);
            }

            /// <summary>
            /// Searches for the PropertySpec with the specified name and returns the zero-based index of
            /// the first occurrence within the entire PropertySpecCollection.
            /// </summary>
            /// <param name="name">The name of the PropertySpec to locate in the PropertySpecCollection.</param>
            /// <returns>The zero-based index of the first occurrence of value within the entire PropertySpecCollection,
            /// if found; otherwise, -1.</returns>
            public int IndexOf(string name)
            {
                int i = 0;

                foreach (PropertySpec spec in _innerArray)
                {
                    //if (spec.Name == name)
                    if (spec.TargetProperty == name)
                        return i;

                    i++;
                }

                return -1;
            }

            /// <summary>
            /// Inserts a PropertySpec object into the PropertySpecCollection at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index at which value should be inserted.</param>
            /// <param name="value">The PropertySpec to insert.</param>
            public void Insert(int index, PropertySpec value)
            {
                _innerArray.Insert(index, value);
            }

            /// <summary>
            /// Removes the first occurrence of a specific object from the PropertySpecCollection.
            /// </summary>
            /// <param name="obj">The PropertySpec to remove from the PropertySpecCollection.</param>
            public void Remove(PropertySpec obj)
            {
                _innerArray.Remove(obj);
            }

            /// <summary>
            /// Removes the property with the specified name from the PropertySpecCollection.
            /// </summary>
            /// <param name="name">The name of the PropertySpec to remove from the PropertySpecCollection.</param>
            public void Remove(string name)
            {
                int index = IndexOf(name);
                RemoveAt(index);
            }

            /// <summary>
            /// Copies the elements of the PropertySpecCollection to a new PropertySpec array.
            /// </summary>
            /// <returns>A PropertySpec array containing copies of the elements of the PropertySpecCollection.</returns>
            public PropertySpec[] ToArray()
            {
                return (PropertySpec[])_innerArray.ToArray(typeof(PropertySpec));
            }

            #region Explicit interface implementations for ICollection and IList

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            void ICollection.CopyTo(Array array, int index)
            {
                CopyTo((PropertySpec[])array, index);
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            int IList.Add(object value)
            {
                return Add((PropertySpec)value);
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            bool IList.Contains(object obj)
            {
                return Contains((PropertySpec)obj);
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            object IList.this[int index]
            {
                get { return this[index]; }
                set { this[index] = (PropertySpec)value; }
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            int IList.IndexOf(object obj)
            {
                return IndexOf((PropertySpec)obj);
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            void IList.Insert(int index, object value)
            {
                Insert(index, (PropertySpec)value);
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            void IList.Remove(object value)
            {
                Remove((PropertySpec)value);
            }

            #endregion
        }

        #endregion

        #region PropertySpecDescriptor class definition

        private class PropertySpecDescriptor : PropertyDescriptor
        {
            private readonly CriteriaBag _bag;
            private readonly PropertySpec _item;

            public PropertySpecDescriptor(PropertySpec item, CriteriaBag bag, string name, Attribute[] attrs)
                :
                    base(name, attrs)
            {
                _bag = bag;
                _item = item;
            }

            public override Type ComponentType
            {
                get { return _item.GetType(); }
            }

            public override bool IsReadOnly
            {
                get { return (Attributes.Matches(ReadOnlyAttribute.Yes)); }
            }

            public override Type PropertyType
            {
                get { return Type.GetType(_item.TypeName); }
            }

            public override bool CanResetValue(object component)
            {
                if (_item.DefaultValue == null)
                    return false;

                return !GetValue(component).Equals(_item.DefaultValue);
            }

            public override object GetValue(object component)
            {
                // Have the property bag raise an event to get the current value
                // of the property.

                var e = new PropertySpecEventArgs(_item, null);
                _bag.OnGetValue(e);
                return e.Value;
            }

            public override void ResetValue(object component)
            {
                SetValue(component, _item.DefaultValue);
            }

            public override void SetValue(object component, object value)
            {
                // Have the property bag raise an event to set the current value
                // of the property.

                var e = new PropertySpecEventArgs(_item, value);
                _bag.OnSetValue(e);
            }

            public override bool ShouldSerializeValue(object component)
            {
                object val = GetValue(component);

                if (_item.DefaultValue == null && val == null)
                    return false;

                return !val.Equals(_item.DefaultValue);
            }
        }

        #endregion

        #region Properties and Events

        private readonly PropertySpecCollection _properties;
        private string _defaultProperty;
        private Criteria[] _selectedObject;

        /// <summary>
        /// Initializes a new instance of the PlainPropertyBag class.
        /// </summary>
        public CriteriaBag()
        {
            _defaultProperty = null;
            _properties = new PropertySpecCollection();
        }

        public CriteriaBag(Criteria obj)
            : this(new[] { obj })
        {
        }

        public CriteriaBag(Criteria[] obj)
        {
            _defaultProperty = "Name";
            _properties = new PropertySpecCollection();
            _selectedObject = obj;
            InitPropertyBag();
        }

        /// <summary>
        /// Gets or sets the name of the default property in the collection.
        /// </summary>
        public string DefaultProperty
        {
            get { return _defaultProperty; }
            set { _defaultProperty = value; }
        }

        /// <summary>
        /// Gets or sets the name of the default property in the collection.
        /// </summary>
        public Criteria[] SelectedObject
        {
            get { return _selectedObject; }
            set
            {
                _selectedObject = value;
                InitPropertyBag();
            }
        }

        /// <summary>
        /// Gets the collection of properties contained within this CriteriaBag.
        /// </summary>
        public PropertySpecCollection Properties
        {
            get { return _properties; }
        }

        /// <summary>
        /// Occurs when a PropertyGrid requests the value of a property.
        /// </summary>
        public event PropertySpecEventHandler GetValue;

        /// <summary>
        /// Occurs when the user changes the value of a property in a PropertyGrid.
        /// </summary>
        public event PropertySpecEventHandler SetValue;

        /// <summary>
        /// Raises the GetValue event.
        /// </summary>
        /// <param name="e">A PropertySpecEventArgs that contains the event data.</param>
        protected virtual void OnGetValue(PropertySpecEventArgs e)
        {
            if (e.Value != null)
                GetValue(this, e);
            e.Value = GetProperty(e.Property.TargetObject, e.Property.TargetProperty, e.Property.DefaultValue);
        }

        /// <summary>
        /// Raises the SetValue event.
        /// </summary>
        /// <param name="e">A PropertySpecEventArgs that contains the event data.</param>
        protected virtual void OnSetValue(PropertySpecEventArgs e)
        {
            if (SetValue != null)
                SetValue(this, e);
            SetProperty(e.Property.TargetObject, e.Property.TargetProperty, e.Value);
        }

        #endregion

        #region Initialize Propertybag

        private void InitPropertyBag()
        {
            PropertyInfo pi;
            Type t = typeof(Criteria); // _selectedObject.GetType();
            PropertyInfo[] props = t.GetProperties();
            // Display information for all properties.
            for (int i = 0; i < props.Length; i++)
            {
                pi = props[i];
                object[] myAttributes = pi.GetCustomAttributes(true);
                string category = "";
                string description = "";
                bool isreadonly = false;
                bool isbrowsable = true;
                object defaultvalue = null;
                string userfriendlyname = "";
                string typeconverter = "";
                string designertypename = "";
                string helptopic = "";
                bool bindable = true;
                string editor = "";
                for (int n = 0; n < myAttributes.Length; n++)
                {
                    var a = (Attribute)myAttributes[n];
                    switch (a.GetType().ToString())
                    {
                        case "System.ComponentModel.CategoryAttribute":
                            category = ((CategoryAttribute)a).Category;
                            break;
                        case "System.ComponentModel.DescriptionAttribute":
                            description = ((DescriptionAttribute)a).Description;
                            break;
                        case "System.ComponentModel.ReadOnlyAttribute":
                            isreadonly = ((ReadOnlyAttribute)a).IsReadOnly;
                            break;
                        case "System.ComponentModel.BrowsableAttribute":
                            isbrowsable = ((BrowsableAttribute)a).Browsable;
                            break;
                        case "System.ComponentModel.DefaultValueAttribute":
                            defaultvalue = ((DefaultValueAttribute)a).Value;
                            break;
                        case "CslaGenerator.Attributes.UserFriendlyNameAttribute":
                            userfriendlyname = ((UserFriendlyNameAttribute)a).UserFriendlyName;
                            break;
                        case "CslaGenerator.Attributes.HelpTopicAttribute":
                            helptopic = ((HelpTopicAttribute)a).HelpTopic;
                            break;
                        case "System.ComponentModel.TypeConverterAttribute":
                            typeconverter = ((TypeConverterAttribute)a).ConverterTypeName;
                            break;
                        case "System.ComponentModel.DesignerAttribute":
                            designertypename = ((DesignerAttribute)a).DesignerTypeName;
                            break;
                        case "System.ComponentModel.BindableAttribute":
                            bindable = ((BindableAttribute)a).Bindable;
                            break;
                        case "System.ComponentModel.EditorAttribute":
                            editor = ((EditorAttribute)a).EditorTypeName;
                            break;
                    }
                }
                userfriendlyname = userfriendlyname.Length > 0 ? userfriendlyname : pi.Name;
                var types = new List<string>();
                foreach (var obj in _selectedObject)
                {
                    if (!types.Contains(obj.Name))
                        types.Add(obj.Name);
                }
                // here get rid of ComponentName and Parent
                bool isValidProperty = (pi.Name != "ComponentName" && pi.Name != "Parent");
                if (isValidProperty && IsBrowsable(types.ToArray(), pi.Name))
                {
                    // CR added missing parameters
                    //this.Properties.Add(new PropertySpec(userfriendlyname,pi.PropertyType.AssemblyQualifiedName,category,description,defaultvalue, editor, typeconverter, _selectedObject, pi.Name,helptopic));
                    Properties.Add(new PropertySpec(userfriendlyname, pi.PropertyType.AssemblyQualifiedName, category,
                                                    description, defaultvalue, editor, typeconverter, _selectedObject,
                                                    pi.Name, helptopic, isreadonly, isbrowsable, designertypename,
                                                    bindable));
                }
            }
        }

        #endregion

        private readonly Dictionary<string, PropertyInfo> propertyInfoCache = new Dictionary<string, PropertyInfo>();

        private PropertyInfo GetPropertyInfoCache(string propertyName)
        {
            if (!propertyInfoCache.ContainsKey(propertyName))
            {
                propertyInfoCache.Add(propertyName, typeof(Criteria).GetProperty(propertyName));
            }
            return propertyInfoCache[propertyName];
        }

        private bool IsEnumerable(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(string))
                return false;
            Type[] interfaces = prop.PropertyType.GetInterfaces();
            foreach (Type typ in interfaces)
                if (typ.Name.Contains("IEnumerable"))
                    return true;
            return false;
        }

        #region IsBrowsable map objecttype:propertyname -> true | false

        private bool IsBrowsable(string[] objectType, string propertyName)
        {
            try
            {
                var cslaObject = (CslaObjectInfo)GeneratorController.Current.GetSelectedItem();

                var criteria = SelectedObject[0];

                if ((cslaObject.ObjectType == CslaObjectType.ReadOnlyObject ||
                    cslaObject.ObjectType == CslaObjectType.ReadOnlyCollection ||
                    cslaObject.ObjectType == CslaObjectType.NameValueList ||
                    (cslaObject.ObjectType == CslaObjectType.UnitOfWork && cslaObject.IsGetter)) &&
                    (propertyName == "CreateOptions" ||
                     propertyName == "DeleteOptions"))
                    return false;
                if (cslaObject.ObjectType == CslaObjectType.EditableChild &&
                    propertyName == "DeleteOptions")
                    return false;
                if ((cslaObject.ObjectType == CslaObjectType.UnitOfWork && cslaObject.IsCreator) &&
                    (propertyName == "GetOptions" ||
                     propertyName == "DeleteOptions"))
                    return false;
                if ((cslaObject.ObjectType == CslaObjectType.UnitOfWork && cslaObject.IsCreatorGetter) &&
                    (propertyName == "DeleteOptions"))
                    return false;
                if ((criteria.CriteriaClassMode == CriteriaMode.BusinessBase ||
                criteria.CriteriaClassMode == CriteriaMode.CustomCriteriaClass )&&
                    propertyName == "NestedClass")
                    return false;
                if (criteria.CriteriaClassMode != CriteriaMode.CustomCriteriaClass &&
                    propertyName == "CustomClass")
                    return false;

                if (_selectedObject.Length > 1 && IsEnumerable(GetPropertyInfoCache(propertyName)))
                    return false;

                return true;
            }
            catch //(Exception e)
            {
                Debug.WriteLine(objectType + ":" + propertyName);
                return true;
            }
        }

        #endregion

        #region Reflection functions

        private object GetField(Type t, string name, object target)
        {
            object obj = null;
            Type tx;

            //FieldInfo[] fields;
            //fields = target.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //fields = target.GetType().GetFields(BindingFlags.Public);

            tx = target.GetType();
            obj = tx.InvokeMember(name, BindingFlags.Default | BindingFlags.GetField, null, target, new object[] { });
            return obj;
        }

        private object SetField(Type t, string name, object value, object target)
        {
            object obj;
            obj = t.InvokeMember(name, BindingFlags.Default | BindingFlags.SetField, null, target, new[] { value });
            return obj;
        }

        private bool SetProperty(object obj, string propertyName, object val)
        {
            try
            {
                // get a reference to the PropertyInfo, exit if no property with that
                // name
                PropertyInfo pi = typeof(Criteria).GetProperty(propertyName);

                if (pi == null)
                    return false;
                // convert the value to the expected type
                val = Convert.ChangeType(val, pi.PropertyType);
                // attempt the assignment
                foreach (Criteria bo in (Criteria[])obj)
                    pi.SetValue(bo, val, null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private object GetProperty(object obj, string propertyName, object defaultValue)
        {
            try
            {
                PropertyInfo pi = GetPropertyInfoCache(propertyName);
                if (!(pi == null))
                {
                    var objs = (Criteria[])obj;
                    var valueList = new ArrayList();

                    foreach (Criteria bo in objs)
                    {
                        object value = pi.GetValue(bo, null);
                        if (!valueList.Contains(value))
                        {
                            valueList.Add(value);
                        }
                    }
                    switch (valueList.Count)
                    {
                        case 1:
                            return valueList[0];
                        default:
                            return string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // if property doesn't exist or throws
            return defaultValue;
        }

        #endregion

        #region ICustomTypeDescriptor explicit interface definitions

        // Most of the functions required by the ICustomTypeDescriptor are
        // merely pssed on to the default TypeDescriptor for this type,
        // which will do something appropriate.  The exceptions are noted
        // below.
        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            // This function searches the property list for the property
            // with the same name as the DefaultProperty specified, and
            // returns a property descriptor for it.  If no property is
            // found that matches DefaultProperty, a null reference is
            // returned instead.

            PropertySpec propertySpec = null;
            if (_defaultProperty != null)
            {
                int index = _properties.IndexOf(_defaultProperty);
                propertySpec = _properties[index];
            }

            if (propertySpec != null)
                return new PropertySpecDescriptor(propertySpec, this, propertySpec.Name, null);

            return null;
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            // Rather than passing this function on to the default TypeDescriptor,
            // which would return the actual properties of CriteriaBag, I construct
            // a list here that contains property descriptors for the elements of the
            // Properties list in the bag.

            var props = new ArrayList();

            foreach (PropertySpec property in _properties)
            {
                var attrs = new ArrayList();

                // If a category, description, editor, or type converter are specified
                // in the PropertySpec, create attributes to define that relationship.
                if (property.Category != null)
                    attrs.Add(new CategoryAttribute(property.Category));

                if (property.Description != null)
                    attrs.Add(new DescriptionAttribute(property.Description));

                if (property.EditorTypeName != null)
                    attrs.Add(new EditorAttribute(property.EditorTypeName, typeof(UITypeEditor)));

                if (property.ConverterTypeName != null)
                    attrs.Add(new TypeConverterAttribute(property.ConverterTypeName));

                // Additionally, append the custom attributes associated with the
                // PropertySpec, if any.
                if (property.Attributes != null)
                    attrs.AddRange(property.Attributes);

                if (property.DefaultValue != null)
                    attrs.Add(new DefaultValueAttribute(property.DefaultValue));

                attrs.Add(new BrowsableAttribute(property.Browsable));
                attrs.Add(new ReadOnlyAttribute(property.ReadOnly));
                attrs.Add(new BindableAttribute(property.Bindable));

                var attrArray = (Attribute[])attrs.ToArray(typeof(Attribute));

                // Create a new property descriptor for the property item, and add
                // it to the list.
                var pd = new PropertySpecDescriptor(property,
                                                    this, property.Name, attrArray);
                props.Add(pd);
            }

            // Convert the list of PropertyDescriptors to a collection that the
            // ICustomTypeDescriptor can use, and return it.
            var propArray = (PropertyDescriptor[])props.ToArray(
                typeof(PropertyDescriptor));
            return new PropertyDescriptorCollection(propArray);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion

    }
}
