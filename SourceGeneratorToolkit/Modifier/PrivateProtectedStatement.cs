using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class PrivateProtectedStatement : AccessModifierStatement
    {
        internal override string Name => nameof(PrivateProtectedStatement);

        public PrivateProtectedStatement()
        {
            SourceText = "private protected ";
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append(SourceText);

            return sb.ToString();
        }
    }
}
