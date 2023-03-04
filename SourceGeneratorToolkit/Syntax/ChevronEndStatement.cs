using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class ChevronEndStatement : SourceStatement
    {
        internal override string Name => nameof(ChevronEndStatement);

        public ChevronEndStatement()
        {
            SourceText = ">";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
