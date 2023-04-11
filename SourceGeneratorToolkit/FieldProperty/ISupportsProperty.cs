using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsProperty<T> where T : SourceContainer
    {
        public PropertyList Properties { get; }
    }
}
