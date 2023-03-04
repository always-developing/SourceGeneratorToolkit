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
            if(string.IsNullOrEmpty(value))
            {
                return this;
            }

            _builder.Append($"{_indentation}{value}");
            return this;
        }

        public IndentedStringBuilder Append(string value, int indentLevel)
        {
            //if (string.IsNullOrEmpty(value))
            //{
            //    return this;
            //}

            string indentation = "";

            for (int i = 0; i < indentLevel; i++)
            {
                indentation += SourceToolkitSettings.Indent;
            }

            _builder.Append($"{indentation}{value}");
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

        public IndentedStringBuilder AppendLine(string value, int indentLevel)
        {
            if (!string.IsNullOrEmpty(value?.Trim()))
            {
                string indentation = "";

                for (int i = 0; i < indentLevel; i++)
                {
                    indentation += SourceToolkitSettings.Indent;
                }

                _builder.AppendLine($"{indentation}{value}");
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
