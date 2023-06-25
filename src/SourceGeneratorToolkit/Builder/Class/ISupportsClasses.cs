namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate classes can be added to the container
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsClasses<TContainer> where TContainer : SourceContainer
    {
    }
}
