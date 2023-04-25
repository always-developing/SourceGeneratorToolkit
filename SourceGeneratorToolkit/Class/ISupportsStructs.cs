namespace SourceGeneratorToolkit
{

    /// <summary>
    /// Marker interface to indicate a structs can be added to the container
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsStructs<TContainer> where TContainer : SourceContainer
    {
    }
}
