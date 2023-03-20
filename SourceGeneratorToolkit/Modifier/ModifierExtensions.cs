using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class ModifierExtensions
    {
        public static T AsStatic<T>(this IStaticModifier<T> @base) where T : SourceContainer
        {
            return @base.GeneralModifier.AsStatic((T)@base);
        }
    }
}
