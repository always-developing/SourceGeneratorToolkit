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
            var sb = new StringBuilder();

            foreach (var item in SourceItems.OrderBy(s => s.SourceText)) 
            {
                sb.AppendLine(item.ToSource());
            }

            sb.Append(new NewLineStatement().ToSource());

            return sb.ToString();
        }

        public UsingsContainer AddUsing(string @using)
        {
            _sourceItems.Add(new UsingStatement(@using));

            return this;
        }
    }
}
