using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class EmptySpaceStatement : SourceStatement
    {
        internal override string Name => nameof(EmptySpaceStatement);

        public EmptySpaceStatement()
        {
            SourceText = " ";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
