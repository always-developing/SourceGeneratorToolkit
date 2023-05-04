using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing an interface method
    /// </summary>
    public class InterfaceMethodContainer : SourceContainer, IPublicModifier<InterfaceMethodContainer>, IPrivateModifier<InterfaceMethodContainer>,
        IProtectedModifier<InterfaceMethodContainer>, IInternalModifier<InterfaceMethodContainer>, IAbstractModifier<InterfaceMethodContainer>,
        IStaticModifier<InterfaceMethodContainer>, IPartialModifier<InterfaceMethodContainer>, ISupportsGenerics<InterfaceMethodContainer>,
        ISupportsGenericsConstraints<InterfaceMethodContainer>, ISupportsParameters<InterfaceMethodContainer>, ISupportsReturnValue,
        IAsyncModifier<InterfaceMethodContainer>, ISupportsComments<InterfaceMethodContainer>, IPrivateProtectedModifier<InterfaceMethodContainer>,
        IProtectedInternalModifier<InterfaceMethodContainer>, IUnsafeModifier<InterfaceMethodContainer>, ISupportsStatement<InterfaceMethodContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(InterfaceMethodContainer);

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        /// <inheritdoc/>
        public GenericList GenericList { get; } = new GenericList();

        /// <inheritdoc/>
        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        /// <inheritdoc/>
        public ParameterContainer ParameterContainer { get; } = new ParameterContainer();

        /// <inheritdoc/>
        public ReturnContainer ReturnType { get; internal set; }

        /// <summary>
        /// Constructor for InterfaceMethodContainer
        /// </summary>
        /// <param name="methodName">The method name</param>
        public InterfaceMethodContainer(string methodName)
        {
            SourceText = methodName;
            ReturnType = new ReturnContainer();
        }

        /// <summary>
        /// Constructor for InterfaceMethodContainer
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The return type</param>
        public InterfaceMethodContainer(string methodName, string returnType)
        {
            SourceText = methodName;
            ReturnType = new ReturnContainer(returnType);
        }

        /// <summary>
        /// Constructor for InterfaceMethodContainer
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The return type</param>
        public InterfaceMethodContainer(string methodName, Type returnType)
        {
            SourceText = methodName;
            ReturnType = new ReturnContainer(returnType);
        }

        /// <inheritdoc/>
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

        /// <summary>
        /// Adds a body to the interface method
        /// </summary>
        /// <param name="body">The method body</param>
        /// <returns>The interface method</returns>
        public InterfaceMethodContainer WithBody(string body)
        {
            _sourceItems.Add(new Statement(body));

            return this;
        }
    }
}
