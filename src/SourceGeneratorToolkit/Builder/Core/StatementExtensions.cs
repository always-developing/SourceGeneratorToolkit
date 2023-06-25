namespace SourceGeneratorToolkit.Core
{
    /// <summary>
    /// Extension methods for the statement container
    /// </summary>
    public static class StatementExtensions
    {
        /// <summary>
        /// Adds a C# statement to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="statement">The C# statement</param>
        /// <returns>The parent container</returns>
        public static TContainer AddStatement<TContainer>(this ISupportsMethods<TContainer> @base, string statement) where TContainer : SourceContainer
        {
            ((SourceContainer)@base)._sourceItems.Add(new Statement(statement));

            return (TContainer)@base;
        }
    }
}
