using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class GeneratorConfiguration
    {
        public List<FileContainer> SourceItems = new List<FileContainer>();

        public GeneratorConfiguration()
        {
        }

        public string Build()
        {
            var sb = new StringBuilder();

            foreach (var file in SourceItems)
            {
                sb.Append(file.GenerateSource());
            }

            return sb.ToString();
        }

        
    }
}
