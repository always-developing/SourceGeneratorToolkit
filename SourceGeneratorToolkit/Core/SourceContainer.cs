﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public abstract class SourceContainer : SourceStatement
    {
        internal List<SourceStatement> SourceItems { get; } = new List<SourceStatement>();

        public virtual SourceContainer AddStatement(string statement)
        {
            SourceItems.Add(new Statement(statement));

            return this;
        }

        public override string ToSource()
        {
            if (!SourceItems.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.Append("");

            foreach (var item in SourceItems)
            {
                sb.Append(item.ToSource());
            }

            return sb.ToString();
        }

        public override string ToTree(int treeLevel)
        {
            var sb = new StringBuilder();

            sb.Append(base.TreePrefix(treeLevel));
            sb.AppendLine(this.GetType().Name);

            foreach (var item in SourceItems)
            {
                sb.AppendLine(item.ToTree(treeLevel + 1));
            }

            return sb.ToString();
        }
    }
}
