namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the partial modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>

    public interface IPartialModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
