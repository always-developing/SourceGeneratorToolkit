using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
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
            return SourceText;
        }
    }
}
