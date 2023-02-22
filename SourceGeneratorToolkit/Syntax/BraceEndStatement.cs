using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit.Syntax
{
    internal class BraceEndStatement : SourceStatement
    {
        internal override string Name => nameof(BraceEndStatement);

        public BraceEndStatement(int intentLevel)
        {
            SourceText = "}";
            IndentLevel = intentLevel;
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.AppendLine(SourceText);

            return sb.ToString();
        }
    }
}
