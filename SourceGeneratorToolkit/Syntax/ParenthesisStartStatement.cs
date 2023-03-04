using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class ParenthesisStartStatement : SourceStatement
    {
        internal override string Name => nameof(ParenthesisStartStatement);

        public ParenthesisStartStatement()
        {
            SourceText = "(";
        }
    }
}
