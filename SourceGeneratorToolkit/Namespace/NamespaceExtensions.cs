using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class NamespaceExtensions
    {
        public static NamespaceContainer WithClass(this NamespaceContainer namespaceContainer, 
            string className, Action<ClassContainer> classBuilder)
        {
            var classContainer = new ClassContainer(className);

            if (namespaceContainer is TraditionalNamespaceContainer)
            {
                classContainer.IndentLevel = namespaceContainer.IndentLevel + 1;
            }

            namespaceContainer.SourceItems.Add(classContainer);
            classBuilder.Invoke(classContainer);

            return namespaceContainer;
        }
    }
}
