namespace SourceGeneratorToolkit
{
    public class PrivateModifier : SourceStatement
    {
        public override string Name => nameof(PrivateModifier);

        public override int Order { get; set; } = 0;

        public PrivateModifier()
        {
            SourceText = "private"; 
        }
    }
}
