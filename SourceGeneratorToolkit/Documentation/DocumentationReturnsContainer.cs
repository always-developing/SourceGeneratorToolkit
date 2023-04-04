using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class DocumentationReturnsContainer : SourceContainer
    {
        internal override string Name => nameof(DocumentationReturnsContainer);

        public DocumentationReturnsContainer WithReturns(string returns)
        {
            return WithReturns(new string[] { returns });
        }

        public DocumentationReturnsContainer WithReturns(string[] returns)
        {
            _sourceItems.Add(new DocumentationStatement("<returns>"));
            _sourceItems.Add(new NewLineStatement());
            foreach (var ret in returns)
            {
                _sourceItems.Add(new DocumentationStatement(ret));
                _sourceItems.Add(new NewLineStatement());
            }
            _sourceItems.Add(new DocumentationStatement("</returns>"));
            _sourceItems.Add(new NewLineStatement());

            return this;
        }
    }
}
