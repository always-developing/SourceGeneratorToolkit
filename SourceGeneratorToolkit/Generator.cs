using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class Generator : SourceContainer
    {
        internal override string Name => nameof(Generator);

        public Generator WithFile(string fileName, Action<FileContainer> fileBuilder)
        {
            var internalFile = new FileContainer(fileName);
            _sourceItems.Add(internalFile);

            fileBuilder.Invoke(internalFile);

            return this;
        }
    }
}
