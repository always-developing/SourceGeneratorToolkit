namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports statements being added
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsStatement<TContainer> where TContainer : SourceContainer
    {
    }
}
