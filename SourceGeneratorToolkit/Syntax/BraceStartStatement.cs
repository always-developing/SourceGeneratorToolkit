using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit.Syntax
{
    internal class BraceStartStatement : SourceStatement
    {
        internal override string Name => nameof(BraceStartStatement);

        public BraceStartStatement()
        {
            SourceText = "{";
        }
    }
}
