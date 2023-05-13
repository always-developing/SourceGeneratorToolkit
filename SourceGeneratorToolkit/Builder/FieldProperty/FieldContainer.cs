namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a field
    /// </summary>
    public class FieldContainer : SourceContainer, IPublicModifier<FieldContainer>, IPrivateModifier<FieldContainer>, IProtectedModifier<FieldContainer>,
        IInternalModifier<FieldContainer>, IReadOnlyModifier<FieldContainer>, IStaticModifier<FieldContainer>, ISupportsDefaultValue<FieldContainer>,
        IPrivateProtectedModifier<FieldContainer>, IOverrideModifier<FieldContainer>, IProtectedInternalModifier<FieldContainer>, IRequiredModifier<FieldContainer>,
        IUnsafeModifier<FieldContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(FieldContainer);

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        /// <inheritdoc/>
        public DefaultValueContainer DefaultValue { get; internal set; } = new DefaultValueContainer();

        /// <summary>
        /// Constructor for the FieldContainer class
        /// </summary>
        /// <param name="type">The field type</param>
        /// <param name="name">The field name</param>
        public FieldContainer(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            _sourceItems.Add(AccessModifier);
            _sourceItems.Add(GeneralModifiers);
            _sourceItems.Add(new Statement(SourceText));
            _sourceItems.Add(DefaultValue);
            _sourceItems.Add(new SemiColonStatement());
            _sourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }
    }
}