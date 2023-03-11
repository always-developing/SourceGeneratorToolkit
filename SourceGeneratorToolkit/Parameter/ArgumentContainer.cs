using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ArgumentContainer : SourceContainer
    {
        internal override string Name => nameof(ArgumentContainer);

        public ArgumentContainer(string argumentValue)
        {
            SourceItems.Add(new Statement(argumentValue));
        }

        public ArgumentContainer(string argumentName, string argumentValue)
        {
            SourceItems.Add(new Statement(argumentName));
            SourceItems.Add(new EqualsStatement());
            SourceItems.Add(new Statement(argumentValue));
        }
    }
}
