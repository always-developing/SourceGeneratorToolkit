using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class DefaultValueContainer : SourceContainer
    {
        internal override string Name => nameof(DefaultValueContainer);

        private string _defaultValue = "";

        public void SetDefautlValue(string defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public override string ToSource()
        {
            if(!string.IsNullOrWhiteSpace(_defaultValue))
            {
                _sourceItems.Add(new EqualsStatement());
                _sourceItems.Add(new Statement(_defaultValue));
            }

            return base.ToSource();
        }
    }
}
