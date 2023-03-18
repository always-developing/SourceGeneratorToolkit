using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InterfaceMethodContainer : SourceContainer
    {
        internal override string Name => nameof(InterfaceMethodContainer);

        internal ParameterContainer _parameterContainer = new ParameterContainer();

        internal ModifierContainer<InterfaceMethodContainer> _generalModifiers;

        internal AccessModifierStatement _accessModifier;

        internal GenericList _genericsList = new GenericList();

        internal GenericConstraintList _constraintContainer = new GenericConstraintList();

        internal ReturnContainer _returnType;

        public InterfaceMethodContainer(string methodName)
        {
            SourceText = methodName;
            _returnType = new ReturnContainer();

            _generalModifiers = new ModifierContainer<InterfaceMethodContainer>(this);
        }

        public InterfaceMethodContainer(string methodName, string returnType)
        {
            SourceText = methodName;
            _returnType = new ReturnContainer(returnType);

            _generalModifiers = new ModifierContainer<InterfaceMethodContainer>(this);
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
            builderList.Add(new SemiColonStatement());

            _sourceItems.InsertRange(0, builderList);

            return base.ToSource();
        }

        public InterfaceMethodContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement();
            return this;
        }

        public InterfaceMethodContainer AsPrivate()
        {
            _accessModifier = new PrivateModifierStatement();
            return this;
        }

        public InterfaceMethodContainer AsProtected()
        {
            _accessModifier = new ProtectedModifierStatement();
            return this;
        }

        public InterfaceMethodContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }

        public InterfaceMethodContainer AsAbstract() => _generalModifiers.AsAbstract();

        public InterfaceMethodContainer AsStatic() => _generalModifiers.AsStatic();

        public InterfaceMethodContainer AsPartial() => _generalModifiers.AsPartial();

        public InterfaceMethodContainer AddGeneric(string value)
        {
            _genericsList.AddGeneric(value);
            return this;
        }

        public InterfaceMethodContainer AsAsync(bool enforceTaskReturnType = true)
        {
            _returnType.EnforceAsync(enforceTaskReturnType);

            return this;
        }

        public InterfaceMethodContainer WithGenericConstraint(string generic, string constraint)
        {
            _constraintContainer.AddConstraint(generic, constraint);

            return this;
        }
    }
}
