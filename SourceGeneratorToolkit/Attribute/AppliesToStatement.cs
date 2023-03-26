using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class AppliesToStatement : SourceContainer
    {
        internal override string Name => nameof(AppliesToStatement);

        public AppliesToStatement(AttributeAppliesTo appliesTo)
        {
            _sourceItems.Add(new Statement(appliesTo.ToString().ToLower()));
            _sourceItems.Add(new ColonStatement());
        }
    }
}
