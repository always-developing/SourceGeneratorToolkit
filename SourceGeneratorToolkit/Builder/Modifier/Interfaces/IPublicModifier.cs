namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the public modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IPublicModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        AccessModifierContainer AccessModifier { get; }
    }
}
