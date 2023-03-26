using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface IPartialModifier<T> where T : SourceContainer
    {
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
