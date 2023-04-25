namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate records can be added to the container
    /// </summary>
    /// <typeparam name="TContainer">The parent contaioner type</typeparam>
    public interface ISupportsRecords<TContainer> where TContainer : SourceContainer
    {
    }
}
