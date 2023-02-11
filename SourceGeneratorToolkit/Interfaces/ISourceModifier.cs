using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISourceModifier : ISourceStatement
    {
        List<ISourceStatement> Modifiers { get; }
    }
}
