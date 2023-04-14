using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class ImplementExtensions
    {
        public static T WithImplementation<T>(this ISupportsImplementation<T> @base, string value) where T : SourceContainer
        {
            @base.Implements.AddImplements(value);

            return (T)@base;
        }

        public static T WithImplementation<T>(this ISupportsImplementation<T> @base, Type value) where T : SourceContainer
        {
            @base.Implements.AddImplements(value.Name);

            return (T)@base;
        }
    }
}
