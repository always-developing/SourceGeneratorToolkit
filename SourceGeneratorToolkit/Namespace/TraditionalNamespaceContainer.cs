using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class TraditionalNamespaceContainer : NamespaceContainer
    {
        public TraditionalNamespaceContainer(string @namespace) : base(@namespace)
        {
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append($"{_accessModifier?.ToSource()}");
            sb.AppendLine($"namespace {SourceText}");

            this.SourceItems.Insert(0, new BraceStartStatement());
            this.SourceItems.Add(new BraceEndStatement(IndentLevel));

            sb.AppendLine(base.ToSource());

            return sb.ToString();
        }
    }
}
