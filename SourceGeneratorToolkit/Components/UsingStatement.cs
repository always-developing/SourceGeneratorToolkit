namespace SourceGeneratorToolkit.Components
{
    public class UsingStatement : ISourceStatement
    {
        public string Name => nameof(UsingStatement);

        public int Order { get; set;  } = 1;

        private readonly string _using;

        public UsingStatement(string @using)
        {
            _using = @using;
        }

        public string GenerateSource()
        {
            return $"using {_using};";
        }
    }
}
