namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the abstract modifier
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IAbstractModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
