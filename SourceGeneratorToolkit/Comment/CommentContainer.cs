using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class CommentContainer : SourceContainer
    {
        internal override string Name => nameof(CommentContainer);

        public CommentContainer(string comment)
        {
            _sourceItems.Add(new CommentStatement(comment));
           
        }
    }
}
