namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a documentation statement
    /// </summary>
    public class DocumentationStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(DocumentationStatement);

        /// <summary>
        /// Constructor for DocumentationStatement
        /// </summary>
        /// <param name="documentText">The documentation text</param>
        public DocumentationStatement(string documentText)
        {
            SourceText = $"/// {documentText}";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
