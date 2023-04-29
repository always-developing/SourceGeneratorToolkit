namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing XML documentation parameters
    /// </summary>
    public class DocumentationParamContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(DocumentationParamContainer);

        /// <summary>
        /// Adds a parameter to the documentation
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="description">The description of the parameter</param>
        /// <returns>The documentation parameter container</returns>
        internal DocumentationParamContainer AddParam(string name, string description)
        {
            _sourceItems.Add(new DocumentationStatement($"<param name=\"{name}\">{description}</param>"));
            _sourceItems.Add(new NewLineStatement());
            return this;
        }
    }
}
