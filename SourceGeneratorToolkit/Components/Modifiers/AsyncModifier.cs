using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit
{
    internal class AsyncModifier : SourceStatement
    {
        public override string Name => nameof(AsyncModifier);

        public override int Order { get; set; } = 3;

        public AsyncModifier()
        {
            SourceText = "async";
        }
    }
}
