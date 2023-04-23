using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Contains a list of "external alias" statements 
    /// </summary>
    public class ExternAliasContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ExternAliasContainer);

        /// <summary>
        /// Adds an external alias statement
        /// </summary>
        /// <param name="externAlias">The name of the "extern alias" to add</param>
        /// <returns>The extern alias container</returns>
        public ExternAliasContainer AddExternAlias(string externAlias)
        {
            _sourceItems.Add(new ExternAliasStatement(externAlias));

            return this;
        }
    }
}
