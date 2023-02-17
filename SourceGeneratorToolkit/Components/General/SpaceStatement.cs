using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class SpaceStatement : SourceStatement
    {
        public override string Name => nameof(SpaceStatement);

        public override int Order { get; set; } = 0;

        private const string _space = " ";

        public SpaceStatement(int order)
        {
            Order = order;
            SourceText = _space;
        }

        public SpaceStatement()
        {
            SourceText = _space;
        }
    }
}
