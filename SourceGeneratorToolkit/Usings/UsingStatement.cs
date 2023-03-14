﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit
{
    public class UsingStatement : SourceStatement
    {
        internal override string Name => nameof(UsingStatement);

        public UsingStatement(string @using)
        {
            SourceText = @using;
        }

        public override string ToSource()
        {
            return $"using {SourceText};";
        }
    }
}
