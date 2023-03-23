using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class PropertyContainer : SourceContainer, IPublicModifier<PropertyContainer>, IPrivateModifier<PropertyContainer>,
        IProtectedInternalModifier<PropertyContainer>, IInternalModifier<PropertyContainer>, IVirtualModifier<PropertyContainer>, 
        IOverrideModifier<PropertyContainer>, IStaticModifier<PropertyContainer>

    {
        internal override string Name => nameof(PropertyContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public ModifierContainer GeneralModifier { get; } = new ModifierContainer();

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
            _sourceItems.Add(AccessModifier);
            _sourceItems.Add(GeneralModifier);
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
