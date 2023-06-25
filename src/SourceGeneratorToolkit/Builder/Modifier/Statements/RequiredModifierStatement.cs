namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the required modifier
    /// </summary>
    public class RequiredModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(RequiredModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public RequiredModifierStatement()
        {
            SourceText = "required ";
            Order = 3;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
