using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit
{
    public class EnumMemberContainer : SourceContainer
    {
        internal override string Name => nameof(EnumMemberContainer);

        public EnumMemberContainer(string name)
        {
            _sourceItems.Add(new Statement(name));
        }

        public EnumMemberContainer(string name, string value)
        {
            _sourceItems.Add(new Statement(name));
            _sourceItems.Add(new EqualsStatement());
            _sourceItems.Add(new Statement(value));
        }
    }
}
