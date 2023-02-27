using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ConstructorContainer : SourceContainer
    {
        internal override string Name => nameof(ConstructorContainer);

        internal ParameterContainer _parameterContainer = new ParameterContainer();

        public ConstructorContainer(string className, int indentLevel)
        {
            SourceText = className;
            IndentLevel = indentLevel;
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append(new NewLineStatement().ToSource());
            sb.AppendLine($"{SourceText}({_parameterContainer.ToSource()})");
            sb.Append(new BraceStartStatement().ToSource());
            sb.Append(new BraceEndStatement(0).ToSource());

            return sb.ToString();
        }

        public ConstructorContainer AddParameter(string type, string name)
        {
            _parameterContainer.SourceItems.Add(new ParameterStatement(type, name));

            return this;
        }
    }
}
