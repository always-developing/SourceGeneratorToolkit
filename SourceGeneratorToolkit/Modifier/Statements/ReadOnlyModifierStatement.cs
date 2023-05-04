namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the readonly modifier
    /// </summary>
    public class ReadOnlyModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ReadOnlyModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public ReadOnlyModifierStatement()
        {
            SourceText = "readonly ";
            Order = 5;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
