using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// The result of a qualifiying node
    /// </summary>
    public class SyntaxReceiverResult
    {
        /// <summary>
        ///  The qualifying node
        /// </summary>
        public SyntaxNode Node { get; set; }

        /// <summary>
        /// Custom metadata configured by the caller
        /// </summary>
        public Dictionary<string, object> CustomMetadata { get; set; }
    }
}
