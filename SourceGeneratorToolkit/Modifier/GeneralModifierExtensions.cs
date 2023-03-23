using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class GeneralModifierExtensions
    {
        public static T AsStatic<T>(this IStaticModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifier.AsStatic((T)@base);
        }

        public static T AsAbstract<T>(this IAbstractModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifier.AsAbstract((T)@base);
        }

        public static T AsPartial<T>(this IPartialModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifier.AsPartial((T)@base);
        }

        public static T AsSealed<T>(this ISealedModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifier.AsSealed((T)@base);
        }

        public static T AsReadOnly<T>(this IReadOnlyModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifier.AsReadOnly((T)@base);
        }

        public static T AsVirtual<T>(this IVirtualModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifier.AsVirtual((T)@base);
        }

        public static T AsOverride<T>(this IOverrideModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifier.AsOverride((T)@base);
        }

        public static T AsAsync<T>(this IAsyncModifier<T> @base, bool enforceTaskReturnType = true) where T : SourceContainer
        {
            if(@base as IHasReturnValue != null)
            {
                ((IHasReturnValue)@base).ReturnType.EnforceAsync(enforceTaskReturnType);
            }

            return @base.GeneralModifier.AsAsync((T)@base, enforceTaskReturnType);
        }
    }
}
