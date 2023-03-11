using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class AttributeContainer : SourceContainer
    {
        internal override string Name => nameof(AttributeContainer);

        public AttributeStatement AddAttribute(string attributeName)
        {
            var attribute = new AttributeStatement(attributeName);
            _sourceItems.Add(attribute);

            return attribute;
        }
    }
}
