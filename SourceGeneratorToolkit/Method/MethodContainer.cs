using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodContainer : SourceContainer, IPublicModifier<MethodContainer>, IPrivateModifier<MethodContainer>, IProtectedModifier<MethodContainer>,
        IInternalModifier<MethodContainer>, IAbstractModifier<MethodContainer>, IStaticModifier<MethodContainer>, IPartialModifier<MethodContainer>,
        IAsyncModifier<MethodContainer>, ISupportsReturnValue, ISupportsGenerics<MethodContainer>, ISupportsGenericsConstraints<MethodContainer>,
        ISupportsParameters<MethodContainer>
    {
        internal override string Name => nameof(MethodContainer);

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public ReturnContainer ReturnType { get; } = new ReturnContainer();

        public GenericList GenericList { get; } = new GenericList();

        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        public ParameterContainer ParameterContainer { get; } = new ParameterContainer();

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
                GeneralModifiers,
                ReturnType,
                new Statement(SourceText),
                GenericList,
                new ParenthesisStartStatement(),
                ParameterContainer,
                new ParenthesisEndStatement(),
                ConstraintContainer,
                new BraceStartStatement()
            };

            _sourceItems.InsertRange(0, builderList);
            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
        }
    }
}
