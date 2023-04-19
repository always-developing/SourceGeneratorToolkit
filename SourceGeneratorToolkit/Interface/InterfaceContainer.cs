using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InterfaceContainer : SourceContainer, IPublicModifier<InterfaceContainer>, IPrivateModifier<InterfaceContainer>,
        IProtectedModifier<InterfaceContainer>, IInternalModifier<InterfaceContainer>, IFileModifier<InterfaceContainer>,
        IPartialModifier<InterfaceContainer>, ISupportsGenerics<InterfaceContainer>, ISupportsGenericsConstraints<InterfaceContainer>,
        ISupportsAttributes<InterfaceContainer>, ISupportsComments<InterfaceContainer>, ISupportsProperty<InterfaceContainer>,
        ISupportsImplementation<InterfaceContainer>, ISupportsField<InterfaceContainer>, IPrivateProtectedModifier<InterfaceContainer>,
        IProtectedInternalModifier<InterfaceContainer>, IUnsafeModifier<InterfaceContainer>
    {
        internal override string Name => nameof(InterfaceContainer);

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public GenericList GenericList { get; } = new GenericList();

        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        public ImplementsContainer Implements { get; } = new ImplementsContainer();

        public PropertyList Properties { get; } = new PropertyList();

        public FieldList Fields { get; } = new FieldList();

        public InterfaceContainer(string interfaceName)
        {
            SourceText = interfaceName;
        }

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

        public InterfaceContainer WithMethod(string methodName, string returnType)
        {
            _sourceItems.Add(new InterfaceMethodContainer(methodName, returnType));

            return this;
        }

        public InterfaceContainer WithMethod(string methodName, Type returnType)
        {
            _sourceItems.Add(new InterfaceMethodContainer(methodName, returnType));

            return this;
        }

        public InterfaceContainer WithMethod(string methodName, string returnType, Action<InterfaceMethodContainer> builder)
        {
            var container = new InterfaceMethodContainer(methodName, returnType);
            _sourceItems.Add(container);

            builder.Invoke(container);

            return this;
        }

        public InterfaceContainer WithMethod(string methodName, Type returnType, Action<InterfaceMethodContainer> builder)
        {
            var container = new InterfaceMethodContainer(methodName, returnType);
            _sourceItems.Add(container);

            builder.Invoke(container);

            return this;
        }
    }
}
