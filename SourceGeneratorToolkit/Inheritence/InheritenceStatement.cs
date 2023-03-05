using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InheritenceStatement : SourceStatement
    {
        internal override string Name => nameof(InheritenceStatement);

        public InheritenceStatement(string inherits)
        {
            SourceText = inherits;
        }

        public override string ToSource()
        {
            return $" {SourceText}";
        }
    }
}
