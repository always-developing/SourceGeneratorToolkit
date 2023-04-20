using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class EnumTypeStatement : SourceStatement
    {
        internal override string Name => nameof(EnumTypeStatement);

        public EnumTypeStatement(string type)
        {
            SourceText = $" : {type}";
        }
    }
}
