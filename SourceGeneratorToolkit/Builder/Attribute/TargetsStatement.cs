namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a type of entity an attribute applies to
    /// </summary>
    public class TargetsStatement : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(TargetsStatement);

        /// <summary>
        /// Constructor for the TargetsStatement class
        /// </summary>
        /// <param name="target">An entity type the attribute applies to</param>
        public TargetsStatement(AttributeTarget target)
        {
            _sourceItems.Add(new Statement(target.ToString().ToLower()));
            _sourceItems.Add(new ColonStatement());
        }
    }
}
