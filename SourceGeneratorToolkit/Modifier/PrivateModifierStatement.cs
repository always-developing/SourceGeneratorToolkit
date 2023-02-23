﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class PrivateModifierStatement : AccessModifierStatement
    {
        internal override string Name => nameof(PrivateModifierStatement);

        public PrivateModifierStatement()
        {
            SourceText = "private ";
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append(SourceText);

            return sb.ToString();
        }
    }
}