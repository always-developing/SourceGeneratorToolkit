using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class DocumentationContainer : SourceContainer
    {
        internal override string Name => nameof(DocumentationContainer);

        internal string[] SummaryText;

        public DocumentationContainer WithSummary(string summary)
        {
            SummaryText = new string[] { summary };

            return this;
        }

        public DocumentationContainer WithSummary(string[] summary)
        {
            SummaryText = summary;

            return this;
        }

        public override string ToSource()
        {
            if(SummaryText == null || SummaryText?.Length == 0)
            {
                return base.ToSource();
            }

            _sourceItems.Add(new DocumentStatement("<summary>"));
            _sourceItems.Add(new NewLineStatement());
            foreach (var summary in SummaryText)
            {
                _sourceItems.Add(new DocumentStatement(summary));
                _sourceItems.Add(new NewLineStatement());
            }
            _sourceItems.Add(new DocumentStatement("</summary>"));
            _sourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }
    }
}
