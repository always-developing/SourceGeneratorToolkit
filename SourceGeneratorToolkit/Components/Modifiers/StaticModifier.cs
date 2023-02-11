using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class StaticModifier : ISourceStatement
    {
        public string Name => nameof(PublicModifier);

        public int Order { get; set; } = 1;

        public string GenerateSource()
        {
            return "static";
        }
    }
}
