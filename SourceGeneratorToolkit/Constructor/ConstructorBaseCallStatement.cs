namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Container representing a constructor which calls "base"
    /// </summary>
    public class ConstructorBaseCallStatement : ConstructorCallStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ConstructorBaseCallStatement);

        /// <summary>
        /// Constructor
        /// </summary>
        public ConstructorBaseCallStatement()
        {
            SourceText = "base";
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
