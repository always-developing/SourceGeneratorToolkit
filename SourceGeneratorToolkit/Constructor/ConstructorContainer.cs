using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ConstructorContainer : SourceContainer, IPublicModifier<ConstructorContainer>, IPrivateModifier<ConstructorContainer>,
        IProtectedModifier<ConstructorContainer>, IInternalModifier<ConstructorContainer>, IProtectedInternalModifier<ConstructorContainer>,
        IPrivateProtectedModifier<ConstructorContainer>, ISupportsParameters<ConstructorContainer>, ISupportsComments<ConstructorContainer>,
        ISupportsStatement<ConstructorContainer>
    {
        internal override string Name => nameof(ConstructorContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public ParameterContainer ParameterContainer { get; } = new ParameterContainer();

        public ConstructorCallStatement ConstructorCalls { get; internal set; }

        public ConstructorContainer(string className)
        {
            SourceText = className;
        }

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

        public ConstructorContainer CallsBase(Action<ConstructorCallStatement> builder = null)
        {
            ConstructorCalls = new ConstructorBaseCallStatement();

            builder?.Invoke(ConstructorCalls);

            return this;
        }

        public ConstructorContainer CallsThis(Action<ConstructorCallStatement> builder = null)
        {
            ConstructorCalls = new ConstructorThisCallStatement();

            builder?.Invoke(ConstructorCalls);

            return this;
        }

        public ConstructorContainer WithBody(string body)
        {
            _sourceItems.Add(new Statement(body));

            return this;
        }
    }
}
