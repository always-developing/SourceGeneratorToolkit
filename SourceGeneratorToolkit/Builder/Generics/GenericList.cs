using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container which represents a list of generics applied to the parent container
    /// </summary>
    public class GenericList : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(GenericList);

        /// <inheritdoc/>
        public override string ToSource()
        {
            if (!SourceItems.Any())
            {
                return "";
            }

            _sourceItems.Insert(0, new ChevronStartStatement());
            _sourceItems.Add(new ChevronEndStatement());

            return base.ToSource();
        }

        /// <summary>
        /// Add a generic value to the collection
        /// </summary>
        /// <param name="name">The name of the generic</param>
        /// <returns>The list</returns>
        public GenericList AddGeneric(string name)
        {
            if(_sourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(new GenericContainer(name));

            return this;
        }
    }
}
