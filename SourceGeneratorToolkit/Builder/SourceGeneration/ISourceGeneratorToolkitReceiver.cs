using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISourceGeneratorToolkitReceiver
    {
        SyntaxReceiverResult Result { get; }
    }
}
