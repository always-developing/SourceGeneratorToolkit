namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the internal modifier
    /// </summary>
    public class InternalModifierStatement : AccessModifierStatement
    { 
        /// <inheritdoc/>
        internal override string Name => nameof(InternalModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public InternalModifierStatement()
        {
            SourceText = "internal ";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
