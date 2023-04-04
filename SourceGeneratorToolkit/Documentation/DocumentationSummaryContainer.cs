using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class DocumentationSummaryContainer : SourceContainer
    {
        internal override string Name => nameof(DocumentationSummaryContainer);

        public DocumentationSummaryContainer WithSummary(string summary)
        {
            return WithSummary(new string[] { summary });
        }

        public DocumentationSummaryContainer WithSummary(string[] summary)
        {
            _sourceItems.Add(new DocumentationStatement("<summary>"));
            _sourceItems.Add(new NewLineStatement());
            foreach (var strSummary in summary)
            {
                _sourceItems.Add(new DocumentationStatement(strSummary));
                _sourceItems.Add(new NewLineStatement());
            }
            _sourceItems.Add(new DocumentationStatement("</summary>"));
            _sourceItems.Add(new NewLineStatement());

            return this;
        }
    }
}
