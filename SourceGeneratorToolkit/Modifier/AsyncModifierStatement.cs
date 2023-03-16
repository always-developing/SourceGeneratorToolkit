using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class AsyncModifierStatement : SourceStatement
    {
        internal override string Name => nameof(AsyncModifierStatement);

        internal readonly bool _enforceTaskReturnType;

        public AsyncModifierStatement(bool enforceTaskReturnType = true)
        {
            SourceText = "async ";
            Order = 10;
            _enforceTaskReturnType = enforceTaskReturnType;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}