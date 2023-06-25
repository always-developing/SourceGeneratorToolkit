namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the override modifier
    /// </summary>
    public class OverrideModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(OverrideModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public OverrideModifierStatement()
        {
            SourceText = "override ";
            Order = 4;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
