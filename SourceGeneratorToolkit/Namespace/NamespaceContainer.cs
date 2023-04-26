using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a namespace 
    /// </summary>
    public class NamespaceContainer : SourceContainer, ISupportsComments<NamespaceContainer>, ISupportsStatement<NamespaceContainer>,
        ISupportsClasses<NamespaceContainer>, ISupportsRecords<NamespaceContainer>, ISupportsStructs<NamespaceContainer>,
        ISupportsNamespaces<NamespaceContainer>, ISupportsEnums<NamespaceContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(NamespaceContainer);

        /// <summary>
        /// Creates a namespace namespace
        /// </summary>
        /// <param name="namespace">The name of the namespace</param>
        public NamespaceContainer(string @namespace)
        {
            SourceText = @namespace;
        }

        /// <summary>
        /// Adds an interface to the namespace
        /// </summary>
        /// <param name="interfaceName">The name of the interface</param>
        /// <param name="builder">The builder used to modify the properties of the interface</param>
        /// <returns>The namespace container</returns>
        public NamespaceContainer WithInterface(string interfaceName, Action<InterfaceContainer> builder)
        {
            var interfaceContainer = new InterfaceContainer(interfaceName);

            _sourceItems.Add(interfaceContainer);
            builder.Invoke(interfaceContainer);

            return this;
        }

    }
}
