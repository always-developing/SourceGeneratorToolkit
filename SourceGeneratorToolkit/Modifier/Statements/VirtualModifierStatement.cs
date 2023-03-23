using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class VirtualModifierStatement : SourceStatement
    {
        internal override string Name => nameof(VirtualModifierStatement);

        public VirtualModifierStatement()
        {
            SourceText = "virtual ";
            Order = 4;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
