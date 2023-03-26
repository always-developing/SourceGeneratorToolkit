using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISealedModifier<T> where T : SourceContainer
    {
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
