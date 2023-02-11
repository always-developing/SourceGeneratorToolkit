namespace SourceGeneratorToolkit
{
    public class InternalModifier : SourceStatement
    {
        public override string Name => nameof(InternalModifier);

        public override int Order { get; set; } = 0;

        public InternalModifier()
        {
            SourceText = "internal";
        }
    }
}
