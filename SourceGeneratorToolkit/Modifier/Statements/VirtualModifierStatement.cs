namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the virtual modifier
    /// </summary>
    public class VirtualModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(VirtualModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public VirtualModifierStatement()
        {
            SourceText = "virtual ";
            Order = 4;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
