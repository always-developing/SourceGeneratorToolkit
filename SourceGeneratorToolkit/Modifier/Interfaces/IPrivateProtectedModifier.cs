using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface IPrivateProtectedModifier<T> where T : SourceContainer
    {
        AccessModifierContainer AccessModifier { get; }
    }
}
