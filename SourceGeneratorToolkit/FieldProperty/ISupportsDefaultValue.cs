namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports default value
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface ISupportsDefaultValue<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        public DefaultValueContainer DefaultValue{ get; }
    }
}
