namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the unsafe modifier
    /// </summary>
    public class UnsafeModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(UnsafeModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public UnsafeModifierStatement()
        {
            SourceText = "unsafe ";
            Order = 3;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
