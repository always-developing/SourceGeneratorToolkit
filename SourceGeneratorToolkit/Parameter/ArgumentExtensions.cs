namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensions for arguments
    /// </summary>
    public static class ArgumentExtensions
    {
        /// <summary>
        /// Adds an argument to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="argumentValue">The argument value</param>
        /// <returns>The parent container</returns>
        public static TContainer AddArgument<TContainer>(this ISupportsArguments<TContainer> @base, string argumentValue) where TContainer : SourceContainer
        {
            @base.Arguments.AddArgument(argumentValue);
            return (TContainer)@base;
        }

        /// <summary>
        /// Adds an argument to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="argumentName">The argument name</param>
        /// <param name="argumentValue">The argument value</param>
        /// <returns>The parent container</returns>
        public static TContainer AddArgument<TContainer>(this ISupportsArguments<TContainer> @base, string argumentName, string argumentValue) where TContainer : SourceContainer
        {
            @base.Arguments.AddArgument(argumentName, argumentValue);
            return (TContainer)@base;
        }
    }
}
