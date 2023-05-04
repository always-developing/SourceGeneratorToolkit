namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the internal modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IInternalModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        AccessModifierContainer AccessModifier { get; }
    }
}
