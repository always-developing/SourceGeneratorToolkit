using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class ArgumentExtensions
    {
        public static T AddArgument<T>(this ISupportsArguments<T> @base, string argumentValue) where T : SourceContainer
        {
            @base.Arguments.AddArgument(argumentValue);
            return (T)@base;
        }

        public static T AddArgument<T>(this ISupportsArguments<T> @base, string argumentName, string argumentValue) where T : SourceContainer
        {
            @base.Arguments.AddArgument(argumentName, argumentValue);
            return (T)@base;
        }
    }
}
