using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit
{
    public class PartialModifier : SourceStatement
    {
        public override string Name => nameof(PartialModifier);

        public override int Order { get; set; } = 2;

        public PartialModifier()
        {
            SourceText = "partial";
        }
    }
}
