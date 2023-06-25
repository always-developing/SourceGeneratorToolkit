using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for the attribute container
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// Adds an attribute to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="builder">The builder used to modify the properties of the attribute</param>
        /// <returns>The parent container</returns>
        public static TContainer AddAttribute<TContainer>(this ISupportsAttributes<TContainer> @base, string attributeName, Action<AttributeStatement> builder = null) 
            where TContainer : SourceContainer
        {
            var attribute = @base.AttributeList.AddAttribute(attributeName);
            builder?.Invoke(attribute);

            return (TContainer)@base;
        }
    }
}
