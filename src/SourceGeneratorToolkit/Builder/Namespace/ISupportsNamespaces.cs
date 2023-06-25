namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate a namespace can be added to the container
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsNamespaces<TContainer> where TContainer : SourceContainer
    {
    }
}
