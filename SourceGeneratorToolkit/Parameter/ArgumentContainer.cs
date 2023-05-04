namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing an argument
    /// </summary>
    public class ArgumentContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ArgumentContainer);

        /// <summary>
        /// Constructor for ArgumentContainer
        /// </summary>
        /// <param name="argumentValue">The argument value</param>
        public ArgumentContainer(string argumentValue)
        {
            _sourceItems.Add(new Statement(argumentValue));
        }

        /// <summary>
        /// Constructor for ArgumentContainer
        /// </summary>
        /// <param name="argumentName">The argument name</param>
        /// <param name="argumentValue">The argument value</param>
        public ArgumentContainer(string argumentName, string argumentValue)
        {
            _sourceItems.Add(new Statement(argumentName));
            _sourceItems.Add(new EqualsStatement());
            _sourceItems.Add(new Statement(argumentValue));
        }
    }
}
