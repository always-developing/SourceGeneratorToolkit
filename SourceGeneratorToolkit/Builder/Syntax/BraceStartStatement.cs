namespace SourceGeneratorToolkit
{
    internal class BraceStartStatement : SourceStatement
    {
        internal override string Name => nameof(BraceStartStatement);

        public BraceStartStatement()
        {
            SourceText = "{";
        }
    }
}
