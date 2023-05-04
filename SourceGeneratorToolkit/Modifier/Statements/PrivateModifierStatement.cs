namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the private modifier
    /// </summary>
    public class PrivateModifierStatement : AccessModifierStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(PrivateModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public PrivateModifierStatement()
        {
            SourceText = "private ";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
