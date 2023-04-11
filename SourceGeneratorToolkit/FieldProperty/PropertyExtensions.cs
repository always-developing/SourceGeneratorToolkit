using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class PropertyExtensions
    {
        public static T AddProperty<T>(this ISupportsProperty<T> @base, string type, string name, Action<PropertyContainer> builder = null) where T : SourceContainer
        {
            @base.Properties.AddProperty(type, name, builder);
            return (T)@base;
        }
    }
}
