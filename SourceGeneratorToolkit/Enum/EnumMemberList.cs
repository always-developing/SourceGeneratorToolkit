using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class EnumMemberList : SourceContainer
    {
        internal override string Name => nameof(EnumMemberList);

        public EnumMemberContainer AddEnumMember(string name)
        {
            var memberContainer = new EnumMemberContainer(name);

            if(_sourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(memberContainer);

            return memberContainer;
        }

        public EnumMemberContainer AddEnumMember(string name, string value)
        {
            var memberContainer = new EnumMemberContainer(name, value);

            if (_sourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(memberContainer);

            return memberContainer;
        }

        public override string ToSource()
        {
            return base.ToSource();
        }
    }
}
