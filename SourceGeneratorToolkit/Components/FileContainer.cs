using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FileContainer : SourceContainer
    {
        public override string Name => nameof(FileContainer);

        public override int Order { get; set; } = 0;

        internal string FileName { get; set; }

        public FileContainer(string fileName = "")
        {
            SetFileName(fileName);
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
