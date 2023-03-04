using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ModifierContainer : SourceContainer
    {
        internal override string Name => nameof(ModifierContainer);

        public override string ToSource()
        {
            if(!SourceItems.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            foreach(var item in SourceItems.OrderBy(i => i.Order))
            {
                sb.Append(item.ToSource());
            }

            return sb.ToString();
        }
    }
}
