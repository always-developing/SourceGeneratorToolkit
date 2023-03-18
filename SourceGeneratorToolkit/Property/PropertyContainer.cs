using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class PropertyContainer : SourceContainer
    {
        internal override string Name => nameof(PropertyContainer);

        internal AccessModifierStatement _accessModifier;

        internal ModifierContainer<PropertyContainer> _generalModifiers;

        internal GetAccessorContainer _getter = new GetAccessorContainer();
        internal SetAccessorContainer _setter = new SetAccessorContainer();
        internal InitAccessorContainer _initer = null;

        internal string _defaultValue = null;

        public PropertyContainer(string type, string name)
        {
            SourceText = $"{type} {name}";

            _generalModifiers = new ModifierContainer<PropertyContainer>(this);
        }

        public override string ToSource()
        {
            if (_accessModifier != null)
            {
                _sourceItems.Add(_accessModifier);
            }

            _sourceItems.Add(_generalModifiers);
            _sourceItems.Add(new Statement(SourceText));

            _sourceItems.Add(new BraceStartStatement());

            if(_getter != null)
            {
                _sourceItems.Add(_getter);
            }

            if (_setter != null)
            {
                _sourceItems.Add(_setter);
            }

            if (_initer != null)
            {
                _sourceItems.Add(_initer);
            }

            _sourceItems.Add(new BraceEndStatement());

            if (_defaultValue != null)
            {
                _sourceItems.Add(new EqualsStatement());
                _sourceItems.Add(new Statement(_defaultValue));
                _sourceItems.Add(new SemiColonStatement());
            }

            _sourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }

        public PropertyContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement();
            return this;
        }

        public PropertyContainer AsPrivate()
        {
            _accessModifier = new PrivateModifierStatement();
            return this;
        }

        public PropertyContainer AsProtected()
        {
            _accessModifier = new ProtectedModifierStatement();
            return this;
        }

        public PropertyContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }

        public PropertyContainer AsVirtual() => _generalModifiers.AsVirtual();

        public PropertyContainer AsOverride() => _generalModifiers.AsOverride();

        public PropertyContainer AsStatic() => _generalModifiers.AsStatic();

        public PropertyContainer WithValue(string value)
        {
            _defaultValue = value;
            return this;
        }

        public PropertyContainer WithGetter()
        {
            _getter = new GetAccessorContainer();
            return this;
        }

        public PropertyContainer WithSetter()
        {
            _setter = new SetAccessorContainer();
            _initer = null;

            return this;
        }

        public PropertyContainer WithIniter()
        {
            _setter = null;
            _initer = new InitAccessorContainer(); 

            return this;
        }

        public PropertyContainer WithNoGetter() 
        {
            _getter = null;
            return this;
        }

        public PropertyContainer WithNoSetter()
        {
            _setter = null;
            return this;
        }

        
    }
}
