using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class CommentExtensions
    {
        public static T AddComment<T>(this ISupportsComments<T> @base, string comment) where T : SourceContainer
        {
            ((SourceContainer)@base)._sourceItems.Add(new NewLineStatement());
            ((SourceContainer)@base)._sourceItems.Add(new CommentStatement(comment));
            ((SourceContainer)@base)._sourceItems.Add(new NewLineStatement());

            return (T)@base;
        }

       
    }
}
