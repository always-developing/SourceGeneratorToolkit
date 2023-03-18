using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodContainer : SourceContainer
    {
        internal override string Name => nameof(MethodContainer);

        internal ParameterContainer _parameterContainer = new ParameterContainer();

        internal ModifierContainer<MethodContainer> _generalModifiers;

        internal AccessModifierStatement _accessModifier;

        internal GenericList _genericsList = new GenericList();

        internal GenericConstraintList _constraintContainer = new GenericConstraintList();

        internal ReturnContainer _returnType;

        public MethodContainer(string methodName)
        {
            SourceText = methodName;
            _returnType = new ReturnContainer();

            _generalModifiers = new ModifierContainer<MethodContainer>(this);
        }

        public MethodContainer(string methodName, string returnType)
        {
            SourceText = methodName;
            _returnType = new ReturnContainer(returnType);

            _generalModifiers = new ModifierContainer<MethodContainer>(this);
        }

        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                new NewLineStatement()
            };

            if (_accessModifier != null)
            {
                builderList.Add(_accessModifier);
            }

            builderList.Add(_generalModifiers);
            builderList.Add(_returnType);
            builderList.Add(new Statement(SourceText));
            builderList.Add(_genericsList);
            builderList.Add(new ParenthesisStartStatement());
            builderList.Add(_parameterContainer);
            builderList.Add(new ParenthesisEndStatement());
            builderList.Add(_constraintContainer);
            builderList.Add(new BraceStartStatement());

            _sourceItems.InsertRange(0, builderList);
            _sourceItems.Add(new BraceEndStatement());

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

        public MethodContainer AsAbstract() => _generalModifiers.AsAbstract();

        public MethodContainer AsStatic() => _generalModifiers.AsStatic();

        public MethodContainer AsPartial() => _generalModifiers.AsPartial();

        public MethodContainer AddGeneric(string value)
        {
            _genericsList.AddGeneric(value);
            return this;
        }

        public MethodContainer AsAsync(bool enforceTaskReturnType = true)
        {
            _returnType.EnforceAsync(enforceTaskReturnType);
            return _generalModifiers.AsAsync(enforceTaskReturnType);
        }

        public MethodContainer WithGenericConstraint(string generic, string constraint)
        {
            _constraintContainer.AddConstraint(generic, constraint);

            return this;
        }
    }
}
