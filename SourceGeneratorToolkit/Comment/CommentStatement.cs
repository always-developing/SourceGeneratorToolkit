using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class CommentStatement : SourceStatement
    {
        internal override string Name => nameof(CommentStatement);

        public CommentStatement(string comment)
        {
            SourceText = comment.StartsWith("//") ? 
                comment : 
                SourceText = $"// {comment}";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
