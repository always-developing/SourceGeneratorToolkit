using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FileModifierStatement : AccessModifierStatement
    {
        internal override string Name => nameof(FileModifierStatement);

        public FileModifierStatement()
        {
            SourceText = "file ";
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append(SourceText);

            return sb.ToString();
        }
    }
}
