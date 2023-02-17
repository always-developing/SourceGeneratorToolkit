using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodBodyStatement : SourceStatement
    {
        public override string Name => nameof(MethodBodyStatement);

        public override int Order { get; set; } = 1;

        public MethodBodyStatement(string sourceText)
        {
            SourceText = sourceText;
        }
    }
}
