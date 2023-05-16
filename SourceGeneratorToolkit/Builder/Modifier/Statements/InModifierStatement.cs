using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the in modifier
    /// </summary>
    public class InModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(OutModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public InModifierStatement()
        {
            SourceText = "in ";
            Order = 1;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
