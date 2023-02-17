using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit
{
    internal class EmptyLineStatement : SourceStatement
    {
        public override string Name => nameof(EmptyLineStatement);

        public override int Order { get; set; } = int.MaxValue;

        private const string _newLine = "";

        public EmptyLineStatement(int order) 
        {
            Order = order;
            SourceText = _newLine;
        }

        public EmptyLineStatement()
        {
            SourceText = _newLine;
        }

        public override string GenerateSource()
        {
            var sb = new StringBuilder();

            sb.AppendLine(_newLine);


            return sb.ToString();
        }
    }
}
