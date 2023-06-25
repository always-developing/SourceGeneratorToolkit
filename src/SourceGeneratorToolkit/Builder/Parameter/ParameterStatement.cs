namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a a parameter
    /// </summary>
    public class ParameterStatement : SourceContainer, IOutModifier<ParameterStatement>, IInModifier<ParameterStatement>,
        IRefModifier<ParameterStatement>, ISupportsDefaultValue<ParameterStatement>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ParameterStatement);

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        /// <inheritdoc/>
        public DefaultValueContainer DefaultValue { get; } = new DefaultValueContainer();

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
            _sourceItems.Add(DefaultValue);

            return base.ToSource();
        }
    }
}
