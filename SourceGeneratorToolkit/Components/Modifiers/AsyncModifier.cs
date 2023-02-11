using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class AsyncModifier : ISourceStatement
    {
        public string Name => nameof(AsyncModifier);

        public int Order { get; set; } = 3;

        public string GenerateSource()
        {
            return "async";
        }
    }
}
