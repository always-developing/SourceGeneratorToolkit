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
            var sb = new IndentedStringBuilder(IndentLevel);

            foreach(var item in SourceItems.OrderBy(i => i.Order))
            {
                sb.Append(item.ToSource());
            }

            return sb.ToString();
        }
    }
}
