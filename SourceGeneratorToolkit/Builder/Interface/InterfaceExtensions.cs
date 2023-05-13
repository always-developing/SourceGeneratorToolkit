using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensiosn for interfaces
    /// </summary>
    public static class InterfaceExtensions
    {
        /// <summary>
        /// Adds an interface to the namespace
        /// </summary>
        /// <typeparam name="TContainer">The parent container</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="interfaceName">The name of the interface</param>
        /// <param name="builder">The builder used to modify the properties of the interface</param>
        /// <returns>The namespace container</returns>
        public static TContainer WithInterface<TContainer>(this ISupportsInterfaces<TContainer> @base, string interfaceName, Action<InterfaceContainer> builder) where TContainer : SourceContainer
        {
            var interfaceContainer = new InterfaceContainer(interfaceName);

            ((SourceContainer)@base)._sourceItems.Add(interfaceContainer);
            builder.Invoke(interfaceContainer);

            return (TContainer)@base;
        }
    }
}
