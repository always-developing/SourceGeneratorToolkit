using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ClassContainer : SourceContainer
    {
        internal override string Name => nameof(ClassContainer);

        public ClassContainer(string className)
        {
            SourceText = className;
        }
    }
}
