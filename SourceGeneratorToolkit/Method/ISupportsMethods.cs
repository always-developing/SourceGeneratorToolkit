namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports methods
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsMethods<TContainer> where TContainer : SourceContainer
    {
    }
}
