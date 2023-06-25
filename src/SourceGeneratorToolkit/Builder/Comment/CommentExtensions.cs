namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for the comment container
    /// </summary>
    public static class CommentExtensions
    {
        /// <summary>
        /// Adds a comment to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="comment">The comment to add</param>
        /// <returns>The parent container</returns>
        public static TContainer AddComment<TContainer>(this ISupportsComments<TContainer> @base, string comment) where TContainer : SourceContainer
        {
            ((SourceContainer)@base)._sourceItems.Add(new NewLineStatement());
            ((SourceContainer)@base)._sourceItems.Add(new CommentStatement(comment));
            ((SourceContainer)@base)._sourceItems.Add(new NewLineStatement());

            return (TContainer)@base;
        }

       
    }
}
