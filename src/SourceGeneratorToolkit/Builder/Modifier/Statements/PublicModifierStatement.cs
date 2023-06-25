namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the public modifier
    /// </summary>
    public class PublicModifierStatement : AccessModifierStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(PublicModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public PublicModifierStatement()
        {
            SourceText = "public ";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
