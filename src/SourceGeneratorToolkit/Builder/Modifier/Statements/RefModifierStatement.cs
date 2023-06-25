namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the out modifier
    /// </summary>
    internal class RefModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(RefModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public RefModifierStatement()
        {
            SourceText = "ref ";
            Order = 1;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
