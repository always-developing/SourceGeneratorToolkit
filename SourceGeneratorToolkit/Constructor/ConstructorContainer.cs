using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ConstructorContainer : SourceContainer, IPublicModifier<ConstructorContainer>, IPrivateModifier<ConstructorContainer>,
        IProtectedModifier<ConstructorContainer>, IInternalModifier<ConstructorContainer>, IProtectedInternalModifier<ConstructorContainer>,
        IPrivateProtected<ConstructorContainer>, ISupportsParameters<ConstructorContainer>
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
            _sourceItems.Add(new NewLineStatement());
            _sourceItems.Add(AccessModifier);
            _sourceItems.Add(new Statement(SourceText));
            _sourceItems.Add(new ParenthesisStartStatement());
            _sourceItems.Add(ParameterContainer);
            _sourceItems.Add(new ParenthesisEndStatement());
            if (ConstructorCalls != null)
            {
                _sourceItems.Add(ConstructorCalls);
            }
            _sourceItems.Add(new BraceStartStatement());
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
    }
}
