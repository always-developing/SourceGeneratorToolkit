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

        public ConstructorContainer(string className)
        {
            SourceText = className;
        }

        public override string ToSource()
        {
            SourceItems.Add(new NewLineStatement());

            if (_accessModifier != null)
            {
                SourceItems.Add(_accessModifier);
            }

            SourceItems.Add(new Statement(SourceText));
            SourceItems.Add(new ParenthesisStartStatement());
            SourceItems.Add(_parameterContainer);
            SourceItems.Add(new ParenthesisEndStatement());
            SourceItems.Add(new BraceStartStatement());
            SourceItems.Add(new BraceEndStatement());

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
    }
}
