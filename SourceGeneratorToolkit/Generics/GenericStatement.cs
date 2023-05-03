namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a generic statement
    /// </summary>
    public class GenericStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(GenericStatement);

        /// <summary>
        /// Constructor for GenericStatement
        /// </summary>
        /// <param name="genericValue">The generic value</param>
        public GenericStatement(string genericValue)
        {
            SourceText = genericValue;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
