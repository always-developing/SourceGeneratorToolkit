namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the unsafe modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IUnsafeModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
