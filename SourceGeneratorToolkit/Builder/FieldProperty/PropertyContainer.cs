using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a property
    /// </summary>
    public class PropertyContainer : SourceContainer, IPublicModifier<PropertyContainer>, IPrivateModifier<PropertyContainer>,
        IProtectedInternalModifier<PropertyContainer>, IInternalModifier<PropertyContainer>, IVirtualModifier<PropertyContainer>, 
        IOverrideModifier<PropertyContainer>, IStaticModifier<PropertyContainer>, IRequiredModifier<PropertyContainer>,
        IPrivateProtectedModifier<PropertyContainer>, IAbstractModifier<PropertyContainer>, IProtectedModifier<PropertyContainer>, 
        IReadOnlyModifier<PropertyContainer>, IUnsafeModifier<PropertyContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(PropertyContainer);

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        /// <inheritdoc/>
        public GetAccessorContainer Getter { get; protected set; } = new GetAccessorContainer();

        /// <inheritdoc/>
        public SetAccessorContainer Setter { get; protected set; } = new SetAccessorContainer();

        /// <inheritdoc/>
        public InitAccessorContainer Initer { get; protected set; }

        /// <summary>
        /// The default value for the property
        /// </summary>
        public string DefaultValue { get; internal set; }

        /// <summary>
        /// Constructor for PropertyContainer
        /// </summary>
        /// <param name="type">The property type</param>
        /// <param name="name">The property name</param>
        public PropertyContainer(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        /// <inheritdoc/>
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

        /// <summary>
        /// Sets the default value of the property
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public PropertyContainer WithValue(string value)
        {
            DefaultValue = value;
            return this;
        }

        /// <summary>
        /// Sets the 'getter' of the property
        /// </summary>
        /// <param name="builder">The builder used to modify the properties of the getter</param>
        /// <returns>The property container</returns>
        public PropertyContainer WithGetter(Action<GetAccessorContainer> builder = null)
        {
            Getter = new GetAccessorContainer();
            builder?.Invoke(Getter);

            return this;
        }

        /// <summary>
        /// Sets the 'setter' of the property
        /// </summary>
        /// <param name="builder">The builder used to modify the properties of the setter</param>
        /// <returns>The property container</returns>
        public PropertyContainer WithSetter(Action<SetAccessorContainer> builder = null)
        {
            Setter = new SetAccessorContainer();
            builder?.Invoke(Setter);

            Initer = null;

            return this;
        }

        /// <summary>
        /// Sets the 'initter' of the property
        /// </summary>
        /// <param name="builder">The builder used to modify the properties of the initter</param>
        /// <returns>The property container</returns>
        public PropertyContainer WithIniter(Action<InitAccessorContainer> builder = null)
        {
            Setter = null;
            Initer = new InitAccessorContainer();
            builder?.Invoke(Initer);

            return this;
        }

        /// <summary>
        /// Removes the 'getter' from the property
        /// </summary>
        /// <returns>The property container</returns>
        public PropertyContainer WithNoGetter() 
        {
            Getter = null;
            return this;
        }

        /// <summary>
        /// Removes the 'setter' from the property
        /// </summary>
        /// <returns>The property container</returns>
        public PropertyContainer WithNoSetter()
        {
            Setter = null;
            return this;
        }
    }
}
