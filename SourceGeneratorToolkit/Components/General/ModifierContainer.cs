using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ModifierContainer : SourceContainer
    {
        public override string Name => nameof(ModifierContainer);

        public override int Order { get; set; } = 1;

        public override string GenerateSource()
        {
            var sb = new StringBuilder();

            foreach (var modifier in SourceItems.OrderBy(m => m.Order))
            {
                sb.Append($"{modifier.GenerateSource()} ");
            }

            return sb.ToString();
        }
    }
}
