using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsParameters<T> where T : SourceContainer
    {
        public ParameterContainer ParameterContainer { get; }
    }
}
