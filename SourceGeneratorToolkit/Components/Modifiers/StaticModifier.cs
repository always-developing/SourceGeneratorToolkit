using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class StaticModifier : SourceStatement
    {
        public override string Name => nameof(PublicModifier);

        public override int Order { get; set; } = 1;

        public StaticModifier()
        {
            SourceText = "static";
        }
    }
}
