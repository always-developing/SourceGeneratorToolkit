using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class AttributeExtensions
    {
        public static T AddAttribute<T>(this ISupportsAttributes<T> @base, string attributeName, Action<AttributeStatement> builder = null) 
            where T : SourceContainer
        {
            var attribute = @base.AttributeList.AddAttribute(attributeName);
            builder?.Invoke(attribute);

            return (T)@base;
        }
    }
}
