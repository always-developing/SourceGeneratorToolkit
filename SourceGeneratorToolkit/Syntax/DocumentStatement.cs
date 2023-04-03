using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class DocumentStatement : SourceStatement
    {
        internal override string Name => nameof(DocumentStatement);

        public DocumentStatement(string documentText)
        {
            SourceText = $"/// {documentText}";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
