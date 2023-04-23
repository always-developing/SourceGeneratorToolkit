using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// An abstract container, which can hold one or more containers or statements representing a C# language feature
    /// </summary>
    public abstract class SourceContainer : SourceStatement
    {
        /// <summary>
        /// The list of statements making up the container
        /// </summary>
        internal List<SourceStatement> _sourceItems = new List<SourceStatement>();

        /// <summary>
        /// A readonly list of statements making up the contents of the container
        /// </summary>
        public ReadOnlyCollection<SourceStatement> SourceItems
        {
            get
            {
                return _sourceItems.AsReadOnly();
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <summary>
        /// Orders the source items by the Order property
        /// </summary>
        public void OrderSourceItems()
        {
            _sourceItems = _sourceItems.OrderBy(item => item.Order).ToList();
        }
    }
}
