namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing XML documentation summary portion
    /// </summary>
    public class DocumentationSummaryContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(DocumentationSummaryContainer);

        /// <summary>
        /// Adds the summary to the container
        /// </summary>
        /// <param name="summary">The summary text</param>
        /// <returns>The summary container</returns>
        public DocumentationSummaryContainer WithSummary(string summary)
        {
            return WithSummary(new string[] { summary });
        }

        /// <summary>
        /// Adds the summaries to the container
        /// </summary>
        /// <param name="summaries">An array of summary striungs</param>
        /// <returns>The summary container</returns>
        public DocumentationSummaryContainer WithSummary(string[] summaries)
        {
            _sourceItems.Add(new DocumentationStatement("<summary>"));
            _sourceItems.Add(new NewLineStatement());
            foreach (var strSummary in summaries)
            {
                _sourceItems.Add(new DocumentationStatement(strSummary));
                _sourceItems.Add(new NewLineStatement());
            }
            _sourceItems.Add(new DocumentationStatement("</summary>"));
            _sourceItems.Add(new NewLineStatement());

            return this;
        }
    }
}
