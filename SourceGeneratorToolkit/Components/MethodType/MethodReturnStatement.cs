using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodReturnStatement : ISourceStatement
    {
        public string Name => nameof(MethodReturnStatement);

        public int Order { get; set; } = 1;

        private readonly string _returnType;

        public MethodReturnStatement(string returnType)
        {
            _returnType = returnType;
        }

        public string GenerateSource()
        {
            return _returnType;
        }
    }
}
