using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodParameterStatement : SourceStatement
    {
        public override string Name => nameof(MethodParameterStatement);

        public override int Order { get; set; } = 1;

        public MethodParameterStatement(string type, string name)
        {
            SourceText = $"{type} {name}";
        }
    }
}
