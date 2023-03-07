using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class ReadOnlyModifierStatement : SourceStatement
    {
        internal override string Name => nameof(ReadOnlyModifierStatement);

        public ReadOnlyModifierStatement()
        {
            SourceText = "readonly ";
            Order = 5;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
