using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface IVirtualModifier<T> where T : SourceContainer
    {
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
