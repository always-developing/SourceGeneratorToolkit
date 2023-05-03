namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a generic constraint statement
    /// </summary>
    public class GenericConstraintStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(GenericConstraintStatement);

        /// <summary>
        /// Constructor for GenericConstraintStatement
        /// </summary>
        /// <param name="constraint">The constraint name</param>
        public GenericConstraintStatement(string constraint)
        {
            SourceText = constraint;
        }
    }
}
