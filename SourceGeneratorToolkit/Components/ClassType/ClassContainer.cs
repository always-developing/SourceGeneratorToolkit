using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ClassContainer : ISourceContainer, ISourceModifier
    {
        public List<ISourceStatement> SourceItems { get; }

        public string Name => nameof(ClassContainer);

        public int Order { get; set; } = 10;

        public List<ISourceStatement> Modifiers { get; }

        private readonly string _className;

        private readonly int _indentLevel;

        public ClassContainer(string className, int indentLevel)
        {
            _className = className;
            _indentLevel = indentLevel;

            SourceItems = new List<ISourceStatement>();
            Modifiers = new List<ISourceStatement>();
        }

        public string GenerateSource()
        {
            var sb = new StringBuilder();

            sb.Append("", _indentLevel);

            foreach (var modifier in Modifiers.OrderBy(m => m.Order))
            {
                sb.Append($"{modifier.GenerateSource()} ");
            }
            sb.AppendLine($"class {_className}");
            sb.AppendLine("{", _indentLevel);

            foreach (var generator in SourceItems.OrderBy(s => s.Order))
            {
                sb.AppendLine(generator.GenerateSource(), _indentLevel);
            }

            sb.AppendLine("}", _indentLevel);
            return sb.ToString();
        }
    }
}
