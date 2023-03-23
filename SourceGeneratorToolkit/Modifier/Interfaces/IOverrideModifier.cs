using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface IOverrideModifier<T> where T : SourceContainer
    {
        ModifierContainer GeneralModifier { get; }
    }
}
