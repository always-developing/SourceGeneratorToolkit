namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports properties
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsProperty<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        public PropertyList Properties { get; }
    }
}
