using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class PropertyContainer : SourceContainer, IPublicModifier<PropertyContainer>, IPrivateModifier<PropertyContainer>,
        IProtectedInternalModifier<PropertyContainer>, IInternalModifier<PropertyContainer>, IVirtualModifier<PropertyContainer>, 
        IOverrideModifier<PropertyContainer>, IStaticModifier<PropertyContainer>, IRequiredModifier<PropertyContainer>,
        IPrivateProtectedModifier<PropertyContainer>, IAbstractModifier<PropertyContainer>, IProtectedModifier<PropertyContainer>, 
        IReadOnlyModifier<PropertyContainer>, IUnsafeModifier<PropertyContainer>
    {
        internal override string Name => nameof(PropertyContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public GetAccessorContainer Getter { get; protected set; } = new GetAccessorContainer();
        public SetAccessorContainer Setter { get; protected set; } = new SetAccessorContainer();

        public InitAccessorContainer Initer { get; protected set; }

        public string DefaultValue { get; internal set; }

        public PropertyContainer(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        public override string ToSource()
        {
            _sourceItems.Add(AccessModifier);
            _sourceItems.Add(GeneralModifiers);
            _sourceItems.Add(new Statement(SourceText));

            _sourceItems.Add(new BraceStartStatement());

            if(Getter != null)
            {
                _sourceItems.Add(Getter);
            }

            if (Setter != null)
            {
                _sourceItems.Add(Setter);
            }

            if (Initer != null)
            {
                _sourceItems.Add(Initer);
            }

            _sourceItems.Add(new BraceEndStatement());

            if (DefaultValue != null)
            {
                _sourceItems.Add(new EqualsStatement());
                _sourceItems.Add(new Statement(DefaultValue));
                _sourceItems.Add(new SemiColonStatement());
            }

            _sourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }

        public PropertyContainer WithValue(string value)
        {
            DefaultValue = value;
            return this;
        }

        public PropertyContainer WithGetter(Action<GetAccessorContainer> builder = null)
        {
            Getter = new GetAccessorContainer();
            builder?.Invoke(Getter);

            return this;
        }

        public PropertyContainer WithSetter(Action<SetAccessorContainer> builder = null)
        {
            Setter = new SetAccessorContainer();
            builder?.Invoke(Setter);

            Initer = null;

            return this;
        }

        public PropertyContainer WithIniter(Action<InitAccessorContainer> builder = null)
        {
            Setter = null;
            Initer = new InitAccessorContainer();
            builder?.Invoke(Initer);

            return this;
        }

        public PropertyContainer WithNoGetter() 
        {
            Getter = null;
            return this;
        }

        public PropertyContainer WithNoSetter()
        {
            Setter = null;
            return this;
        }

        
    }
}
