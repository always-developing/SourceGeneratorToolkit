using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class Generator : SourceContainer
    {
        internal override string Name => nameof(Generator);

        public Generator WithFile(string fileName, Action<FileContainer> file)
        {
            var internalFile = new FileContainer(fileName);
            SourceItems.Add(internalFile);

            file.Invoke(internalFile);

            return this;
        }
    }
}
