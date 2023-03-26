using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class GeneralModifierExtensions
    {
        public static T AsStatic<T>(this IStaticModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifiers.AsStatic((T)@base);
        }

        public static T AsAbstract<T>(this IAbstractModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifiers.AsAbstract((T)@base);
        }

        public static T AsPartial<T>(this IPartialModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifiers.AsPartial((T)@base);
        }

        public static T AsSealed<T>(this ISealedModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifiers.AsSealed((T)@base);
        }

        public static T AsReadOnly<T>(this IReadOnlyModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifiers.AsReadOnly((T)@base);
        }

        public static T AsVirtual<T>(this IVirtualModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifiers.AsVirtual((T)@base);
        }

        public static T AsOverride<T>(this IOverrideModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifiers.AsOverride((T)@base);
        }

        public static T AsAsync<T>(this IAsyncModifier<T> @base, bool enforceTaskReturnType = true) where T : SourceContainer
        {
            if(@base as ISupportsReturnValue != null)
            {
                ((ISupportsReturnValue)@base).ReturnType.EnforceAsync(enforceTaskReturnType);
            }

            // TODO: something better here
            if (@base as InterfaceMethodContainer == null)
            {
                return @base.GeneralModifiers.AsAsync((T)@base, enforceTaskReturnType);
            }

            return (T)@base;
        }
    }
}
