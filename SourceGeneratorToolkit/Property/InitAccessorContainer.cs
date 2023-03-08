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
            if (!SourceItems.Any())
            {
                SourceItems.Add(new Statement("init"));
                SourceItems.Add(new SemiColonStatement());
            }

            return base.ToSource();
        }
    }
}
