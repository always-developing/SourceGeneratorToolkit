namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the protected internal modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IProtectedInternalModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        AccessModifierContainer AccessModifier { get; }
    }
}
