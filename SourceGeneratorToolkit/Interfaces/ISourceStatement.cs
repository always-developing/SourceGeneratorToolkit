using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISourceStatement
    {
        string Name { get; }

        int Order { get; set; }

        string GenerateSource();
    }
}
