using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ProtectedModifier : SourceStatement
    {
        public override string Name => nameof(ProtectedModifier);

        public override int Order { get; set; } = 0;

        public ProtectedModifier()
        {
            SourceText = "protected";
        }
    }
}
