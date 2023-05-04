namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the private protected modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IPrivateProtectedModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        AccessModifierContainer AccessModifier { get; }
    }
}
