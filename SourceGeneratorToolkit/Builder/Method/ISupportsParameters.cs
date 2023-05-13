namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports parameters
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsParameters<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        public ParameterContainer ParameterContainer { get; }
    }
}
