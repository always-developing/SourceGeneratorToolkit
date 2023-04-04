using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class DocumentationStatement : SourceStatement
    {
        internal override string Name => nameof(DocumentationStatement);

        public DocumentationStatement(string documentText)
        {
            SourceText = $"/// {documentText}";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
