using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class AccessModifierExtensions
    {
        public static T AsPublic<T>(this IPublicModifier<T> @base) where T : SourceContainer
        {
            return @base.AccessModifier.AsPublic((T)@base);
        }

        public static T AsPrivate<T>(this IPrivateModifier<T> @base) where T : SourceContainer
        {
            return @base.AccessModifier.AsPrivate((T)@base);
        }

        public static T AsProtected<T>(this IProtectedModifier<T> @base) where T : SourceContainer
        {
            return @base.AccessModifier.AsProtected((T)@base);
        }

        public static T AsInternal<T>(this IInternalModifier<T> @base) where T : SourceContainer
        {
            return @base.AccessModifier.AsInternal((T)@base);
        }

        public static T AsProtectedInternal<T>(this IProtectedInternalModifier<T> @base) where T : SourceContainer
        {
            return @base.AccessModifier.AsProtectedInternal((T)@base);
        }

        public static T AsFile<T>(this IFileModifier<T> @base) where T : SourceContainer
        {
            return @base.AccessModifier.AsFile((T)@base);
        }
    }
}
