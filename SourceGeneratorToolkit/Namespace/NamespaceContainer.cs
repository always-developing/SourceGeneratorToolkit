using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class NamespaceContainer : SourceContainer, IPublicModifier<NamespaceContainer>, IInternalModifier<NamespaceContainer>, 
        ISupportsComments<NamespaceContainer>
    {
        internal override string Name => nameof(NamespaceContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public NamespaceContainer(string @namespace)
        {
            SourceText = @namespace;
        }

        public NamespaceContainer WithClass(string className, Action<ClassContainer> classBuilder)
        {
            var classContainer = new ClassContainer(className);

            _sourceItems.Add(classContainer);
            classBuilder.Invoke(classContainer);

            return this;
        }

        public NamespaceContainer WithInterface(string interfaceName, Action<InterfaceContainer> builder)
        {
            var interfaceContainer = new InterfaceContainer(interfaceName);

            _sourceItems.Add(interfaceContainer);
            builder.Invoke(interfaceContainer);

            return this;
        }

        public NamespaceContainer WithNamespace(string @namespace, Action<NamespaceContainer> nsBuilder)
        {
            var ns = new TraditionalNamespaceContainer(@namespace);
            _sourceItems.Add(ns);

            nsBuilder.Invoke(ns);

            return this;
        }

        public NamespaceContainer WithFilescopedNamespace(string @namespace, Action<NamespaceContainer> nsBuilder)
        {
            var ns = new FilescopedNamespaceContainer(@namespace);
            _sourceItems.Add(ns);

            nsBuilder.Invoke(ns);

            return this;
        }
    }
}
