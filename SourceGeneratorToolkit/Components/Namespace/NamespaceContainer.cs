using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class NamespaceContainer : SourceContainer
    {
        public override string Name => nameof(NamespaceContainer);

        public override int Order { get; set; } = 1;

        public bool FileScoped { get;  }

        public NamespaceContainer(bool fileScoped)
        {
            FileScoped = fileScoped;
        }
    }
}
