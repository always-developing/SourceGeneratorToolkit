namespace SourceGeneratorToolkit
{
    // <summary>
    /// Marker interface to indicate an interface can be added to the container
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsEnums<TContainer> where TContainer : SourceContainer
    {
    }
}
