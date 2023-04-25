using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a namespace 
    /// </summary>
    public class NamespaceContainer : SourceContainer, ISupportsComments<NamespaceContainer>, ISupportsStatement<NamespaceContainer>,
        ISupportsClasses<NamespaceContainer>, ISupportsRecords<NamespaceContainer>, ISupportsStructs<NamespaceContainer>
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

        /// <summary>
        /// Adds an enum to the namespace
        /// </summary>
        /// <param name="enumName">The name of the enum</param>
        /// <param name="builder">The builder used to modify the properties of the enum</param>
        /// <returns>The namespace container</returns>
        public NamespaceContainer WithEnum(string enumName, Action<EnumContainer> builder)
        {
            var enumContainer = new EnumContainer(enumName);

            _sourceItems.Add(enumContainer);
            builder.Invoke(enumContainer);

            return this;
        }

        /// <summary>
        /// Adds an enum to the namespace, specifying the enum type
        /// </summary>
        /// <param name="enumName">The name of the enum</param>
        /// <param name="type">The type of the enum</param>
        /// <param name="builder">The builder used to modify the properties of the enum</param>
        /// <returns>The namespace container</returns>
        public NamespaceContainer WithEnum(string enumName, string type, Action<EnumContainer> builder)
        {
            var enumContainer = new EnumContainer(enumName, type);

            _sourceItems.Add(enumContainer);
            builder.Invoke(enumContainer);

            return this;
        }

        /// <summary>
        /// Adds a namespace to the namespace
        /// </summary>
        /// <param name="namespace">The name of the namespace</param>
        /// <param name="builder">The builder used to modify the properties of the namespace</param>
        /// <returns>The namespace container</returns>
        public NamespaceContainer WithNamespace(string @namespace, Action<NamespaceContainer> builder)
        {
            var ns = new TraditionalNamespaceContainer(@namespace);
            _sourceItems.Add(ns);

            builder.Invoke(ns);

            return this;
        }

        /// <summary>
        /// Adds a filescoped namespace to the file
        /// </summary>
        /// <param name="namespace">The name of the namespace</param>
        /// <param name="builder">The builder used to modify the properties of the namespace</param>
        /// <returns>The namespace container</returns>
        public NamespaceContainer WithFilescopedNamespace(string @namespace, Action<NamespaceContainer> builder)
        {
            var ns = new FilescopedNamespaceContainer(@namespace);
            _sourceItems.Add(ns);

            builder.Invoke(ns);

            return this;
        }
    }
}
