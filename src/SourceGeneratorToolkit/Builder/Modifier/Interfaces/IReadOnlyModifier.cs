namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the readonly keyword
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IReadOnlyModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
