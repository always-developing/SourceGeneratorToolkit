namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the sealed keyword
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISealedModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
