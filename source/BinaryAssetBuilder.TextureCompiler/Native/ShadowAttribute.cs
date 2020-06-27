using System;
using System.Reflection;

namespace Native
{
    [AttributeUsage(AttributeTargets.Interface)]
    internal class ShadowAttribute : Attribute
    {
        public Type Type { get; }

        public ShadowAttribute(Type typeOfTheAssociatedShadow)
        {
            Type = typeOfTheAssociatedShadow;
        }

        public static ShadowAttribute Get(Type type)
        {
            return type.GetTypeInfo().GetCustomAttribute<ShadowAttribute>();
        }
    }
}
