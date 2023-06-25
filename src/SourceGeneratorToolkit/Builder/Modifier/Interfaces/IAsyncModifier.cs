namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the async modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IAsyncModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
