using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface IAbstractModifier<T> where T : SourceContainer
    {
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
