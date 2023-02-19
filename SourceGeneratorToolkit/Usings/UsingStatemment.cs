﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit
{
    public class UsingStatemment : SourceStatement
    {
        internal override string Name => nameof(UsingStatemment);

        public UsingStatemment(string @using)
        {
            SourceText = @using;
        }

        public override string ToSource()
        {
            return $"using {SourceText};";
        }
    }
}
