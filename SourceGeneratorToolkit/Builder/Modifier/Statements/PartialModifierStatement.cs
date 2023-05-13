namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the prtial modifier
    /// </summary>
    public class PartialModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(PartialModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public PartialModifierStatement()
        {
            SourceText = "partial ";
            Order = 2;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
