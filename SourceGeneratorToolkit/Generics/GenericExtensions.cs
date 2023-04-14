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

        public static T WithGenericConstraint<T>(this ISupportsGenericsConstraints<T> @base, string generic, GenericConstraint constraint) where T : SourceContainer
        {
            @base.ConstraintContainer.AddConstraint(generic, GetStrigConstraint(constraint));

            return (T)@base;
        }

        private static string GetStrigConstraint(GenericConstraint constraint) => constraint switch
        {
            GenericConstraint.Struct => "struct",
            GenericConstraint.Class => "class",
            GenericConstraint.NullableClass => "class?",
            GenericConstraint.NotNull => "notnull",
            GenericConstraint.Default => "default",
            GenericConstraint.Unmanaged => "unmanaged",
            GenericConstraint.New => "new()",
            _ => constraint.ToString()
        };
    }
}
