namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a "this" calll in a constructor
    /// </summary>
    public class ConstructorThisCallStatement : ConstructorCallStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ConstructorThisCallStatement);

        /// <summary>
        /// Constructor for ConstructorThisCallStatement
        /// </summary>
        public ConstructorThisCallStatement()
        {
            SourceText = "this";
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            _sourceItems.Add(new ColonStatement());
            _sourceItems.Add(new Statement(SourceText));
            _sourceItems.Add(new ParenthesisStartStatement());
            _sourceItems.Add(Arguments);
            _sourceItems.Add(new ParenthesisEndStatement());

            return base.ToSource();
        }
    }
}
