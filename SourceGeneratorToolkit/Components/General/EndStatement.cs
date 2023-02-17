using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit
{
    internal class EndStatement : SourceStatement
    {
        public override string Name => nameof(EndStatement);

        public override int Order { get; set; } = int.MaxValue;

        private const string _endBrace = ";";

        public EndStatement(int order)
        {
            Order = order;
            SourceText = _endBrace;
        }

        public EndStatement()
        {
            SourceText = _endBrace;
        }
    }
}
