using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ClassContainer : SourceContainer, ISourceModifier
    {
        public override string Name => nameof(ClassContainer);

        public override int Order { get; set; } = 10;

        public ModifierContainer Modifiers { get; } = new ModifierContainer();

        private readonly int _indentLevel;

        public ClassContainer(string className, int indentLevel)
        {
            SourceText = className;
            _indentLevel = indentLevel;
        }

        public override string GenerateSource()
        {
            var sb = new StringBuilder();

            sb.Append("", _indentLevel);

            sb.Append(Modifiers.GenerateSource());


            sb.AppendLine($"class {SourceText}");
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
