using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FileContainer : ISourceContainer
    {
        public string Name => nameof(FileContainer);

        public int Order { get; set; } = 0;

        public List<ISourceStatement> SourceItems { get; }

        internal string FileName { get; set; }

        public FileContainer(string fileName = "")
        {
            SourceItems = new List<ISourceStatement>();
            SetFileName(fileName);
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

        internal void SetFileName(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName) && fileName.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
            {
                FileName = fileName;

                return;
            }

            if (!string.IsNullOrEmpty(fileName))
            {
                FileName = $"{fileName}.g.cs";

                return;
            }

            FileName = $"{Guid.NewGuid()}.g.cs";
        }
    }
}
