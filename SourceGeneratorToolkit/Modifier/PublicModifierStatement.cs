using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class PublicModifierStatement : AccessModifierStatement
    {
        internal override string Name => nameof(PublicModifierStatement);

        public PublicModifierStatement()
        {
            SourceText = "public ";
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append(SourceText);

            return sb.ToString();
        }
    }
}
