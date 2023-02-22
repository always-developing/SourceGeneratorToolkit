using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SourceGeneratorToolkit
{
    public abstract class SourceStatement
    {
        internal abstract string Name { get; }

        internal int Order { get; set; } = 0;

        internal int IndentLevel { get; set; } = 0;

        internal string SourceText { get; set; }

        public virtual string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.AppendLine(SourceText);

            return sb.ToString();
        }

        public virtual string ToTree(int treeLevel)
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append($"{TreePrefix(treeLevel)}{this.GetType().Name}");

            return sb.ToString();
        }

        //protected StringBuilder IndentedStringBuilder()
        //{
        //    var sb = new StringBuilder();

        //    for (int i = 0; i < IndentLevel; i++)
        //    {
        //        sb.Append(SourceToolkitSettings.Indent);
        //    }

        //    return sb;
        //}

        protected string TreePrefix(int treeLevel)
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 2 ; i<= treeLevel; i++) 
            {
                sb.Append(" ");
            }

            sb.Append("|-");

            return sb.ToString();
        }

    }
}
