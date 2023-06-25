using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensions for implementations
    /// </summary>
    public static class ImplementExtensions
    {
        /// <summary>
        /// Adds an implementation to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="value">The implementation value</param>
        /// <returns>The parent type</returns>
        public static TContainer WithImplementation<TContainer>(this ISupportsImplementation<TContainer> @base, string value) where TContainer : SourceContainer
        {
            @base.Implements.AddImplements(value);

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds an implementation to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="value">The implementation value type</param>
        /// <returns>The parent type</returns>
        public static TContainer WithImplementation<TContainer>(this ISupportsImplementation<TContainer> @base, Type value) where TContainer : SourceContainer
        {
            @base.Implements.AddImplements(value.Name);

            return (TContainer)@base;
        }
    }
}
