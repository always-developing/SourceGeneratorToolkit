using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class NamespaceContainer : ISourceContainer
    {
        public string Name => nameof(NamespaceContainer);

        public int Order { get; set; } = 1;

        public List<ISourceStatement> SourceItems { get; }

        public bool FileScoped { get;  }

        public NamespaceContainer(bool fileScoped)
        {
            SourceItems = new List<ISourceStatement>();
            FileScoped = fileScoped;
        }

        public string GenerateSource()
        {
            var sb = new StringBuilder();

            foreach (var generator in SourceItems.OrderBy(s => s.Order))
            {
                sb.AppendLine(generator.GenerateSource());
            }

            return sb.ToString();
        }
    }
}
