using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ProtectedModifierStatement : AccessModifierStatement
    {
        internal override string Name => nameof(ProtectedModifierStatement);

        public ProtectedModifierStatement()
        {
            SourceText = "protected ";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
