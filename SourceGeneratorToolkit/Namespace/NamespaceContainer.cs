using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a namespace 
    /// </summary>
    public class NamespaceContainer : SourceContainer, ISupportsComments<NamespaceContainer>, ISupportsStatement<NamespaceContainer>,
        ISupportsClasses<NamespaceContainer>, ISupportsRecords<NamespaceContainer>, ISupportsStructs<NamespaceContainer>,
        ISupportsNamespaces<NamespaceContainer>, ISupportsEnums<NamespaceContainer>, ISupportsInterfaces<NamespaceContainer>
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
    
    }
}
