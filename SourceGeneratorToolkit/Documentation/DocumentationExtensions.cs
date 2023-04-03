using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class DocumentationExtensions
    {
        public static T AddDocumentation<T>(this ISupportsDocumentation<T> @base, Action<DocumentationContainer> docContainer) where T : SourceContainer
        {
            docContainer?.Invoke(@base.Documentation);

            return (T)@base;
        }
    }
}
