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
                SourceItems.Add(new Statement("get"));
                SourceItems.Add(new SemiColonStatement());
            }

            return base.ToSource();
        }
    }
}
