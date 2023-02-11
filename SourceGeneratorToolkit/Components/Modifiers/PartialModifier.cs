using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class PartialModifier : ISourceStatement
    {
        public string Name => nameof(PartialModifier);

        public int Order { get; set; } = 2;

        public string GenerateSource()
        {
            return "partial";
        }
    }
}
