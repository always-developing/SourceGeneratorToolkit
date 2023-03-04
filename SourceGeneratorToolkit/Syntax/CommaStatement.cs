using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class CommaStatement : SourceStatement
    {
        internal override string Name => nameof(CommaStatement);

        public CommaStatement()
        {
            SourceText = ", ";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
