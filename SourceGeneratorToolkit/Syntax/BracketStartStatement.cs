using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class BracketStartStatement : SourceStatement
    {
        internal override string Name => nameof(BracketStartStatement);

        public BracketStartStatement()
        {
            SourceText = "[";
        }
    }
}
