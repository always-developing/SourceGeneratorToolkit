namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the file modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IFileModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        AccessModifierContainer AccessModifier { get; }
    }
}
