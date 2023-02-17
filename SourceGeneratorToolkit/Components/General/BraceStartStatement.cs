using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class BraceStartStatement : SourceStatement
    {
        public override string Name => nameof(BraceEndStatement);

        public override int Order { get; set; } = int.MinValue;

        private const string _endBrace = "{";

        public BraceStartStatement()
        {
            SourceText = _endBrace;
        }
    }
}
