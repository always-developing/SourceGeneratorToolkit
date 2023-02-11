using System.Reflection.Metadata;

namespace SourceGeneratorToolkit
{
    internal class BraceEndStatement : SourceStatement
    {
        public override string Name => nameof(BraceEndStatement);

        public override int Order { get; set; } = int.MaxValue;

        private const string _endBrace = "}";

        public BraceEndStatement()
        {
            SourceText = _endBrace;
        }
    }
}
