using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class Statement : SourceStatement
    {
        internal override string Name => nameof(Statement);

        public Statement(string statement)
        {
            SourceText = statement;
        }
    }
}
