namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports implementations
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsImplementation<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        public ImplementsContainer Implements { get; }
    }
}
