using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensiosn for namesopaces
    /// </summary>
    public static class NamespaceExtensions
    {
        /// <summary>
        /// Adds a namespace to the file
        /// </summary>
        /// <typeparam name="TContainer">The parent container</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="namespace">The name of the namespace</param>
        /// <param name="builder">The builder used to modify the properties of the namespace</param>
        /// <returns>The file container</returns>
        public static TContainer WithNamespace<TContainer>(this ISupportsNamespaces<TContainer> @base, string @namespace, Action<NamespaceContainer> builder) where TContainer : SourceContainer
        {
            var ns = new TraditionalNamespaceContainer(@namespace);
            ((SourceContainer)@base)._sourceItems.Add(ns);

            builder.Invoke(ns);

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a filescoped namespace to the file
        /// </summary>
        /// <typeparam name="TContainer">The parent container</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="namespace">The name of the namespace</param>
        /// <param name="builder">The builder used to modify the properties of the namespace</param>
        /// <returns>The file container</returns>
        public static TContainer WithFilescopedNamespace<TContainer>(this ISupportsNamespaces<TContainer> @base, string @namespace, Action<NamespaceContainer> builder) where TContainer : SourceContainer
        {
            var ns = new FilescopedNamespaceContainer(@namespace);
            ((SourceContainer)@base)._sourceItems.Add(ns);

            builder.Invoke(ns);

            return (TContainer)@base;
        }
    }
}
