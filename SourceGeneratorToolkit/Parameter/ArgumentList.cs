using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ArgumentList : SourceContainer
    {
        internal override string Name => nameof(ArgumentList);

        public ArgumentList AddArgument(string argument)
        {
            var argContainer = new ArgumentContainer(argument);

            if (SourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(argContainer);

            return this;
        }

        public ArgumentList AddArgument(string argumentName, string argument)
        {
            var argContainer = new ArgumentContainer(argumentName, argument);

            if (SourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(argContainer);

            return this;
        }
    }
}
