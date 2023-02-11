using System.Text;

namespace SourceGeneratorToolkit
{
    internal class NamespaceBegin : ISourceStatement
    {
        public string Name => nameof(NamespaceBegin);

        public int Order { get; set; } = 0;

        private bool _fileScoped = true;

        private string _namespace;

        public NamespaceBegin(string @namespace, bool fileScoped)
        {
            _fileScoped = fileScoped;
            _namespace = @namespace;
        }

        public string GenerateSource()
        {
            var sb = new StringBuilder();

            if (_fileScoped)
            {
                sb.AppendLine($"namespace {_namespace};");
            }
            else
            {
                sb.AppendLine($"namespace {_namespace}");
                sb.AppendLine("{");
            }

            return sb.ToString();
        }
    }
}
