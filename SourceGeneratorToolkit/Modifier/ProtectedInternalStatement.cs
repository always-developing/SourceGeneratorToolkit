using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ProtectedInternalStatement : AccessModifierStatement
    {
        internal override string Name => nameof(ProtectedInternalStatement);

        public ProtectedInternalStatement()
        {
            SourceText = "protected internal ";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
