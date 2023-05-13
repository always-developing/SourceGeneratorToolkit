namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a constructor which calls into another constructor
    /// </summary>
    public class ConstructorCallStatement : SourceContainer, ISupportsArguments<ConstructorCallStatement>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ConstructorCallStatement);

        /// <inheritdoc/>
        public ArgumentList Arguments { get; } = new ArgumentList();

        /// <summary>
        /// Adds an argument to the constructor
        /// </summary>
        /// <param name="argumentValue">The constructor argument value</param>
        /// <returns></returns>
        public ConstructorCallStatement AddArgument(string argumentValue)
        {
            Arguments.AddArgument(argumentValue);

            return this;
        }
    }
}
