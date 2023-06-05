using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing an attribute
    /// </summary>
    public class AttributeStatement : SourceContainer, ISupportsArguments<AttributeStatement>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(AttributeStatement);

        /// <inheritdoc/>
        public ArgumentList Arguments { get; } = new ArgumentList();

        /// <inheritdoc/>
        public TargetsStatement AttributeTarget { get; internal set; }

        /// <summary>
        /// Constructor for the AttributeStatement class
        /// </summary>
        /// <param name="attributeName">The name of the attribute</param>
        public AttributeStatement(string attributeName)
        {
            SourceText = attributeName.StartsWith("[") && attributeName.EndsWith("]")
            ? attributeName.Substring(1, attributeName.Length - 1)
            : attributeName;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            _sourceItems.Add(new BracketStartStatement());

            if(AttributeTarget != null)
            {
                _sourceItems.Add(AttributeTarget);
            }

            _sourceItems.Add(new Statement(SourceText));
            
            if(Arguments.SourceItems.Any())
            {
                _sourceItems.Add(new ParenthesisStartStatement());
                _sourceItems.Add(Arguments);
                _sourceItems.Add(new ParenthesisEndStatement());
            }

            _sourceItems.Add(new BracketEndStatement());

            return base.ToSource();
        }
        
        /// <summary>
        /// Specifies the target type the attribute applies to
        /// </summary>
        /// <param name="target">The target type</param>
        /// <returns>The attribtue statement</returns>
        public AttributeStatement TargetsType(AttributeTarget target)
        {
            AttributeTarget = new TargetsStatement(target);
            return this;
        }
    }
}
