using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodContainer : SourceContainer
    {
        internal override string Name => nameof(MethodContainer);

        internal ParameterContainer _parameterContainer = new ParameterContainer();

        internal ModifierContainer _generalModifiers = new ModifierContainer();

        internal AccessModifierStatement _accessModifier;

        internal string _returnType;

        public MethodContainer(string methodName, string returnType)
        {
            SourceText = methodName;
            _returnType = returnType;
        }

        public override string ToSource()
        {
            var sb = new StringBuilder();

            sb.Append(new NewLineStatement().ToSource());
            if (_accessModifier != null)
            {
                sb.Append($"{_accessModifier?.ToSource()}");
                sb.Append(_generalModifiers.ToSource());
                sb.AppendLine($"{_returnType} {SourceText}({_parameterContainer.ToSource()})");
            }
            else
            {
                sb.Append(_generalModifiers.ToSource());
                sb.AppendLine($"{_returnType} {SourceText}({_parameterContainer.ToSource()})");
            }

            sb.Append(new BraceStartStatement().ToSource());
            sb.Append(new BraceEndStatement().ToSource());

            return sb.ToString();
        }

        public MethodContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement();
            return this;
        }

        public MethodContainer AsPrivate()
        {
            _accessModifier = new PrivateModifierStatement();
            return this;
        }

        public MethodContainer AsProtected()
        {
            _accessModifier = new ProtectedModifierStatement();
            return this;
        }

        public MethodContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }

        public MethodContainer AsAbstract()
        {
            _generalModifiers.SourceItems.Add(new AbstractModifierStatement());
            return this;
        }

        public MethodContainer AsStatic()
        {
            _generalModifiers.SourceItems.Add(new StaticModifierStatement());
            return this;
        }

        public MethodContainer AsPartial()
        {
            _generalModifiers.SourceItems.Add(new PartialModifierStatement());
            return this;
        }
    }
}
