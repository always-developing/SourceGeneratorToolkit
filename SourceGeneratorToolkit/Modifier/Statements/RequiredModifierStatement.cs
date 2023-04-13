using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class RequiredModifierStatement : SourceStatement
    {
        internal override string Name => nameof(RequiredModifierStatement);

        public RequiredModifierStatement()
        {
            SourceText = "required ";
            Order = 3;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
