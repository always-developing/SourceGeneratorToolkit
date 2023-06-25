namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the sealed modifier
    /// </summary>
    public class SealedModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(SealedModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public SealedModifierStatement()
        {
            SourceText = "sealed ";
            Order = 3;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
