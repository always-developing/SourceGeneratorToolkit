using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class GetAccessorContainer : SourceContainer
    {
        internal override string Name => nameof(GetAccessorContainer);

        public override string ToSource()
        {
            if (!SourceItems.Any())
            {
                _sourceItems.Add(new Statement("get"));
                _sourceItems.Add(new SemiColonStatement());
            }

            return base.ToSource();
        }
    }
}
