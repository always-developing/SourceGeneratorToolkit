using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface IReadOnlyModifier<T> where T : SourceContainer
    {
        ModifierContainer GeneralModifier { get; }
    }
}
