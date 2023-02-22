using SourceGeneratorToolkit.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FilescopedNamespaceContainer : NamespaceContainer
    {
        internal override string Name => nameof(FilescopedNamespaceContainer);

        public FilescopedNamespaceContainer(string @namespace) : base(@namespace) 
        { 
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.AppendLine($"namespace {SourceText};");
            sb.Append(new NewLineStatement().ToSource());
            sb.AppendLine(base.ToSource());

            return sb.ToString();
        }
    }
}
