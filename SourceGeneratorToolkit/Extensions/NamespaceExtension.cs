using SourceGeneratorToolkit;
using System;

namespace SourceGeneratorToolkit
{
    public static class NamespaceExtension
    {
        public static FileContainer WithNamespace(this FileContainer container, string @namespace, Action<NamespaceContainer> content, bool fileScoped = true)
        {
            var nsContainer = new NamespaceContainer(@namespace, fileScoped);

            if(fileScoped)
            {
                nsContainer.PostStatements.SourceItems.Add(new EndStatement(int.MaxValue - 1));
                nsContainer.SourceItems.Add(new EmptyLineStatement(int.MinValue));
            }
            else
            {
                nsContainer.SourceItems.Add(new BraceStartStatement());
                nsContainer.SourceItems.Add(new EmptyLineStatement(int.MinValue + 1));
                nsContainer.SourceItems.Add(new EmptyLineStatement(int.MaxValue -1));
                nsContainer.SourceItems.Add(new BraceEndStatement());
            }

            container.SourceItems.Add(nsContainer);
            content.Invoke(nsContainer);

            return container;
        }
    }
}
