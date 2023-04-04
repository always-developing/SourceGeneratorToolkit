using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class DocumentationParamContainer : SourceContainer
    {
        internal override string Name => nameof(DocumentationParamContainer);

        internal  DocumentationParamContainer AddParam(string name, string description)
        {
            _sourceItems.Add(new DocumentationStatement($"<param name=\"{name}\">{description}</param>"));
            _sourceItems.Add(new NewLineStatement());
            return this;
        }
    }
}
