namespace SourceGeneratorToolkit
{
    internal class BraceEndStatement : ISourceStatement
    {
        public string Name => nameof(BraceEndStatement);

        public int Order { get; set; } = int.MaxValue;

        public string GenerateSource()
        {
            return "}";
        }
    }
}
