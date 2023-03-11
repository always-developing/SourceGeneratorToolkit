using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class GenericConstraintStatement : SourceStatement
    {
        internal override string Name => nameof(GenericConstraintStatement);

        public GenericConstraintStatement(string constraints)
        {
            SourceText = constraints;
        }
    }
}
