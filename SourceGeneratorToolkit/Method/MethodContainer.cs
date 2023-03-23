using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodContainer : SourceContainer, IPublicModifier<MethodContainer>, IPrivateModifier<MethodContainer>, IProtectedModifier<MethodContainer>,
        IInternalModifier<MethodContainer>, IAbstractModifier<MethodContainer>, IStaticModifier<MethodContainer>, IPartialModifier<MethodContainer>,
        IAsyncModifier<MethodContainer>, IHasReturnValue
    {
        internal override string Name => nameof(MethodContainer);

        internal ParameterContainer _parameterContainer = new ParameterContainer();

        public ModifierContainer GeneralModifier { get; } = new ModifierContainer();

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        internal GenericList _genericsList = new GenericList();

        internal GenericConstraintList _constraintContainer = new GenericConstraintList();

        public ReturnContainer ReturnType { get; } = new ReturnContainer();

        public MethodContainer(string methodName)
        {
            SourceText = methodName;
        }

        public MethodContainer(string methodName, string returnType)
        {
            SourceText = methodName;
            ReturnType = new ReturnContainer(returnType);
        }

        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                new NewLineStatement(),
                AccessModifier,
                GeneralModifier,
                ReturnType,
                new Statement(SourceText),
                _genericsList,
                new ParenthesisStartStatement(),
                _parameterContainer,
                new ParenthesisEndStatement(),
                _constraintContainer,
                new BraceStartStatement()
            };

            _sourceItems.InsertRange(0, builderList);
            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
        }

        public MethodContainer AddGeneric(string value)
        {
            _genericsList.AddGeneric(value);
            return this;
        }

        public MethodContainer WithGenericConstraint(string generic, string constraint)
        {
            _constraintContainer.AddConstraint(generic, constraint);

            return this;
        }
    }
}
