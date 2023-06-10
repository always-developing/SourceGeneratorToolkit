using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class SyntaxReceiverResult
    {
        public SyntaxNode Node { get; set; }

        //public string this[string key]
        //{
        //    get => GetMetadataFromKey(key);
        //}

        //public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, object> CustomMetadata { get; set; }

        //private string GetMetadataFromKey(string key)
        //{
        //    if(Metadata.TryGetValue(key, out var value))
        //    {
        //        return value;
        //    }

        //    if (CustomMetadata!= null && CustomMetadata.TryGetValue(key, out var customValue))
        //    {
        //        return customValue.ToString();
        //    }

        //    return string.Empty;
        //}
    }
}
