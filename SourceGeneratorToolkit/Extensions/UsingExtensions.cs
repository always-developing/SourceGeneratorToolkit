using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static  class UsingExtensions
    {
        public static FileContainer WithUsing(this FileContainer container, string usingStatement)
        {
            container.SourceItems.Add(new UsingContainer(usingStatement));

            return container;
        }

        public static FileContainer WithUsing(this FileContainer container, params string[] usingStatements)
        {
            container.SourceItems.Add(new UsingContainer(usingStatements));

            return container;
        }
    }
}
