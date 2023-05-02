namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a comment
    /// </summary>
    public class CommentContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(CommentContainer);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comment">The comment to add</param>
        public CommentContainer(string comment)
        {
            _sourceItems.Add(new CommentStatement(comment));
        }
    }
}
