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
            SourceItems.Add(new NewLineStatement());

            if (_accessModifier != null)
            {
                SourceItems.Add(_accessModifier);
            }

            SourceItems.Add(_generalModifiers);
            SourceItems.Add(new Statement($"{_returnType} {SourceText}"));
            SourceItems.Add(new ParenthesisStartStatement());
            SourceItems.Add(_parameterContainer);
            SourceItems.Add(new ParenthesisEndStatement());

            SourceItems.Add(new BraceStartStatement());
            SourceItems.Add(new BraceEndStatement());

            return base.ToSource();
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
