using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class AbstractModifierStatement : SourceStatement
    {
        internal override string Name => nameof(AbstractModifierStatement);

        public AbstractModifierStatement()
        {
            SourceText = "abstract ";
            Order = 1;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
