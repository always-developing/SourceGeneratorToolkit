using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsInheritence<T> where T : SourceContainer
    {
        public InheritenceContainer Inherits { get; }
    }
}
