namespace SourceGeneratorToolkit
{
    internal class SemiColonStatement : SourceStatement
    {
        internal override string Name => nameof(SemiColonStatement);

        public SemiColonStatement()
        {
            SourceText = ";";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
