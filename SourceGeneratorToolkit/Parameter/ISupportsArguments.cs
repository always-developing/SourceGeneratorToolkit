namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports arguments
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsArguments<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        ArgumentList Arguments { get; }
    }
}
