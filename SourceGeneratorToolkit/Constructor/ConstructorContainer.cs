using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ConstructorContainer : SourceContainer
    {
        internal override string Name => nameof(ConstructorContainer);

        internal ParameterContainer _parameterContainer = new ParameterContainer();

        internal AccessModifierStatement _accessModifier;

        internal ConstructorCallStatement _constructorCalls;

        public ConstructorContainer(string className)
        {
            SourceText = className;
        }

        public override string ToSource()
        {
            _sourceItems.Add(new NewLineStatement());

            if (_accessModifier != null)
            {
                _sourceItems.Add(_accessModifier);
            }

            _sourceItems.Add(new Statement(SourceText));
            _sourceItems.Add(new ParenthesisStartStatement());
            _sourceItems.Add(_parameterContainer);
            _sourceItems.Add(new ParenthesisEndStatement());
            if (_constructorCalls != null)
            {
                _sourceItems.Add(_constructorCalls);
            }
            _sourceItems.Add(new BraceStartStatement());
            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();            
        }

        public ConstructorContainer AddParameter(string type, string name)
        {
            _parameterContainer.AddParameter(type, name);

            return this;
        }

        public ConstructorContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement();
            return this;
        }

        public ConstructorContainer AsPrivate()
        {
            _accessModifier = new PrivateModifierStatement();
            return this;
        }

        public ConstructorContainer AsProtected()
        {
            _accessModifier = new ProtectedModifierStatement();
            return this;
        }

        public ConstructorContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }

        public ConstructorContainer AsProtectedInternal()
        {
            _accessModifier = new ProtectedInternalModifierStatement();
            return this;
        }

        public ConstructorContainer AsPrivateProtected()
        {
            _accessModifier = new PrivateProtectedStatement();
            return this;
        }

        public ConstructorContainer CallsBase(Action<ConstructorCallStatement> builder = null)
        {
            _constructorCalls = new ConstructorBaseCallStatement();

            builder?.Invoke(_constructorCalls);

            return this;
        }

        public ConstructorContainer CallsThis(Action<ConstructorCallStatement> builder = null)
        {
            _constructorCalls = new ConstructorThisCallStatement();

            builder?.Invoke(_constructorCalls);

            return this;
        }
    }
}
