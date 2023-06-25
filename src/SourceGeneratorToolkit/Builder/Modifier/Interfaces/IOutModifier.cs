namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the out keyword
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IOutModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
