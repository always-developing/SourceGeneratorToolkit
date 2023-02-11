using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class SourceContainer : SourceStatement
    {
        public List<SourceStatement> SourceItems { get; } = new List<SourceStatement>();

        public override string GenerateSource()
        {
            var sb = new StringBuilder();

            foreach (var item in SourceItems.OrderBy(s => s.Order)) 
            {
                sb.AppendLine(item.GenerateSource());
            }

            return sb.ToString();
        }
    }
}
