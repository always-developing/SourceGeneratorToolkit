namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing an implementation statement
    /// </summary>
    public class ImplementStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ImplementStatement);

        /// <summary>
        /// Constructor for ImplementStatement
        /// </summary>
        /// <param name="implements">The implementation value</param>
        public ImplementStatement(string implements)
        {
            SourceText = implements;
        }
    }
}
