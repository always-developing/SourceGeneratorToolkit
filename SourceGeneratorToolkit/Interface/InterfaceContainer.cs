using System;
using System.Collections.Generic;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing an interface
    /// </summary>
    public class InterfaceContainer : SourceContainer, IPublicModifier<InterfaceContainer>, IPrivateModifier<InterfaceContainer>,
        IProtectedModifier<InterfaceContainer>, IInternalModifier<InterfaceContainer>, IFileModifier<InterfaceContainer>,
        IPartialModifier<InterfaceContainer>, ISupportsGenerics<InterfaceContainer>, ISupportsGenericsConstraints<InterfaceContainer>,
        ISupportsAttributes<InterfaceContainer>, ISupportsComments<InterfaceContainer>, ISupportsProperty<InterfaceContainer>,
        ISupportsImplementation<InterfaceContainer>, ISupportsField<InterfaceContainer>, IPrivateProtectedModifier<InterfaceContainer>,
        IProtectedInternalModifier<InterfaceContainer>, IUnsafeModifier<InterfaceContainer>, ISupportsStatement<InterfaceContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(InterfaceContainer);

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public GenericList GenericList { get; } = new GenericList();

        /// <inheritdoc/>
        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        /// <inheritdoc/>
        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        /// <inheritdoc/>
        public ImplementsContainer Implements { get; } = new ImplementsContainer();

        /// <inheritdoc/>
        public PropertyList Properties { get; } = new PropertyList();

        /// <inheritdoc/>
        public FieldList Fields { get; } = new FieldList();

        /// <summary>
        /// Constructor for InterfaceContainer
        /// </summary>
        /// <param name="interfaceName">The interface name</param>
        public InterfaceContainer(string interfaceName)
        {
            SourceText = interfaceName;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                AttributeList,
                AccessModifier,
                GeneralModifiers,
                new Statement($"interface {SourceText}"),
                GenericList,

                Implements,
                ConstraintContainer,
                new NewLineStatement(),
                new BraceStartStatement()
            };

            _sourceItems.InsertRange(0, builderList);

            _sourceItems.Add(Fields);
            _sourceItems.Add(Properties);

            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
        }

        /// <summary>
        /// Adds a method to the interface
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The method return type</param>
        /// <returns>The interface container</returns>
        public InterfaceContainer WithMethod(string methodName, string returnType)
        {
            _sourceItems.Add(new InterfaceMethodContainer(methodName, returnType));

            return this;
        }

        /// <summary>
        /// Adds a method to the interface
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The method return type</param>
        /// <returns>The interface container</returns>
        public InterfaceContainer WithMethod(string methodName, Type returnType)
        {
            _sourceItems.Add(new InterfaceMethodContainer(methodName, returnType));

            return this;
        }

        /// <summary>
        /// Adds a method to the interface
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The method return type</param>
        /// /// <param name="builder">The builder used to modify the properties of the interface method</param>
        /// <returns>The interface container</returns>
        public InterfaceContainer WithMethod(string methodName, string returnType, Action<InterfaceMethodContainer> builder)
        {
            var container = new InterfaceMethodContainer(methodName, returnType);
            _sourceItems.Add(container);

            builder.Invoke(container);

            return this;
        }

        /// <summary>
        /// Adds a method to the interface
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The method return type</param>
        /// /// <param name="builder">The builder used to modify the properties of the interface method</param>
        /// <returns>The interface container</returns>
        public InterfaceContainer WithMethod(string methodName, Type returnType, Action<InterfaceMethodContainer> builder)
        {
            var container = new InterfaceMethodContainer(methodName, returnType);
            _sourceItems.Add(container);

            builder.Invoke(container);

            return this;
        }
    }
}
