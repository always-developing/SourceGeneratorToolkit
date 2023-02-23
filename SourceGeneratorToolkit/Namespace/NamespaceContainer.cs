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

        internal AccessModifierStatement _accessModifier;

        public NamespaceContainer(string @namespace)
        {
            SourceText = @namespace;
        }
        public NamespaceContainer WithClass(string className, Action<ClassContainer> classBuilder)
        {
            var classContainer = new ClassContainer(className);

            if (this is TraditionalNamespaceContainer)
            {
                classContainer.IndentLevel = this.IndentLevel + 1;
            }

            this.SourceItems.Add(classContainer);
            classBuilder.Invoke(classContainer);

            return this;
        }

        public NamespaceContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement();
            return this;
        }

        public NamespaceContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }
    }
}
