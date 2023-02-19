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

        public override string ToSource()
        {
            var sb = IndentedStringBuilder();

            sb.AppendLine($"namespace {SourceText}");

            this.SourceItems.Insert(0, new BraceStartStatement());
            this.SourceItems.Add(new BraceEndStatement());

            sb.AppendLine(base.ToSource());

            return sb.ToString();
        }
    }
}
