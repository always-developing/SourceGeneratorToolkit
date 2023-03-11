using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace SourceGeneratorToolkit
{
    public class AttributeStatement : SourceContainer
    {
        internal override string Name => nameof(AttributeStatement);

        internal ArgumentList _arguments = new ArgumentList();

        internal AppliesToStatement _appliesTo;

        public AttributeStatement(string attributeName)
        {
            SourceText = attributeName.StartsWith("[") && attributeName.EndsWith("]")
            ? attributeName.Substring(1, attributeName.Length - 1)
            : attributeName;
        }

        public override string ToSource()
        {
            _sourceItems.Add(new BracketStartStatement());

            if(_appliesTo != null)
            {
                _sourceItems.Add(_appliesTo);
            }

            _sourceItems.Add(new Statement(SourceText));
            
            if(_arguments.SourceItems.Any())
            {
                _sourceItems.Add(new ParenthesisStartStatement());
                _sourceItems.Add( _arguments);
                _sourceItems.Add(new ParenthesisEndStatement());
            }

            _sourceItems.Add(new BracketEndStatement());

            return base.ToSource();
        }

        public AttributeStatement AddArgument(string argumentValue)
        {
            _arguments.AddArgument(new ArgumentContainer(argumentValue));

            return this;
        }

        public AttributeStatement AddArgument(string argumentName, string argumentValue)
        {
            _arguments.AddArgument(new ArgumentContainer(argumentName, argumentValue));

            return this;
        }

        public AttributeStatement AppliesTo(AppliesTo appliesTo)
        {
            _appliesTo = new AppliesToStatement(appliesTo);

            return this;
        }
    }
}
