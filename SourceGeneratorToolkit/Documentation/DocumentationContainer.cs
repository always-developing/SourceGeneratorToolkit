namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing XML documentation
    /// </summary>
    public class DocumentationContainer : SourceContainer, ISupportsStatement<DocumentationContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(DocumentationContainer);

        /// <inheritdoc/>
        public DocumentationSummaryContainer Summary { get; } = new DocumentationSummaryContainer();

        /// <inheritdoc/>
        public DocumentationParamContainer Parameters { get; } = new DocumentationParamContainer();

        /// <inheritdoc/>
        public DocumentationReturnsContainer Returns { get; } = new DocumentationReturnsContainer();

        /// <summary>
        /// Adds a summary to the documentation text
        /// </summary>
        /// <param name="summary">The summary text</param>
        /// <returns>The documentation container</returns>
        public DocumentationContainer WithSummary(string summary)
        {
            Summary.WithSummary(summary);
            return this;
        }

        /// <summary>
        /// Adds a summary to the documentation text
        /// </summary>
        /// <param name="summaries">An array of summary texts</param>
        /// <returns>The documentation container</returns>
        public DocumentationContainer WithSummary(string[] summaries)
        {
            Summary.WithSummary(summaries);
            return this;
        }

        /// <summary>
        /// Adds a param to the documentation rext 
        /// </summary>
        /// <param name="name">The param name</param>
        /// <param name="description">The param description</param>
        /// <returns>The documentation container</returns>
        public DocumentationContainer AddParam(string name, string description)
        {
            Parameters.AddParam(name, description);
            return this;
        }

        /// <summary>
        /// Adds a return to the documentation text
        /// </summary>
        /// <param name="returns">The returns description</param>
        /// <returns>The documentation container</returns>
        public DocumentationContainer WithReturns(string returns)
        {
            Returns.WithReturns(returns);
            return this;
        }

        /// <summary>
        /// Adds a return to the documentation text
        /// </summary>
        /// <param name="returns">The returns descriptions</param>
        /// <returns>The documentation container</returns>
        public DocumentationContainer WithReturns(string[] returns)
        {
            Returns.WithReturns(returns);
            return this;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            _sourceItems.Add(Summary);
            _sourceItems.Add(Parameters);
            _sourceItems.Add(Returns);

            return base.ToSource();
        }
    }
}
