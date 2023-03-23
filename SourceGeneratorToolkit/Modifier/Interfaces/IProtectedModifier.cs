using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface IProtectedModifier<T> where T : SourceContainer
    {
        AccessModifierContainer AccessModifier { get; }
    }
}
