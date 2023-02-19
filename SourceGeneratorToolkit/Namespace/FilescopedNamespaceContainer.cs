using SourceGeneratorToolkit.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FilescopedNamespaceContainer : SourceContainer
    {
        internal override string Name => nameof(FilescopedNamespaceContainer);

        public FilescopedNamespaceContainer(string @namespace)
        {
            SourceText = @namespace;
        }

        public override string ToSource()
        {
            var sb = IndentedStringBuilder();

            sb.AppendLine($"namespace {SourceText};");
            sb.AppendLine(base.ToSource());

            return sb.ToString();
        }
    }
}
