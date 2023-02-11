namespace SourceGeneratorToolkit
{
    internal class LambdaStatement : ISourceStatement
    {
        public string Name => nameof(LambdaStatement);

        public int Order { get; set; } = 0;

        public string GenerateSource()
        {
            return " =>";
        }
    }
}