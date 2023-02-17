using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder Append(this StringBuilder sb, string value, int indentLevel)
        {
            for(int i=0; i < indentLevel; i++)
            {
                sb.Append(Constants.Indent);
            }

            sb.Append(value);

            return sb;
        }

        public static StringBuilder AppendLine(this StringBuilder sb, string value, int indentLevel)
        {
            for (int i = 0; i < indentLevel; i++)
            {
                sb.Append(Constants.Indent);
            }

            sb.AppendLine(value);

            return sb;
        }
    }
}
