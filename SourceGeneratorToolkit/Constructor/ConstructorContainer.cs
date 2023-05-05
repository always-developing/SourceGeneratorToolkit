using System;
using System.Collections.Generic;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a constructor
    /// </summary>
    public class ConstructorContainer : SourceContainer, IPublicModifier<ConstructorContainer>, IPrivateModifier<ConstructorContainer>,
        IProtectedModifier<ConstructorContainer>, IInternalModifier<ConstructorContainer>, IProtectedInternalModifier<ConstructorContainer>,
        IPrivateProtectedModifier<ConstructorContainer>, ISupportsParameters<ConstructorContainer>, ISupportsComments<ConstructorContainer>,
        ISupportsStatement<ConstructorContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ConstructorContainer);

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public ParameterContainer ParameterContainer { get; } = new ParameterContainer();

        /// <inheritdoc/>
        public ConstructorCallStatement ConstructorCalls { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="className">The class name for the constructor</param>
        public ConstructorContainer(string className)
        {
            SourceText = className;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                new NewLineStatement(),
                AccessModifier,
                new Statement(SourceText),
                new ParenthesisStartStatement(),
                ParameterContainer,
                new ParenthesisEndStatement()
            };

            if (ConstructorCalls != null)
            {
                builderList.Add(ConstructorCalls);
            }
            builderList.Add(new BraceStartStatement());

            _sourceItems.InsertRange(0, builderList);
            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();            
        }

        /// <summary>
        /// Adds a "base" call to the constructor
        /// </summary>
        /// <param name="builder">The builder used to modify the properties of the constructor</param>
        /// <returns></returns>
        public ConstructorContainer CallsBase(Action<ConstructorCallStatement> builder = null)
        {
            ConstructorCalls = new ConstructorBaseCallStatement();

            builder?.Invoke(ConstructorCalls);

            return this;
        }

        /// <summary>
        /// Adds a "this" call to the constructor
        /// </summary>
        /// <param name="builder">The builder used to modify the properties of the constructor</param>
        /// <returns>The constructor container</returns>
        public ConstructorContainer CallsThis(Action<ConstructorCallStatement> builder = null)
        {
            ConstructorCalls = new ConstructorThisCallStatement();

            builder?.Invoke(ConstructorCalls);

            return this;
        }

        /// <summary>
        /// Specifies the body of the constructor
        /// </summary>
        /// <param name="body">The body of the constructor as text</param>
        /// <returns>The constructor container</returns>
        public ConstructorContainer WithBody(string body)
        {
            _sourceItems.Add(new Statement(body));

            return this;
        }
    }
}
