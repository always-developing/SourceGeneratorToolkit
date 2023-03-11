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
            _sourceItems.Add(new Statement(argumentValue));
        }

        public ArgumentContainer(string argumentName, string argumentValue)
        {
            _sourceItems.Add(new Statement(argumentName));
            _sourceItems.Add(new EqualsStatement());
            _sourceItems.Add(new Statement(argumentValue));
        }
    }
}
