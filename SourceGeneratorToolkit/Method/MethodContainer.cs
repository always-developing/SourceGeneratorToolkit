using System;
using System.Collections.Generic;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a method
    /// </summary>
    public class MethodContainer : SourceContainer, IPublicModifier<MethodContainer>, IPrivateModifier<MethodContainer>, IProtectedModifier<MethodContainer>,
        IInternalModifier<MethodContainer>, IAbstractModifier<MethodContainer>, IStaticModifier<MethodContainer>, IPartialModifier<MethodContainer>,
        IAsyncModifier<MethodContainer>, ISupportsReturnValue, ISupportsGenerics<MethodContainer>, ISupportsGenericsConstraints<MethodContainer>,
        ISupportsParameters<MethodContainer>, ISupportsComments<MethodContainer>, ISupportsDocumentation<MethodContainer>, IUnsafeModifier<MethodContainer>,
        IPrivateProtectedModifier<MethodContainer>, IOverrideModifier<MethodContainer>, IProtectedInternalModifier<MethodContainer>,
        IVirtualModifier<MethodContainer>, ISupportsStatement<MethodContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(MethodContainer);

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public ReturnContainer ReturnType { get; } = new ReturnContainer();

        /// <inheritdoc/>
        public GenericList GenericList { get; } = new GenericList();

        /// <inheritdoc/>
        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        /// <inheritdoc/>
        public ParameterContainer ParameterContainer { get; } = new ParameterContainer();

        /// <inheritdoc/>
        public DocumentationContainer Documentation { get; } = new DocumentationContainer();

        /// <summary>
        /// Constructor for MethodContainer
        /// </summary>
        /// <param name="methodName">The method name</param>
        public MethodContainer(string methodName)
        {
            SourceText = methodName;
            ReturnType = new ReturnContainer();
        }

        /// <summary>
        /// Constructor for MethodContainer
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The method return type</param>
        public MethodContainer(string methodName, string returnType)
        {
            SourceText = methodName;
            ReturnType = new ReturnContainer(returnType);
        }

        /// <summary>
        /// Constructor for MethodContainer
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The method return type</param>
        public MethodContainer(string methodName, Type returnType)
        {
            SourceText = methodName;
            ReturnType = new ReturnContainer(returnType);
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                Documentation,
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

        /// <summary>
        /// Adds a body to the method
        /// </summary>
        /// <param name="body">The method body</param>
        /// <returns>The method container</returns>
        public MethodContainer WithBody(string body)
        {
            _sourceItems.Add(new Statement(body));

            return this;
        }
    }
}
