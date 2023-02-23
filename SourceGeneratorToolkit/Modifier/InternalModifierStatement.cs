using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class InternalModifierStatement : AccessModifierStatement
    {
        internal override string Name => nameof(InternalModifierStatement);

        public InternalModifierStatement()
        {
            SourceText = "internal ";
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append(SourceText);

            return sb.ToString();
        }
    }
}
