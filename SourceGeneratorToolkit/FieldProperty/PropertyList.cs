using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class PropertyList : SourceContainer
    {
        internal override string Name => nameof(ArgumentList);

        public PropertyContainer AddProperty(string type, string name, Action<PropertyContainer> builder = null)
        {
            var propContainer = new PropertyContainer(type, name);
            _sourceItems.Add(propContainer);

            builder?.Invoke(propContainer);

            return propContainer;
        }
    }
}
