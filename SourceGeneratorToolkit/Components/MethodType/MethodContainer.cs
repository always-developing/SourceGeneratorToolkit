using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodContainer : ISourceContainer, ISourceModifier
    {
        public List<ISourceStatement> SourceItems { get; }

        public string Name => nameof(MethodContainer);

        public int Order { get; set; } = 10;

        public List<ISourceStatement> Modifiers { get; }

        private MethodReturnStatement _returnType;

        public List<ISourceStatement> Parameters { get; }

        public List<ISourceStatement> PostStatements { get; }

        private readonly string _methodName;

        private readonly int _indentLevel;

        public MethodContainer(string methodName, int indentLevel)
        {
            _methodName = methodName;
            _indentLevel = indentLevel;

            SourceItems = new List<ISourceStatement>();
            Modifiers = new List<ISourceStatement>();
            Parameters = new List<ISourceStatement>();
            PostStatements = new List<ISourceStatement>();
        }

        public string GenerateSource()
        {
            var sb = new StringBuilder();

            sb.Append("", _indentLevel);

            foreach (var modifier in Modifiers.OrderBy(m => m.Order))
            {
                sb.Append($"{modifier.GenerateSource()} ");
            }
            sb.Append(_returnType.GenerateSource());
            sb.Append($" {_methodName}(");

            foreach (var parameter in Parameters)
            {
                sb.Append($"{parameter.GenerateSource()}");

                if(Parameters.Last() != parameter)
                {
                    sb.Append($", ");
                }
                else
                {
                    sb.Append($")");
                }
            }

            foreach (var statement in PostStatements.OrderBy(m => m.Order))
            {
                sb.Append($"{statement.GenerateSource()} ");
            }

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
