using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace SourceGeneratorToolkit
{
    public class AttributeContainer : SourceContainer
    {
        internal override string Name => nameof(AttributeContainer);

        internal ArgumentList _arguments = new ArgumentList();

        public AttributeContainer(string attributeName)
        {
            SourceText = attributeName.StartsWith("[") && attributeName.EndsWith("]")
            ? attributeName.Substring(1, attributeName.Length - 1)
            : attributeName;
        }

        public override string ToSource()
        {
            SourceItems.Add(new BracketStartStatement());
            SourceItems.Add(new Statement(SourceText));
            
            if(_arguments.SourceItems.Any())
            {
                SourceItems.Add(new ParenthesisStartStatement());
                SourceItems.Add( _arguments);
                SourceItems.Add(new ParenthesisEndStatement());
            }

            SourceItems.Add(new BracketEndStatement());

            return base.ToSource();
        }

        public AttributeContainer AddArgument(string argumentValue)
        {
            _arguments.AddArgument(new ArgumentContainer(argumentValue));

            return this;
        }

        public AttributeContainer AddArgument(string argumentName, string argumentValue)
        {
            _arguments.AddArgument(new ArgumentContainer(argumentName, argumentValue));

            return this;
        }
    }
}
