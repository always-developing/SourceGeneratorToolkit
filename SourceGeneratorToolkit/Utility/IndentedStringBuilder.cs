using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class IndentedStringBuilder 
    {
        private readonly StringBuilder _builder = new StringBuilder();

        private readonly string _indentation;

        public IndentedStringBuilder(int indentLevel)
        {
            for (int i = 0; i < indentLevel; i++)
            {
                _indentation += SourceToolkitSettings.Indent;
            }
        }

        public IndentedStringBuilder Append(string value)
        {
            //if(!string.IsNullOrEmpty(value?.Trim()))
            //{
            //    _builder.Append($"{_indentation}{value}");
            //}
            _builder.Append($"{_indentation}{value}");
            return this;
        }

        public IndentedStringBuilder AppendLine(string value)
        {
            if (!string.IsNullOrEmpty(value?.Trim()))
            {
                _builder.AppendLine($"{_indentation}{value}");
                return this;
            }

            return this;
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}
