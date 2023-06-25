using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container which represents the implementation of an interface
    /// </summary>
    public class ImplementsContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ImplementsContainer);

        /// <summary>
        /// Adds an implementation to the parent container
        /// </summary>
        /// <param name="implementsInterface">The interface name to implement</param>
        /// <returns>The implementation container</returns>
        public ImplementsContainer AddImplements(string implementsInterface)
        {
            if(_sourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(new ImplementStatement(implementsInterface));

            return this;
        }

        /// <summary>
        /// Flags the container (the one implementing the interface) as also inheriting
        /// </summary>
        /// <param name="inherits"></param>
        /// <returns></returns>
        public ImplementsContainer ParentAlsoInherits(bool inherits)
        {
            if (_sourceItems.Any())
            {
                if (!inherits)
                {
                    _sourceItems.Insert(0, new ColonStatement());
                }
                else
                {
                    _sourceItems.Insert(0, new CommaStatement());
                }
            }

            return this;
        }
    }
}
