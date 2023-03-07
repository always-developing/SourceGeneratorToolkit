using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ProtectedInternalModifierStatement : AccessModifierStatement
    {
        internal override string Name => nameof(ProtectedInternalModifierStatement);

        public ProtectedInternalModifierStatement()
        {
            SourceText = "protected internal ";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
