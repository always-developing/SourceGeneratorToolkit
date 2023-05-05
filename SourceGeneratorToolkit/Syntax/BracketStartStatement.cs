namespace SourceGeneratorToolkit
{
    internal class BracketStartStatement : SourceStatement
    {
        internal override string Name => nameof(BracketStartStatement);

        public BracketStartStatement()
        {
            SourceText = "[";
        }
    }
}
