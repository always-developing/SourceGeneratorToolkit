using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InterfaceMethodContainer : SourceContainer, IPublicModifier<InterfaceMethodContainer>, IPrivateModifier<InterfaceMethodContainer>,
        IProtectedModifier<InterfaceMethodContainer>, IInternalModifier<InterfaceMethodContainer>, IAbstractModifier<InterfaceMethodContainer>,
        IStaticModifier<InterfaceMethodContainer>, IPartialModifier<InterfaceMethodContainer>, ISupportsGenerics<InterfaceMethodContainer>,
        ISupportsGenericsConstraints<InterfaceMethodContainer>, ISupportsParameters<InterfaceMethodContainer>, ISupportsReturnValue,
        IAsyncModifier<InterfaceMethodContainer>, ISupportsComments<InterfaceMethodContainer>

    {
        internal override string Name => nameof(InterfaceMethodContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public GenericList GenericList { get; } = new GenericList();

        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        public ParameterContainer ParameterContainer { get; } = new ParameterContainer();

        public ReturnContainer ReturnType { get; internal set; }

        public InterfaceMethodContainer(string methodName)
        {
            SourceText = methodName;
            ReturnType = new ReturnContainer();
        }

        public InterfaceMethodContainer(string methodName, string returnType)
        {
            SourceText = methodName;
            ReturnType = new ReturnContainer(returnType);
        }

        public InterfaceMethodContainer(string methodName, Type returnType)
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
                ConstraintContainer
            };

            if(!_sourceItems.Any())
            {
                builderList.Add(new SemiColonStatement());
                _sourceItems.InsertRange(0, builderList);
            }
            else
            {
                builderList.Add(new BraceStartStatement());
                _sourceItems.InsertRange(0, builderList);
                _sourceItems.Add(new BraceEndStatement());
            }

            return base.ToSource();
        }

        public InterfaceMethodContainer WithBody(string body)
        {
            _sourceItems.Add(new Statement(body));

            return this;
        }
    }
}
