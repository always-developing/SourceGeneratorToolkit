using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsAttributes<T> where T : SourceContainer
    {
        AttributeContainer AttributeList { get; }
    }
}

