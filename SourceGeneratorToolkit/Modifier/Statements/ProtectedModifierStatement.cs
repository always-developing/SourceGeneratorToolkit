namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the protected modifier
    /// </summary>
    public class ProtectedModifierStatement : AccessModifierStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ProtectedModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public ProtectedModifierStatement()
        {
            SourceText = "protected ";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
