using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class GenericsContainer : SourceContainer
    {
        internal override string Name => nameof(GenericsContainer);

        public override string ToSource()
        {
            var sb = new StringBuilder();

            if (!SourceItems.Any())
            {
                return "";
            }

            sb.Append(new ChevronStartStatement().ToSource());

            for (int i = 0; i < SourceItems.Count; i++)
            {
                sb.Append(SourceItems[i].ToSource());

                if (i != SourceItems.Count - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append(new ChevronEndStatement().ToSource());
            return sb.ToString();
        }
    }
}
