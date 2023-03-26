using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace SourceGeneratorToolkit
{
    public class AttributeStatement : SourceContainer, ISupportsArguments<AttributeStatement>
    {
        internal override string Name => nameof(AttributeStatement);

        public ArgumentList Arguments { get; } = new ArgumentList();

        public AppliesToStatement AttributeAppliesTo { get; internal set; }

        public AttributeStatement(string attributeName)
        {
            SourceText = attributeName.StartsWith("[") && attributeName.EndsWith("]")
            ? attributeName.Substring(1, attributeName.Length - 1)
            : attributeName;
        }

        public override string ToSource()
        {
            _sourceItems.Add(new BracketStartStatement());

            if(AttributeAppliesTo != null)
            {
                _sourceItems.Add(AttributeAppliesTo);
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
        
        public AttributeStatement AppliesTo(AttributeAppliesTo appliesTo)
        {
            AttributeAppliesTo = new AppliesToStatement(appliesTo);
            return this;
        }
    }
}
