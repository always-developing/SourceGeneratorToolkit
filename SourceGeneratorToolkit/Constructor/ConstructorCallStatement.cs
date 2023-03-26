using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ConstructorCallStatement : SourceContainer, ISupportsArguments<ConstructorCallStatement>
    {
        internal override string Name => nameof(ConstructorCallStatement);

        public ArgumentList Arguments { get; } = new ArgumentList();

        public ConstructorCallStatement AddArgument(string argumentValue)
        {
            Arguments.AddArgument(argumentValue);

            return this;
        }
    }
}
