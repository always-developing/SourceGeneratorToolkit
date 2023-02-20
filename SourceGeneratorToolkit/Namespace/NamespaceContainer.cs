using SourceGeneratorToolkit.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class NamespaceContainer : SourceContainer
    {
        internal override string Name => nameof(NamespaceContainer);

        public NamespaceContainer(string @namespace)
        {
            SourceText = @namespace;
        }

        public NamespaceContainer AddClass(string className, Action<ClassContainer> classBuilder)
        {
            var ns = new ClassContainer(className);
            SourceItems.Add(ns);

            classBuilder.Invoke(ns);

            return this;
        }
    }
}
