using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InterfaceMethodContainer : SourceContainer, IPublicModifier<InterfaceMethodContainer>, IPrivateModifier<InterfaceMethodContainer>,
        IProtectedModifier<InterfaceMethodContainer>, IInternalModifier<InterfaceMethodContainer>, IAbstractModifier<InterfaceMethodContainer>,
        IStaticModifier<InterfaceMethodContainer>, IPartialModifier<InterfaceMethodContainer>
    {
        internal override string Name => nameof(InterfaceMethodContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public ModifierContainer GeneralModifier { get; } = new ModifierContainer();

        internal ParameterContainer _parameterContainer = new ParameterContainer();

        internal GenericList _genericsList = new GenericList();

        internal GenericConstraintList _constraintContainer = new GenericConstraintList();

        internal ReturnContainer _returnType;

        public InterfaceMethodContainer(string methodName)
        {
            SourceText = methodName;
            _returnType = new ReturnContainer();
        }

        public InterfaceMethodContainer(string methodName, string returnType)
        {
            SourceText = methodName;
            _returnType = new ReturnContainer(returnType);
        }

        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                new NewLineStatement(),
                AccessModifier,
                GeneralModifier,
                _returnType,
                new Statement(SourceText),
                _genericsList,
                new ParenthesisStartStatement(),
                _parameterContainer,
                new ParenthesisEndStatement(),
                _constraintContainer,
                new SemiColonStatement()
            };

            _sourceItems.InsertRange(0, builderList);

            return base.ToSource();
        }

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
