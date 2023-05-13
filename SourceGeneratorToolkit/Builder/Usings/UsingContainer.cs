namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a using statement
    /// </summary>
    public class UsingContainer : SourceContainer, IStaticModifier<UsingContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(UsingContainer);

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        internal bool _isGlobal = false;

        /// <summary>
        /// Constructor for UsingContainer
        /// </summary>
        /// <param name="using"></param>
        public UsingContainer(string @using)
        {
            SourceText = @using;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            if(_isGlobal)
            {
                _sourceItems.Add(new Statement("global "));
            }
            _sourceItems.Add(new Statement("using "));
            _sourceItems.Add(GeneralModifiers);
            _sourceItems.Add(new Statement(SourceText));
            _sourceItems.Add(new SemiColonStatement());

            return base.ToSource();
        }

        /// <summary>
        /// Flags the using statement as global
        /// </summary>
        /// <returns></returns>
        public UsingContainer AsGlobal()
        {
            _isGlobal = true;
            return this;
        }
    }
}
