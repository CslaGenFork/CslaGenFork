using System;
using System.ComponentModel;
using CslaGenerator.Util.PropertyBags;

namespace CslaGenerator.Util
{
    public class ContextHelper
    {
        public static void GetContextInstanceObject(ITypeDescriptorContext context, ref object objinfo,
            ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is PropertyBag or PropertyGrid
                if (context.Instance is PropertyBag)
                {
                    var pBag = (PropertyBag) context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetAssociativeEntityContextInstanceObject(ITypeDescriptorContext context, ref object objinfo,
            ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is PropertyBag or PropertyGrid
                if (context.Instance is AssociativeEntityPropertyBag)
                {
                    var pBag = (AssociativeEntityPropertyBag) context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetConvertValuePropertyContextInstanceObject(ITypeDescriptorContext context,
            ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is PropertyBag or PropertyGrid
                if (context.Instance is ConvertValuePropertyBag)
                {
                    var pBag = (ConvertValuePropertyBag) context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetPropertyContextInstanceObject(ITypeDescriptorContext context, ref object objinfo,
            ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is PropertyBag or PropertyGrid
                if (context.Instance is BusinessRuleConstructorBag)
                {
                    var pBag = (BusinessRuleConstructorBag) context.Instance;
                    if (pBag.SelectedObject[0].ConstructorParameter0.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter0;
                    else if (pBag.SelectedObject[0].ConstructorParameter1.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter1;
                    else if (pBag.SelectedObject[0].ConstructorParameter2.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter2;
                    else if (pBag.SelectedObject[0].ConstructorParameter3.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter3;
                    else if (pBag.SelectedObject[0].ConstructorParameter4.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter4;
                    else if (pBag.SelectedObject[0].ConstructorParameter5.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter5;
                    else if (pBag.SelectedObject[0].ConstructorParameter6.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter6;
                    else if (pBag.SelectedObject[0].ConstructorParameter7.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter7;
                    else if (pBag.SelectedObject[0].ConstructorParameter8.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter8;
                    else if (pBag.SelectedObject[0].ConstructorParameter9.Name == context.PropertyDescriptor.Name)
                        objinfo = pBag.SelectedObject[0].ConstructorParameter9;
                    /*                    if (pBag.SelectedObject.Length == 1)
                                            objinfo = pBag.SelectedObject[0];
                                        else
                                            objinfo = (pBag).SelectedObject;*/
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetInheritedTypeContextInstanceObject(ITypeDescriptorContext context, ref object objinfo,
            ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is InheritedTypePropertyBag or PropertyGrid
                if (context.Instance is InheritedTypePropertyBag)
                {
                    var pBag = (InheritedTypePropertyBag) context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetAuthorizationTypeContextInstanceObject(ITypeDescriptorContext context, ref object objinfo,
            ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is AuthorizationRuleBag or PropertyGrid
                if (context.Instance is AuthorizationRuleBag)
                {
                    var pBag = (AuthorizationRuleBag) context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetBusinessRuleTypeContextInstanceObject(ITypeDescriptorContext context, ref object objinfo,
            ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is AuthorizationRuleBag or PropertyGrid
                if (context.Instance is BusinessRuleBag)
                {
                    var pBag = (BusinessRuleBag) context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        /*public static void GetBusinessRulePropertyTypeContextInstanceObject(ITypeDescriptorContext context, ref object objinfo, ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is AuthorizationRuleBag or PropertyGrid
                if (context.Instance is BusinessRulePropertyBag)
                {
                    var pBag = (BusinessRulePropertyBag)context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }*/

        public static void GetUnitOfWorkPropertyContextInstanceObject(ITypeDescriptorContext context, ref object objinfo,
            ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is UnitOfWorkPropertyBag or PropertyGrid
                if (context.Instance is UnitOfWorkPropertyBag)
                {
                    var pBag = (UnitOfWorkPropertyBag) context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetChildPropertyContextInstanceObject(ITypeDescriptorContext context, ref object objinfo,
            ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is ChildPropertyBag or PropertyGrid
                if (context.Instance is ChildPropertyBag)
                {
                    var pBag = (ChildPropertyBag) context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }

        public static void GetValuePropertyContextInstanceObject(ITypeDescriptorContext context, ref object objinfo,
            ref Type instanceType)
        {
            if (context.Instance != null)
            {
                // check if context.Instance is ValuePropertyBag or PropertyGrid
                if (context.Instance is ValuePropertyBag)
                {
                    var pBag = (ValuePropertyBag) context.Instance;
                    if (pBag.SelectedObject.Length == 1)
                        objinfo = pBag.SelectedObject[0];
                    else
                        objinfo = (pBag).SelectedObject;
                    instanceType = objinfo.GetType();
                }
                else
                {
                    // by default it is a propertygrid
                    objinfo = context.Instance;
                    instanceType = context.Instance.GetType();
                }
            }
        }
    }
}