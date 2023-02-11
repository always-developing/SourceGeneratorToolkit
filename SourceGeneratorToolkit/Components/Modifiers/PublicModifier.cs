namespace SourceGeneratorToolkit
{
    public class PublicModifier : ISourceStatement
    {
        public string Name => nameof(PublicModifier);

        public int Order { get; set; } = 0;

        public string GenerateSource()
        {
            return "public";
        }
    }
}
