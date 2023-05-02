namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a comment
    /// </summary>
    public class CommentStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(CommentStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comment">The comment</param>
        public CommentStatement(string comment)
        {
            SourceText = comment.StartsWith("//") ? 
                comment : 
                SourceText = $"// {comment}";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
