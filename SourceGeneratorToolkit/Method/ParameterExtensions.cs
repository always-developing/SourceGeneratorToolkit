using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class ParameterExtensions
    {
        public static T AddParameter<T>(this ISupportsParameters<T> @base, string type, string name) where T : SourceContainer
        {
            @base.ParameterContainer.AddParameter(type, name);

            return (T)@base;
        }
    }
}
