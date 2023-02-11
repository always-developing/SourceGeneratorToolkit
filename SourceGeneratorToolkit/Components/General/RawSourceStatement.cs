using System.Collections.Generic;

namespace SourceGeneratorToolkit
{
    public class RawSourceStatement : SourceStatement
    {
        public override string Name => nameof(RawSourceStatement);

        public override int Order { get; set; } = 1;

        public RawSourceStatement(string sourceText, int order = 1)
        {
            SourceText = sourceText;
            Order = order;
        }

        public override string GenerateSource()
        {
            return SourceText;
        }
    }
}
