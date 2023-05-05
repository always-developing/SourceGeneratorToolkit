using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Facilities the output of the container/statement heirarchy in the correct format
    /// </summary>
    public class IndentedStringBuilder 
    {
        private readonly StringBuilder _builder = new StringBuilder();

        private readonly string _indentation;

        /// <summary>
        /// Constructor for IndentedStringBuilder
        /// </summary>
        /// <param name="indentLevel">The intent level at the current position in the heirarchy</param>
        public IndentedStringBuilder(int indentLevel)
        {
            for (int i = 0; i < indentLevel; i++)
            {
                _indentation += SourceToolkitSettings.Indent;
            }
        }

        /// <summary>
        /// Appends to the existing text
        /// </summary>
        /// <param name="value">The value to append</param>
        /// <returns>The indented string builder</returns>
        public IndentedStringBuilder Append(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return this;
            }

            _builder.Append($"{_indentation}{value}");
            return this;
        }

        /// <summary>
        /// Appends to the existing text
        /// </summary>
        /// <param name="value">The value to append</param>
        /// <param name="indentLevel">The indent level to use when appending</param>
        /// <returns>The indented string builder</returns>
        public IndentedStringBuilder Append(string value, int indentLevel)
        {
            string indentation = "";

            for (int i = 0; i < indentLevel; i++)
            {
                indentation += SourceToolkitSettings.Indent;
            }

            _builder.Append($"{indentation}{value}");
            return this;
        }

        /// <summary>
        /// Appends a line to the existing text
        /// </summary>
        /// <param name="value">The value to append</param>
        /// <returns>The indented string builder</returns>
        public IndentedStringBuilder AppendLine(string value)
        {
            if (!string.IsNullOrEmpty(value?.Trim()))
            {
                _builder.AppendLine($"{_indentation}{value}");
                return this;
            }

            return this;
        }

        /// <summary>
        /// Appends a line to the existing text
        /// </summary>
        /// <param name="value">The value to append</param>
        /// <param name="indentLevel">The indent level to use when appending</param>
        /// <returns>The indented string builder</returns>
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

        /// <summary>
        /// Output the content of the string builder
        /// </summary>
        /// <returns>The contents</returns>
        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}
