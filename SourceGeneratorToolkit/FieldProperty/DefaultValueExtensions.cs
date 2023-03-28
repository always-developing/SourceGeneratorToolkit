using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class DefaultValueExtensions
    {
        public static T WithDefaultValue<T>(this ISupportsDefaultValue<T> @base, string value) where T : SourceContainer
        {
            @base.DefaultValue.SetDefautlValue(value);
            return (T)@base;
        }
    }
}
