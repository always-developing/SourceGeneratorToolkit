using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class NewLineStatement : SourceStatement
    {
        internal override string Name => nameof(NewLineStatement);

        public NewLineStatement()
        {
            SourceText = "";
        }

        public override string ToSource()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(SourceText);

            return sb.ToString();
        }
    }
}
