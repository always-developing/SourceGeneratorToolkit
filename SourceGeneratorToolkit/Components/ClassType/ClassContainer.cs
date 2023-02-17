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

        public ClassContainer(string className, int intendLevel)
        {
            SourceText = className;
            IndentLevel = intendLevel;
        }

        public override string GenerateSource()
        {
            var sb = new StringBuilder();

            sb.Append("", IndentLevel);
            sb.Append(Modifiers.GenerateSource());


            sb.AppendLine($"class {SourceText}");
            sb.AppendLine("{", IndentLevel);

            foreach (var generator in SourceItems.OrderBy(s => s.Order))
            {
                sb.Append(generator.GenerateSource(), IndentLevel);
            }

            sb.AppendLine("");
            sb.Append("}", IndentLevel);
            return sb.ToString();
        }
    }
}
