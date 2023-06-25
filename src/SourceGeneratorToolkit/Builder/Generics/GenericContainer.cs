namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a generic
    /// </summary>
    public class GenericContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(GenericContainer);

        /// <summary>
        /// Constructor for GenericContainer
        /// </summary>
        /// <param name="value">The generic value</param>
        public GenericContainer(string value)
        {
            SourceText = value;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
