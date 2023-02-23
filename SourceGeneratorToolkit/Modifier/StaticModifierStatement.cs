using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class StaticModifierStatement : SourceStatement
    {
        internal override string Name => nameof(StaticModifierStatement);

        public StaticModifierStatement()
        {
            SourceText = "static ";
            Order = 4;
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append(SourceText);

            return sb.ToString();
        }
    }
}
