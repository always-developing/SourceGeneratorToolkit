using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class ConstructorThisCallStatement : ConstructorCallStatement
    {
        internal override string Name => nameof(ConstructorThisCallStatement);

        public ConstructorThisCallStatement()
        {
            SourceText = "this";
        }

        public override string ToSource()
        {
            _sourceItems.Add(new ColonStatement());
            _sourceItems.Add(new Statement(SourceText));
            _sourceItems.Add(new ParenthesisStartStatement());
            _sourceItems.Add(Arguments);
            _sourceItems.Add(new ParenthesisEndStatement());

            return base.ToSource();
        }


    }
}
