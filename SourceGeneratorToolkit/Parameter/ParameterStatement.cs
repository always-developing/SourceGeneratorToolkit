using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ParameterStatement : SourceStatement
    {
        internal override string Name => nameof(ParameterStatement);

        public ParameterStatement(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
