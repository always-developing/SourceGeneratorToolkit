using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class NamespaceContainer : SourceContainer, ISourcePost
    {
        public override string Name => nameof(NamespaceContainer);

        public override int Order { get; set; } = 1;

        public PostContainer PostStatements { get; } = new PostContainer();

        internal bool Filescoped { get; }

        public NamespaceContainer(string sourceText, bool filescoped = true)
        {
            SourceText = sourceText;
            Filescoped = filescoped;
        }

        public override string GenerateSource()
        {
            var sb = new StringBuilder();

            sb.Append($"namespace {SourceText}");
            sb.Append(PostStatements.GenerateSource());

            sb.AppendLine("");


            foreach (var generator in SourceItems.OrderBy(s => s.Order))
            {
                sb.Append(generator.GenerateSource(), IndentLevel);
            }

            return sb.ToString();
        }
    }
}
