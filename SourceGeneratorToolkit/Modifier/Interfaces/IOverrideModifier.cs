namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the override modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IOverrideModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
