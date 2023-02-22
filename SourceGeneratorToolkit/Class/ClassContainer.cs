using SourceGeneratorToolkit.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ClassContainer : SourceContainer
    {
        internal override string Name => nameof(ClassContainer);

        public ClassContainer(string className)
        {
            SourceText = className;
        }

        public override string ToSource()
        {
            var sb = new  IndentedStringBuilder(IndentLevel);

            sb.AppendLine($"class {SourceText}");
            
            sb.Append(new BraceStartStatement().ToSource());
            sb.AppendLine(base.ToSource());
            sb.Append(new BraceEndStatement(0).ToSource());

            return sb.ToString();
        }
    }
}
