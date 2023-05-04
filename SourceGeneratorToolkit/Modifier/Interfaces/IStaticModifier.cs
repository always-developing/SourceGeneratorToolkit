namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the static modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IStaticModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
