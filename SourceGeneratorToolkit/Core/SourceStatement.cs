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

        internal string SourceText { get; set; }

        public SourceStatement() { }

        public SourceStatement(string statement)
        {
            SourceText = statement;
        }

        public virtual string ToSource()
        {
            return SourceText;
        }

        public virtual string ToTree(int treeLevel)
        {
            var sb = new StringBuilder();

            sb.Append($"{TreePrefix(treeLevel)}{this.GetType().Name}");

            return sb.ToString();
        }

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
