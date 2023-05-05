namespace SourceGeneratorToolkit
{
    internal class EqualsStatement : SourceStatement
    {
        internal override string Name => nameof(EqualsStatement);

        public EqualsStatement()
        {
            SourceText = "=";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
