namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports comments
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsComments<TContainer> where TContainer : SourceContainer
    {
    }
}
