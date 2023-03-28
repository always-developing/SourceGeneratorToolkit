using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class SetAccessorContainer : SourceContainer
    {
        internal override string Name => nameof(SetAccessorContainer);

        public override string ToSource()
        {
            if(!_sourceItems.Any())
            {
                _sourceItems.Add(new Statement("set"));
                _sourceItems.Add(new SemiColonStatement());
            }

            return base.ToSource();
        }
    }
}
