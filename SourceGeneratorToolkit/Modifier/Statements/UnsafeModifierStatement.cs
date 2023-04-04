using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class UnsafeModifierStatement : SourceStatement
    {
        internal override string Name => nameof(UnsafeModifierStatement);

        public UnsafeModifierStatement()
        {
            SourceText = "unsafe ";
            Order = 3;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
