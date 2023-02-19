using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit.Syntax
{
    internal class BraceEndStatement : SourceStatement
    {
        internal override string Name => nameof(BraceEndStatement);

        public BraceEndStatement()
        {
            SourceText = "}";
        }

        public override string ToSource()
        {
            StringBuilder sb = IndentedStringBuilder();

            sb.Append(SourceText);

            return sb.ToString();
        }
    }
}
