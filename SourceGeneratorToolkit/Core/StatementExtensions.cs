using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SourceGeneratorToolkit.Core
{
    public static class StatementExtensions
    {
        public static SourceContainer AddStatement<T>(this ISupportsMethods<T> @base, string statement) where T : SourceContainer
        {
            ((SourceContainer)@base)._sourceItems.Add(new Statement(statement));

            return (T)@base;
        }
    }
}
