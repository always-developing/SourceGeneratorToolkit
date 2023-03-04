using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class PartialModifierStatement : SourceStatement
    {
        internal override string Name => nameof(PartialModifierStatement);

        public PartialModifierStatement()
        {
            SourceText = "partial ";
            Order = 2;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
