using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodParameterStatement : ISourceStatement
    {
        public string Name => nameof(MethodParameterStatement);

        public int Order { get; set; } = 1;

        private readonly string _type;

        private readonly string _name;

        public MethodParameterStatement(string type, string name)
        {
            _type = type;
            _name = name;
        }

        public string GenerateSource()
        {
            return $"{_type} {_name}";
        }
    }
}
