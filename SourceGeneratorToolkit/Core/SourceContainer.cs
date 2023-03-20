using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public abstract class SourceContainer : SourceStatement
    {
        protected List<SourceStatement> _sourceItems = new List<SourceStatement>();

        public ReadOnlyCollection<SourceStatement> SourceItems
        {
            get
            {
                return _sourceItems.AsReadOnly();
            }
        }

        public virtual SourceContainer AddStatement(string statement)
        {
            _sourceItems.Add(new Statement(statement));

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

        public void OrderSourceItems()
        {
            _sourceItems = _sourceItems.OrderBy(item => item.Order).ToList();
        }
    }
}
