using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ConstructorContainer : SourceContainer
    {
        internal override string Name => nameof(ConstructorContainer);

        internal ParameterContainer _parameterContainer = new ParameterContainer();

        internal AccessModifierStatement _accessModifier;

        public ConstructorContainer(string className, int indentLevel)
        {
            SourceText = className;
            IndentLevel = indentLevel;
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            sb.Append(new NewLineStatement().ToSource());
            if (_accessModifier != null)
            {
                sb.Append($"{_accessModifier?.ToSource()}");
                sb.AppendLine($"{SourceText}({_parameterContainer.ToSource()})", 0);
            }
            else
            {
                sb.AppendLine($"{SourceText}({_parameterContainer.ToSource()})");
            }

            sb.Append(new BraceStartStatement().ToSource());
            sb.Append(new BraceEndStatement(0).ToSource());

            return sb.ToString();
        }

        public ConstructorContainer AddParameter(string type, string name)
        {
            _parameterContainer.SourceItems.Add(new ParameterStatement(type, name));

            return this;
        }

        public ConstructorContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement();
            return this;
        }

        public ConstructorContainer AsPrivate()
        {
            _accessModifier = new PrivateModifierStatement();
            return this;
        }

        public ConstructorContainer AsProtected()
        {
            _accessModifier = new ProtectedModifierStatement();
            return this;
        }

        public ConstructorContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }

        public ConstructorContainer AsProtectedInternal()
        {
            _accessModifier = new ProtectedInternalStatement();
            return this;
        }

        public ConstructorContainer AsPrivateProtected()
        {
            _accessModifier = new PrivateProtectedStatement();
            return this;
        }
    }
}
