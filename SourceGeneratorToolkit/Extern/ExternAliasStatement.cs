namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing an extern alias
    /// </summary>
    public class ExternAliasStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ExternAliasStatement);

        /// <summary>
        /// Constructor for ExternAliasStatement
        /// </summary>
        /// <param name="externAlias">The extern alias statement</param>
        public ExternAliasStatement(string externAlias)
        {
            SourceText = externAlias;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return $"extern alias {SourceText};";
        }
    }
}
