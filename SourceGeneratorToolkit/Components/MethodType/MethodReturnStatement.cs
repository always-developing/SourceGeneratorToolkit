using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodReturnStatement : SourceStatement
    {
        public override string Name => nameof(MethodReturnStatement);

        public override int Order { get; set; } = 1;

        public MethodReturnStatement(string returnType)
        {
            SourceText = returnType;
        }
    }
}
