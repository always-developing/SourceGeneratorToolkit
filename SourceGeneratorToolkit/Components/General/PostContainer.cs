using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class PostContainer : SourceContainer
    {
        public override string Name => nameof(PostContainer);

        public override int Order { get; set; } = 1;

        public override string GenerateSource()
        {
            var sb = new StringBuilder();

            foreach (var statement in SourceItems.OrderBy(m => m.Order))
            {
                sb.Append($"{statement.GenerateSource()} ");
            }

            return sb.ToString();
        }
    }
}