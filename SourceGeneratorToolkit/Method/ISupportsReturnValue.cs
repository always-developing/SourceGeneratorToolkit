namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports a return value
    /// </summary>
    public interface ISupportsReturnValue
    {
        /// <inheritdoc/>
        public ReturnContainer ReturnType { get; }
    }
}
