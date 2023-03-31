﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InterfaceContainer : SourceContainer, IPublicModifier<InterfaceContainer>, IPrivateModifier<InterfaceContainer>,
        IProtectedModifier<InterfaceContainer>, IInternalModifier<InterfaceContainer>, IFileModifier<InterfaceContainer>,
        IPartialModifier<InterfaceContainer>, ISupportsGenerics<InterfaceContainer>, ISupportsGenericsConstraints<InterfaceContainer>,
        ISupportsAttributes<InterfaceContainer>, ISupportsComments<InterfaceContainer>
    {
        internal override string Name => nameof(InterfaceContainer);

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public GenericList GenericList { get; } = new GenericList();

        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        internal ImplementsContainer _implementsContainer = new ImplementsContainer();

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

                _implementsContainer,
                ConstraintContainer,
                new NewLineStatement(),
                new BraceStartStatement()
            };

            _sourceItems.InsertRange(0, builderList);

            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
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
            var attribute = AttributeList.AddAttribute(attributeName);
            builder?.Invoke(attribute);

            return this;
        }
    }
}
