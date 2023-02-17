using System;

namespace SourceGeneratorToolkit
{
    public static class ClassExtensions
    {
        public static NamespaceContainer WithClass(this NamespaceContainer container, string className, Action<ClassContainer> content)
        {
            var clsContainer = new ClassContainer(className, 
                container.Filescoped ? container.IndentLevel : container.IndentLevel + 1);
            container.SourceItems.Add(clsContainer);

            content.Invoke(clsContainer);

            return container;
        }
    }
}
