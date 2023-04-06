using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsImplementation<T> where T : SourceContainer
    {
        public ImplementsContainer Implements { get; }
    }
}
