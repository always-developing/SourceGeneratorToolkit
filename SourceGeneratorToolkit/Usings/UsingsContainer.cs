using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class UsingsContainer : SourceContainer
    {
        internal override string Name => nameof(UsingsContainer);

        public override string ToSource()
        {
            _sourceItems = _sourceItems.OrderBy(s => s.SourceText).ToList();
            _sourceItems = _sourceItems.SelectMany(ss => new[] { ss, new NewLineStatement() }).ToList();

            return base.ToSource();
        }

        public UsingsContainer AddUsing(string @using)
        {
            _sourceItems.Add(new UsingStatement(@using));

            return this;
        }
    }
}
