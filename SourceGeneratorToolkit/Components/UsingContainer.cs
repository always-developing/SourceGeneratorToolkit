using SourceGeneratorToolkit.Components;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class UsingContainer : ISourceContainer
    {
        public string Name => nameof(UsingContainer);

        public int Order { get; set; } = 0;

        public List<ISourceStatement> SourceItems { get; }

        public UsingContainer(string @using)
        {
            SourceItems = new List<ISourceStatement>();
            SourceItems.Add(new UsingStatement(@using));
        }

        public UsingContainer(params string[] usingStatements)
        {
            SourceItems = new List<ISourceStatement>();
            SourceItems.AddRange(usingStatements.Select(u => new UsingStatement(u)));
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
