using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ParameterContainer : SourceContainer
    {
        internal override string Name => nameof(ParameterContainer);

        public void AddParameter(string type, string name) 
        {
            if(_sourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }
            _sourceItems.Add(new ParameterStatement(type, name));
        }
    }
}
