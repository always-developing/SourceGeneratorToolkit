using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class SetAccessorContainer : SourceContainer
    {
        internal override string Name => nameof(SetAccessorContainer);

        public override string ToSource()
        {
            if(!SourceItems.Any())
            {
                SourceItems.Add(new Statement("set"));
                SourceItems.Add(new SemiColonStatement());
            }

            return base.ToSource();
        }
    }
}
