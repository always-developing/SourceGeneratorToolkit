using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for the documentation container
    /// </summary>
    public static class DocumentationExtensions
    {
        /// <summary>
        /// Adds documentation to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="builder">The builder used to modify the properties of the documentation</param>
        /// <returns>he parent container</returns>
        public static TContainer AddDocumentation<TContainer>(this ISupportsDocumentation<TContainer> @base, Action<DocumentationContainer> builder) where TContainer : SourceContainer
        {
            builder?.Invoke(@base.Documentation);

            return (TContainer)@base;
        }
    }
}
