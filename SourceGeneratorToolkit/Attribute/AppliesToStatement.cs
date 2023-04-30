namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a type of entity an attribute applies to
    /// </summary>
    public class AppliesToStatement : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(AppliesToStatement);

        /// <summary>
        /// Constructor for the AppliesToStatement class
        /// </summary>
        /// <param name="appliesTo">An entity type the attribute applies to</param>
        public AppliesToStatement(AttributeAppliesTo appliesTo)
        {
            _sourceItems.Add(new Statement(appliesTo.ToString().ToLower()));
            _sourceItems.Add(new ColonStatement());
        }
    }
}
