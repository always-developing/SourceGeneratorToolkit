using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface IHasReturnValue
    {
        public ReturnContainer ReturnType { get; }
    }
}
