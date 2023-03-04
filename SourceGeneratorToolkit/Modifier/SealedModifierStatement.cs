using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class SealedModifierStatement : SourceStatement
    {
        internal override string Name => nameof(SealedModifierStatement);

        public SealedModifierStatement()
        {
            SourceText = "sealed ";
            Order = 3;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
