using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ArgumentList : SourceContainer
    {
        internal override string Name => nameof(ArgumentList);

        public ArgumentList AddArgument(ArgumentContainer argument)
        {
            if(SourceItems.Any())
            {
                SourceItems.Add(new CommaStatement());
            }

            SourceItems.Add(argument);

            return this;
        }
    }
}
