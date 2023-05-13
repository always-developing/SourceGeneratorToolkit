namespace SourceGeneratorToolkit
{
    internal class ParenthesisStartStatement : SourceStatement
    {
        internal override string Name => nameof(ParenthesisStartStatement);

        public ParenthesisStartStatement()
        {
            SourceText = "(";
        }
    }
}
