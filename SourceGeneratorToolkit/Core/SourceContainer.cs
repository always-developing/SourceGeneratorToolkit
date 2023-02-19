using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public abstract class SourceContainer : SourceStatement
    {
        internal List<SourceStatement> SourceItems { get; } = new List<SourceStatement>();

        public override string ToSource()
        {
            var sb = IndentedStringBuilder();

            foreach (var item in SourceItems)
            {
                sb.Append(item.ToSource());
            }

            return sb.ToString();
        }

        public override string ToTree()
        {
            var sb = IndentedStringBuilder();

            sb.AppendLine(this.GetType().Name);

            foreach (var item in SourceItems)
            {
                sb.AppendLine(item.ToTree());
            }

            return sb.ToString();
        }
    }
}
