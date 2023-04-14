using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class InheritenceExtensions
    {
        public static T WithInheritence<T>(this ISupportsInheritence<T> @base, string baseClassName) where T : SourceContainer
        {
            @base.Inherits.AddInheritence(baseClassName);

            return (T)@base;
        }

        public static T WithInheritence<T>(this ISupportsInheritence<T> @base, Type baseClass) where T : SourceContainer
        {
            @base.Inherits.AddInheritence(baseClass.Name);

            return (T)@base;
        }
    }
}
