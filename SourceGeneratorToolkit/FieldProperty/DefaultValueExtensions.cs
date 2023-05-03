namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for the default value container
    /// </summary>
    public static class DefaultValueExtensions
    {
        /// <summary>
        /// Sets the default value of a parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="value">The default value</param>
        /// <returns>The parent container</returns>
        public static TContainer WithDefaultValue<TContainer>(this ISupportsDefaultValue<TContainer> @base, string value) where TContainer : SourceContainer
        {
            @base.DefaultValue.SetDefautlValue(value);
            return (TContainer)@base;
        }
    }
}
