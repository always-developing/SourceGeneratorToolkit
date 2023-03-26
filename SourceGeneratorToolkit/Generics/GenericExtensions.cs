using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class GenericExtensions
    {
        public static T AddGeneric<T>(this ISupportsGenerics<T> @base, string value) where T : SourceContainer
        {
            @base.GenericList.AddGeneric(value);

            return (T)@base;
        }

        public static T WithGenericConstraint<T>(this ISupportsGenericsConstraints<T> @base, string generic, string constraint) where T : SourceContainer
        {
            @base.ConstraintContainer.AddConstraint(generic, constraint);

            return (T)@base;
        }
    }
}
