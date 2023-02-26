using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class GenericContainer : SourceContainer
    {
        internal override string Name => nameof(GenericContainer);

        public GenericContainer(string value)
        {
            SourceText = value;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
