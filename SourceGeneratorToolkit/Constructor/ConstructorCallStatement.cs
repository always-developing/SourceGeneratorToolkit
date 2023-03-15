using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ConstructorCallStatement : SourceContainer
    {
        internal override string Name => nameof(ConstructorCallStatement);

        internal ArgumentList _arguments = new ArgumentList();

        public ConstructorCallStatement AddArgument(string argumentValue)
        {
            _arguments.AddArgument(new ArgumentContainer(argumentValue));

            return this;
        }
    }
}
