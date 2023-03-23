using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InterfaceContainer : SourceContainer, IPublicModifier<InterfaceContainer>, IPrivateModifier<InterfaceContainer>,
        IProtectedModifier<InterfaceContainer>, IInternalModifier<InterfaceContainer>, IFileModifier<InterfaceContainer>,
        IPartialModifier<InterfaceContainer>
    {
        internal override string Name => nameof(InterfaceContainer);

        public ModifierContainer GeneralModifier { get; } = new ModifierContainer();

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        internal GenericList _genericList = new GenericList();

        internal AttributeContainer _attributeList = new AttributeContainer();

        internal GenericConstraintList _constraintContainer = new GenericConstraintList();

        internal ImplementsContainer _implementsContainer = new ImplementsContainer();

        public InterfaceContainer(string interfaceName)
        {
            SourceText = interfaceName;
        }

        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                _attributeList,
                AccessModifier,
                GeneralModifier,
                new Statement($"interface {SourceText}"),
                _genericList,

                _implementsContainer,
                _constraintContainer,
                new NewLineStatement(),
                new BraceStartStatement()
            };

            _sourceItems.InsertRange(0, builderList);

            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
        }

        public InterfaceContainer AddGeneric(string value)
        {
            _genericList.AddGeneric(value);
            return this;
        }

        public InterfaceContainer WithGenericConstraint(string generic, string constraint)
        {
            _constraintContainer.AddConstraint(generic, constraint);

            return this;
        }

        public InterfaceContainer WithMethod(string methodName, string returnType)
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

        public InterfaceContainer Implements(string implementsInterface)
        {
            _implementsContainer.AddImplements(implementsInterface);

            return this;
        }

        public InterfaceContainer AddField(string type, string name, Action<FieldContainer> builder = null)
        {
            var fieldContainer = new FieldContainer(type, name);
            _sourceItems.Add(fieldContainer);

            builder?.Invoke(fieldContainer);

            return this;
        }

        public InterfaceContainer AddProperty(string type, string name, Action<PropertyContainer> builder = null)
        {
            var propertyContainer = new PropertyContainer(type, name);
            _sourceItems.Add(propertyContainer);

            builder?.Invoke(propertyContainer);

            return this;
        }

        public InterfaceContainer AddAttribute(string attributeName, Action<AttributeStatement> builder = null)
        {
            var attribute = _attributeList.AddAttribute(attributeName);
            builder?.Invoke(attribute);

            return this;
        }
    }
}
