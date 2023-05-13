namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate inferfaces can be added to the container
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsInterfaces<TContainer> where TContainer : SourceContainer
    {
    }
}

