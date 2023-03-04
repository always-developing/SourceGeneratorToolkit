using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class ChevronStartStatement : SourceStatement
    {
        internal override string Name => nameof(ChevronStartStatement);

        public ChevronStartStatement()
        {
            SourceText = "<";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
