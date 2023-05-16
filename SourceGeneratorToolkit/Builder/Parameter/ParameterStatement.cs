namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a a parameter
    /// </summary>
    public class ParameterStatement : SourceContainer, IOutModifier<ParameterStatement>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ParameterStatement);

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

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
            _sourceItems.Add(GeneralModifiers);
            _sourceItems.Add(new Statement(SourceText));

            return base.ToSource();
        }
    }
}
