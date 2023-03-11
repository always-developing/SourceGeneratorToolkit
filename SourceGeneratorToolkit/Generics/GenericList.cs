using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class GenericList : SourceContainer
    {
        internal override string Name => nameof(GenericList);

        public override string ToSource()
        {
            if (!SourceItems.Any())
            {
                return "";
            }

            _sourceItems.Insert(0, new ChevronStartStatement());
            _sourceItems.Add(new ChevronEndStatement());

            return base.ToSource();
        }

        public GenericList AddGeneric(string value)
        {
            if(_sourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(new GenericContainer(value));

            return this;
        }
    }
}
