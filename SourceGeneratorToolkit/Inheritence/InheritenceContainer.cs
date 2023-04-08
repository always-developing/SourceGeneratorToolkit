using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InheritenceContainer : SourceContainer
    {
        internal override string Name => nameof(InheritenceContainer);

        public InheritenceContainer AddInheritence(string baseCLassName)
        {
            _sourceItems.Clear();

            _sourceItems.Add(new ColonStatement());
            _sourceItems.Add(new InheritenceStatement(baseCLassName));

            return this;
        }

        public InheritenceContainer IncludeColon()
        {
            _sourceItems.Insert(0, new ColonStatement());

            return this;
        }
    }
}
