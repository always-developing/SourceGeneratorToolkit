using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ImplementsContainer : SourceContainer
    {
        internal override string Name => nameof(ImplementsContainer);

        public ImplementsContainer AddImplements(string implementsInterface)
        {
            if(_sourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(new ImplementStatement(implementsInterface));

            return this;
        }

        public ImplementsContainer ParentAlsoInherits(bool inherits)
        {
            if (_sourceItems.Any())
            {
                if (!inherits)
                {
                    _sourceItems.Insert(0, new ColonStatement());
                }
                else
                {
                    _sourceItems.Insert(0, new CommaStatement());
                }
            }

            return this;
        }
    }
}
