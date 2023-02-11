using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ProtectedModifier : ISourceStatement
    {
        public string Name => nameof(ProtectedModifier);

        public int Order { get; set; } = 0;

        public string GenerateSource()
        {
            return "protected";
        }
    }
}
