using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FieldList : SourceContainer
    {
        internal override string Name => nameof(ArgumentList);

        public FieldContainer AddField(string type, string name, Action<FieldContainer> builder = null)
        {
            var fieldContainer = new FieldContainer(type, name);
            _sourceItems.Add(fieldContainer);

            builder?.Invoke(fieldContainer);

            return fieldContainer;
        }
    }
}
