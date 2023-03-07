using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class EqualsStatement : SourceStatement
    {
        internal override string Name => nameof(EqualsStatement);

        public EqualsStatement()
        {
            SourceText = "=";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
