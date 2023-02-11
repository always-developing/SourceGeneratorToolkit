using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISourceContainer : ISourceStatement
    {
        List<ISourceStatement> SourceItems { get; }
    }
}
