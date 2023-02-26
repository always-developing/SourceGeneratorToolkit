using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class GenericConstraintStatement : SourceStatement
    {
        internal override string Name => nameof(GenericConstraintStatement);

        public GenericConstraintStatement(string constraints)
        {
            SourceText = constraints;
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append(SourceText);

            return sb.ToString();
        }
    }
}
