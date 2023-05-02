namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports attributes
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsDocumentation<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        DocumentationContainer Documentation { get; }
    }
}
