using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsReturnValue
    {
        public ReturnContainer ReturnType { get; }
    }
}
