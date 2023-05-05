namespace SourceGeneratorToolkit
{
    internal class BracketEndStatement : SourceStatement
    {
        internal override string Name => nameof(BracketEndStatement);

        public BracketEndStatement()
        {
            SourceText = "]";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
