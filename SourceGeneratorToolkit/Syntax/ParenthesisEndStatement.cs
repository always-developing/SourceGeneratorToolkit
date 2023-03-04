using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class ParenthesisEndStatement : SourceStatement
    {
        internal override string Name => nameof(ParenthesisEndStatement);

        public ParenthesisEndStatement()
        {
            SourceText = ")";
        }
    }
}
