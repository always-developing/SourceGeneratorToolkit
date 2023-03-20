using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FieldContainer : SourceContainer
    {
        internal override string Name => nameof(FieldContainer);

        internal AccessModifierStatement _accessModifier;

        internal ModifierContainer _generalModifiers = new ModifierContainer();

        internal string _defaultValue = null;

        public FieldContainer(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        public override string ToSource()
        {
            if(_accessModifier != null)
            {
                _sourceItems.Add(_accessModifier);
            }

            _sourceItems.Add(_generalModifiers);
            _sourceItems.Add(new Statement(SourceText));

            if(_defaultValue != null)
            {
                _sourceItems.Add(new EqualsStatement());
                _sourceItems.Add(new Statement(_defaultValue));
            }

            _sourceItems.Add(new SemiColonStatement());
            _sourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }

        public FieldContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement();
            return this;
        }

        public FieldContainer AsPrivate()
        {
            _accessModifier = new PrivateModifierStatement();
            return this;
        }

        public FieldContainer AsProtected()
        {
            _accessModifier = new ProtectedModifierStatement();
            return this;
        }

        public FieldContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }

        public FieldContainer WithValue(string value)
        {
            _defaultValue = value;
            return this;
        }

        public FieldContainer AsReadOnly() => _generalModifiers.AsReadOnly(this);

        public FieldContainer AsStatic() => _generalModifiers.AsStatic(this);
    }
}
