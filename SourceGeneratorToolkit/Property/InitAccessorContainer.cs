using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InitAccessorContainer : SourceContainer
    {
        internal override string Name => nameof(InitAccessorContainer);

        public override string ToSource()
        {
            if (!_sourceItems.Any())
            {
                _sourceItems.Add(new Statement("init"));
                _sourceItems.Add(new SemiColonStatement());
            }

            return base.ToSource();
        }
    }
}
