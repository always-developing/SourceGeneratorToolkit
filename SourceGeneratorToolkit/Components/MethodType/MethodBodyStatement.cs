using SourceGeneratorToolkit.Containers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodBodyStatement : ISourceStatement
    {
        public string Name => nameof(MethodBodyStatement);

        public int Order { get; set; } = 1;

        private readonly string _sourceText;

        public MethodBodyStatement(string sourceText)
        {
            _sourceText = sourceText;
        }

        public string GenerateSource()
        {
            return _sourceText;
        }
    }
}
