using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface IStaticModifier<T> where T : SourceContainer
    {
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
