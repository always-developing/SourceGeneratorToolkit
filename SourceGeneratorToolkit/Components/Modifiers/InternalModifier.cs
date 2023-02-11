namespace SourceGeneratorToolkit
{
    public class InternalModifier : ISourceStatement
    {
        public string Name => nameof(InternalModifier);

        public int Order { get; set; } = 0;

        public string GenerateSource()
        {
            return "internal";
        }
    }
}
