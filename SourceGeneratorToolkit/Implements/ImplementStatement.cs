using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ImplementStatement : SourceStatement
    {
        internal override string Name => nameof(ImplementStatement);

        public ImplementStatement(string implements)
        {
            SourceText = implements;
        }
    }
}
