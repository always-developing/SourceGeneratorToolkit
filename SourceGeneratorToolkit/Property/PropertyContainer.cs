using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class PropertyContainer : SourceContainer
    {
        internal override string Name => nameof(PropertyContainer);

        internal AccessModifierStatement _accessModifier;

        internal ModifierContainer _generalModifiers = new ModifierContainer();

        internal GetAccessorContainer _getter = new GetAccessorContainer();
        internal SetAccessorContainer _setter = new SetAccessorContainer();
        internal InitAccessorContainer _initer = null;

        internal string _defaultValue = null;

        public PropertyContainer(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        public override string ToSource()
        {
            if (_accessModifier != null)
            {
                SourceItems.Add(_accessModifier);
            }

            SourceItems.Add(_generalModifiers);
            SourceItems.Add(new Statement(SourceText));

            SourceItems.Add(new BraceStartStatement());

            if(_getter != null)
            {
                SourceItems.Add(_getter);
            }

            if (_setter != null)
            {
                SourceItems.Add(_setter);
            }

            if (_initer != null)
            {
                SourceItems.Add(_initer);
            }

            SourceItems.Add(new BraceEndStatement());

            if (_defaultValue != null)
            {
                SourceItems.Add(new EqualsStatement());
                SourceItems.Add(new Statement(_defaultValue));
                SourceItems.Add(new SemiColonStatement());
            }
            
            SourceItems.Add(new NewLineStatement());

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

        public PropertyContainer AsStatic()
        {
            _generalModifiers.SourceItems.Add(new StaticModifierStatement());
            return this;
        }
    }
}
