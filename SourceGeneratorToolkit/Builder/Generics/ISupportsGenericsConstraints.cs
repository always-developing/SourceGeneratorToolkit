namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports generic constraints
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsGenericsConstraints<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        public GenericConstraintList ConstraintContainer { get; }
    }
}
