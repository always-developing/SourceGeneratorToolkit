using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ExternAliasStatement : SourceStatement
    {
        internal override string Name => nameof(ExternAliasStatement);

        public ExternAliasStatement(string @using)
        {
            SourceText = @using;
        }

        public override string ToSource()
        {
            return $"extern alias {SourceText};";
        }
    }
}
