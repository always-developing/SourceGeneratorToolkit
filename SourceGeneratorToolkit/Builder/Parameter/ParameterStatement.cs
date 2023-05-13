namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a a parameter
    /// </summary>
    public class ParameterStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ParameterStatement);

        /// <summary>
        /// Constructor for ParameterStatement
        /// </summary>
        /// <param name="type">The parameter type</param>
        /// <param name="name">The parameter name</param>
        public ParameterStatement(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}
