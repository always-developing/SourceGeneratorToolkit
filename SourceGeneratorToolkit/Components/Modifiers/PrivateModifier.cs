namespace SourceGeneratorToolkit
{
    public class PrivateModifier : ISourceStatement
    {
        public string Name => nameof(PrivateModifier);

        public int Order { get; set; } = 0;

        public string GenerateSource()
        {
            return "private";
        }
    }
}
