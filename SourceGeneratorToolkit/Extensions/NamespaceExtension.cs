using System;

namespace SourceGeneratorToolkit
{
    public static class NamespaceExtension
    {
        public static FileContainer WithNamespace(this FileContainer container, string @namespace, Action<NamespaceContainer> content, bool fileScoped = true)
        {
            var nsContainer = new NamespaceContainer(fileScoped);
            container.SourceItems.Add(nsContainer);

            nsContainer.SourceItems.Add(new NamespaceBegin(@namespace, fileScoped));

            content.Invoke(nsContainer);

            if(!fileScoped)
            {
                nsContainer.SourceItems.Add(new BraceEndStatement());
            }

            return container;
        }
    }
}
