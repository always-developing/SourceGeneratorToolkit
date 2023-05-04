namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the static modifier
    /// </summary>
    public class StaticModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(StaticModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public StaticModifierStatement()
        {
            SourceText = "static ";
            Order = 4;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
