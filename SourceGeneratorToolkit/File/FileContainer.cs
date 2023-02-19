using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FileContainer : SourceContainer
    {
        internal override string Name => nameof(FileContainer);

        public FileContainer(string fileName)
        {
            SourceText = fileName;
        }

        public override string ToTree()
        {
            StringBuilder sb = IndentedStringBuilder();

            sb.AppendLine($"-{this.GetType().Name} ({SourceText})");

            return sb.ToString().TrimEnd();
        }

        public FileContainer WithUsing(string @using)
        {
            SourceItems.Add(new UsingStatemment(@using));

            return this;
        }
    }
}
