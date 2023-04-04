using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class DocumentationContainer : SourceContainer
    {
        internal override string Name => nameof(DocumentationContainer);

        public DocumentationSummaryContainer Summary { get; } = new DocumentationSummaryContainer();

        public DocumentationParamContainer Parameters { get; } = new DocumentationParamContainer();

        public DocumentationReturnsContainer Returns { get; } = new DocumentationReturnsContainer();

        public DocumentationContainer WithSummary(string summary)
        {
            Summary.WithSummary(summary);
            return this;
        }

        public DocumentationContainer WithSummary(string[] summary)
        {
            Summary.WithSummary(summary);
            return this;
        }

        public DocumentationContainer AddParam(string name, string description)
        {
            Parameters.AddParam(name, description);
            return this;
        }

        public DocumentationContainer WithReturns(string returns)
        {
            Returns.WithReturns(returns);
            return this;
        }

        public DocumentationContainer WithReturns(string[] returns)
        {
            Returns.WithReturns(returns);
            return this;
        }

        public override string ToSource()
        {
            _sourceItems.Add(Summary);
            _sourceItems.Add(Parameters);
            _sourceItems.Add(Returns);

            return base.ToSource();
        }
    }
}
