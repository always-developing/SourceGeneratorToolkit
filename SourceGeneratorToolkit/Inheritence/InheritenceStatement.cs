using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InheritenceStatement : SourceStatement
    {
        internal override string Name => nameof(InheritenceStatement);

        public InheritenceStatement(string baseClassName)
        {
            SourceText = baseClassName;
        }

        public override string ToSource()
        {
            return $" {SourceText}";
        }
    }
}
