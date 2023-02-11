namespace SourceGeneratorToolkit
{
    public class PublicModifier : SourceStatement
    {
        public override string Name => nameof(PublicModifier);

        public override int Order { get; set; } = 0;

        public PublicModifier()
        {
            SourceText = "public";
        }
    }
}
