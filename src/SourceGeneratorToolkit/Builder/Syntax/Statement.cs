﻿namespace SourceGeneratorToolkit
{
    internal class Statement : SourceStatement
    {
        internal override string Name => nameof(Statement);

        public Statement(string statement)
        {
            SourceText = statement;
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
