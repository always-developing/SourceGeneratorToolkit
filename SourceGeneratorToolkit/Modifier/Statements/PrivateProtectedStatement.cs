namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the private protected modifier
    /// </summary>
    public class PrivateProtectedStatement : AccessModifierStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(PrivateProtectedStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public PrivateProtectedStatement()
        {
            SourceText = "private protected ";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
