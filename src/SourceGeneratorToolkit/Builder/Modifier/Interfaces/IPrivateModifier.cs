namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the private modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IPrivateModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        AccessModifierContainer AccessModifier { get; }
    }
}
