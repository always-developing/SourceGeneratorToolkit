namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports generics
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsGenerics<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        public GenericList GenericList { get; }
    }
}
