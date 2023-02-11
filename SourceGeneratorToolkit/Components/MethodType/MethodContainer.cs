using SourceGeneratorToolkit.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodContainer : SourceContainer, ISourceModifier, ISourcePost, ISourceParameters
    {
        public override string Name => nameof(MethodContainer);

        public override int Order { get; set; } = 10;

        private MethodReturnStatement _returnType;

        public ModifierContainer Modifiers { get; } = new ModifierContainer();

        public ParameterContainer Parameters { get; } = new ParameterContainer();

        public PostContainer PostStatements { get; } = new PostContainer();

        private readonly int _indentLevel;

        public MethodContainer(string methodName, int indentLevel)
        {
            SourceText = methodName;
            _indentLevel = indentLevel;
        }

        public override string GenerateSource()
        {
            var sb = new StringBuilder();

            sb.Append("", _indentLevel);

            sb.Append(Modifiers.GenerateSource());
            
            sb.Append(_returnType.GenerateSource());
            sb.Append($" {SourceText}(");

            sb.Append(Parameters.GenerateSource());

            sb.Append($")");

            sb.Append(PostStatements.GenerateSource());

            sb.AppendLine("");

            foreach (var generator in SourceItems.OrderBy(s => s.Order))
            {
                sb.AppendLine(generator.GenerateSource(), (_indentLevel + 2));
            }

            return sb.ToString();
        }

        internal void WithReturnType(MethodReturnStatement returnType)
        {
            _returnType = returnType;
        }
    }
}
