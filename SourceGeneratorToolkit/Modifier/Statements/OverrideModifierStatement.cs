using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class OverrideModifierStatement : SourceStatement
    {
        internal override string Name => nameof(OverrideModifierStatement);

        public OverrideModifierStatement()
        {
            SourceText = "override ";
            Order = 4;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
