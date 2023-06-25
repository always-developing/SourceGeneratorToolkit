namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the required keyword
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IRequiredModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
