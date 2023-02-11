namespace SourceGeneratorToolkit
{
    public class UsingStatement : SourceStatement
    {
        public override string Name => nameof(UsingStatement);

        public override int Order { get; set; } = 1;

        public UsingStatement(string @using)
        {
            SourceText = @using;
        }

        public override string GenerateSource()
        {
            return $"using {SourceText};";
        }
    }
}
