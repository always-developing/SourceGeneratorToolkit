using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A contgainer representing a collection of arguments
    /// </summary>
    public class ArgumentList : SourceContainer
    {
        // <inheritdoc/>
        internal override string Name => nameof(ArgumentList);

        /// <summary>
        /// Adds an argument to the collection
        /// </summary>
        /// <param name="argumentValue">The argument value</param>
        /// <returns>The argument collection</returns>
        public ArgumentList AddArgument(string argumentValue)
        {
            var argContainer = new ArgumentContainer(argumentValue);

            if (SourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(argContainer);

            return this;
        }

        /// <summary>
        /// Adds an argument to the container
        /// </summary>
        /// <param name="argumentName">The argument name</param>
        /// <param name="argumentValue">The argument value</param>
        /// <returns></returns>
        public ArgumentList AddArgument(string argumentName, string argumentValue)
        {
            var argContainer = new ArgumentContainer(argumentName, argumentValue);

            if (SourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(argContainer);

            return this;
        }
    }
}
