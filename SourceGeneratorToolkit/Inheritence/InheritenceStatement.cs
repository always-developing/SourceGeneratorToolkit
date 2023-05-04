namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing inheritence
    /// </summary>
    public class InheritenceStatement : SourceStatement
    {
        internal override string Name => nameof(InheritenceStatement);

        /// <summary>
        /// Constructor for InheritenceStatement
        /// </summary>
        /// <param name="baseClassName"></param>
        public InheritenceStatement(string baseClassName)
        {
            SourceText = baseClassName;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return $" {SourceText}";
        }
    }
}
