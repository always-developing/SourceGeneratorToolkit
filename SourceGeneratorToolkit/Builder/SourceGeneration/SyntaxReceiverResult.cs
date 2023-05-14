using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class SyntaxReceiverResult
    {
        public string Name { get; set; }

        public string Namespace { get; set; }

        public SyntaxNode Node { get; set; }

        public Dictionary<string, object> CustomMetadata { get; set; }
    }
}
