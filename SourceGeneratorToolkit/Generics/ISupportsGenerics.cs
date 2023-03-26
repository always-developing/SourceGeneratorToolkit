using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsGenerics<T> where T : SourceContainer
    {
        public GenericList GenericList { get; }
    }
}
