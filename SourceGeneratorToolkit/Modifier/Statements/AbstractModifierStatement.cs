namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the abstract modifier
    /// </summary>
    public class AbstractModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(AbstractModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public AbstractModifierStatement()
        {
            SourceText = "abstract ";
            Order = 1;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
