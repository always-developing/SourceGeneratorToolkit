using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class NamespaceExtensions
    {
        public static NamespaceContainer WithClass(this NamespaceContainer namespaceContainer, string className)
        {
            return namespaceContainer;
        }
    }
}
