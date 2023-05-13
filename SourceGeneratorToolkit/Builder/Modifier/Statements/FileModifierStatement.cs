namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the file modifier
    /// </summary>
    public class FileModifierStatement : AccessModifierStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(FileModifierStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public FileModifierStatement()
        {
            SourceText = "file ";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
