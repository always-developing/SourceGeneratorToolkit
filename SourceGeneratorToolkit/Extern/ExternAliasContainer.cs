using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ExternAliasContainer : SourceContainer
    {
        internal override string Name => nameof(ExternAliasContainer);

        public ExternAliasContainer AddExternAlias(string externAlias)
        {
            _sourceItems.Add(new ExternAliasStatement(externAlias));

            return this;
        }
    }
}
