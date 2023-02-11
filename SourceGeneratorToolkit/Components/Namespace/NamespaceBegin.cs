using System.Globalization;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class NamespaceBegin : SourceStatement
    {
        public override string Name => nameof(NamespaceBegin);

        public override int Order { get; set; } = 0;

        private bool _fileScoped = true;

        public NamespaceBegin(string @namespace, bool fileScoped)
        {
            _fileScoped = fileScoped;
            SourceText = @namespace;
        }

        public override string GenerateSource()
        {
            var sb = new StringBuilder();

            if (_fileScoped)
            {
                sb.AppendLine($"namespace {SourceText};");
            }
            else
            {
                sb.AppendLine($"namespace {SourceText}");
                sb.AppendLine("{");
            }

            return sb.ToString();
        }
    }
}
