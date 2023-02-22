using SourceGeneratorToolkit.Syntax;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        //public NamespaceContainer AddClass(string className, Action<ClassContainer> classBuilder)
        //{
        //    ClassContainer ns = this is TraditionalNamespaceContainer ? new ClassContainer(className, this.IndentLevel + 1)
        //        : new ClassContainer(className, this.IndentLevel);

        //    SourceItems.Add(ns);

        //    classBuilder.Invoke(ns);

        //    return this;
        //}
    }
}
