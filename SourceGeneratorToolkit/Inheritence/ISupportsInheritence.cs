namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports inheritence
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsInheritence<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        public InheritenceContainer Inherits { get; }
    }
}
