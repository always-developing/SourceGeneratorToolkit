namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports fields
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsField<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        public FieldList Fields { get; }
    }
}
