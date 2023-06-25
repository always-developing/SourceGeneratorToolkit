namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the out modifier
    /// </summary>
    public class OutModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(OutModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public OutModifierStatement()
        {
            SourceText = "out ";
            Order = 1;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
