using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ReturnContainer : SourceContainer
    {
        internal override string Name => nameof(ReturnContainer);

        private const string VoidReturnType = "void";

        private bool _enforceAsync = false;

        public ReturnContainer()
        {
            SourceText = VoidReturnType;
        }

        public ReturnContainer(string returnType)
        {
            SourceText = returnType;
        }

        public void EnforceAsync(bool enforceAsync)
        {
            _enforceAsync = enforceAsync;
        }

        public override string ToSource()
        {
            if (!_enforceAsync)
            {
                _sourceItems.Add(new Statement(SourceText));
                _sourceItems.Add(new EmptySpaceStatement());

                return base.ToSource();
            }

            _sourceItems.Add(SourceText == VoidReturnType ? new TaskStatement() : new TaskStatement(SourceText));
            _sourceItems.Add(new EmptySpaceStatement());

            return base.ToSource();
        }
    }
}
