using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class NamespaceContainer : SourceContainer, ISupportsComments<NamespaceContainer>, ISupportsStatement<NamespaceContainer>
    {
        internal override string Name => nameof(NamespaceContainer);

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

        public NamespaceContainer WithStruct(string structName, Action<StructContainer> structBuilder)
        {
            var structContainer = new StructContainer(structName);

            _sourceItems.Add(structContainer);
            structBuilder.Invoke(structContainer);

            return this;
        }

        public NamespaceContainer WithRecord(string recordName, Action<RecordContainer> recordBuilder)
        {
            var recordContainer = new RecordContainer(recordName);

            _sourceItems.Add(recordContainer);
            recordBuilder.Invoke(recordContainer);

            return this;
        }

        public NamespaceContainer WithInterface(string interfaceName, Action<InterfaceContainer> builder)
        {
            var interfaceContainer = new InterfaceContainer(interfaceName);

            _sourceItems.Add(interfaceContainer);
            builder.Invoke(interfaceContainer);

            return this;
        }

        public NamespaceContainer WithEnum(string enumName, Action<EnumContainer> builder)
        {
            var enumContainer = new EnumContainer(enumName);

            _sourceItems.Add(enumContainer);
            builder.Invoke(enumContainer);

            return this;
        }

        public NamespaceContainer WithEnum(string enumName, string type, Action<EnumContainer> builder)
        {
            var enumContainer = new EnumContainer(enumName, type);

            _sourceItems.Add(enumContainer);
            builder.Invoke(enumContainer);

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
