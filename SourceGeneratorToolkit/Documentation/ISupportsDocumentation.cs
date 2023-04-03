using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsDocumentation<T> where T : SourceContainer
    {
        DocumentationContainer Documentation{ get; }
    }
}
