using System.Collections.Generic;

namespace SourceGeneratorToolkit.Containers
{
    public class RawSourceContainer : ISourceContainer
    {
        public string Name => nameof(RawSourceContainer);

        public int Order { get; set; } = 1;

        public List<ISourceStatement> SourceItems { get; }

        private readonly string _sourceText;

        public RawSourceContainer(string sourceText, int order = 1)
        {
            _sourceText = sourceText;
            this.Order = order;
        }

        public string GenerateSource()
        {
            return _sourceText;
        }
    }
}
