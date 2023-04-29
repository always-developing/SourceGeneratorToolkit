namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the returns statement of XML documentation
    /// </summary>
    public class DocumentationReturnsContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(DocumentationReturnsContainer);

        /// <summary>
        /// Adds the return statement to the XML documentation
        /// </summary>
        /// <param name="returns">The returns description</param>
        /// <returns>The documentation returns container</returns>
        public DocumentationReturnsContainer WithReturns(string returns)
        {
            return WithReturns(new string[] { returns });
        }

        /// <summary>
        /// Adds the return statement to the XML documentation
        /// </summary>
        /// <param name="returns">An array of return descriptions</param>
        /// <returns>The documentation returns container</returns>
        public DocumentationReturnsContainer WithReturns(string[] returns)
        {
            _sourceItems.Add(new DocumentationStatement("<returns>"));
            _sourceItems.Add(new NewLineStatement());
            foreach (var ret in returns)
            {
                _sourceItems.Add(new DocumentationStatement(ret));
                _sourceItems.Add(new NewLineStatement());
            }
            _sourceItems.Add(new DocumentationStatement("</returns>"));
            _sourceItems.Add(new NewLineStatement());

            return this;
        }
    }
}
