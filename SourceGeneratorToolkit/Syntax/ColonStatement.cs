﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class ColonStatement : SourceStatement
    {
        internal override string Name => nameof(ColonStatement);

        public ColonStatement()
        {
            SourceText = ":";
        }

        public override string ToSource()
        {
            return SourceText;
        }
    }
}
