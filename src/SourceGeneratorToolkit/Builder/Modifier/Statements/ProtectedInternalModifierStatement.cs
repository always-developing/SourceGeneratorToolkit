namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the protected internal modifier
    /// </summary>
    public class ProtectedInternalModifierStatement : AccessModifierStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ProtectedInternalModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public ProtectedInternalModifierStatement()
        {
            SourceText = "protected internal ";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
