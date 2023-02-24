using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class GenericStatement : SourceStatement
    {
        internal override string Name => nameof(GenericStatement);

        public GenericStatement(string genericsValue)
        {
            SourceText = genericsValue;
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append(SourceText);

            return sb.ToString();
        }
    }
}
