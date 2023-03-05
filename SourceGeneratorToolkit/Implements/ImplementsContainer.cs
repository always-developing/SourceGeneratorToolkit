using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ImplementsContainer : SourceContainer
    {
        internal override string Name => nameof(ImplementsContainer);

        public override string ToSource()
        {
            if (SourceItems.Any() && SourceItems.Last().GetType() == typeof(CommaStatement))
            {
                SourceItems.Remove(SourceItems.Last());
            }

            return base.ToSource();
        }
    }
}
