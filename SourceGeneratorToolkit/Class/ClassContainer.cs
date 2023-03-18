using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit
{
    public class ClassContainer : SourceContainer
    {
        internal override string Name => nameof(ClassContainer);

        internal AccessModifierStatement _accessModifier;

        internal ModifierContainer<ClassContainer> _generalModifiers;

        internal GenericList _genericList = new GenericList();

        internal AttributeContainer _attributeList = new AttributeContainer();

        internal GenericConstraintList _constraintContainer = new GenericConstraintList();

        internal InheritenceStatement _inheritenceStatement;

        internal ImplementsContainer _implementsContainer = new ImplementsContainer();

        public ClassContainer(string className)
        {
            SourceText = className;

            _generalModifiers = new ModifierContainer<ClassContainer>(this);
        }

        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                _attributeList
            };

            if (_accessModifier != null)
            {
                builderList.Add(_accessModifier);
            }
            builderList.Add(_generalModifiers);
            builderList.Add(new Statement($"class {SourceText}"));
            builderList.Add(_genericList);

            if(_inheritenceStatement != null || _implementsContainer.SourceItems.Any())
            {
                builderList.Add(new ColonStatement());
            }

            if (_inheritenceStatement != null)
            {
                builderList.Add(_inheritenceStatement);

                if(_implementsContainer.SourceItems.Any())
                {
                    builderList.Add(new CommaStatement());
                }
            }

            builderList.Add(_implementsContainer);
            builderList.Add(_constraintContainer);
            builderList.Add(new NewLineStatement());
            builderList.Add(new BraceStartStatement());

            _sourceItems.InsertRange(0, builderList);

            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
        }

        public ClassContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement(); 
            return this; 
        }

        public ClassContainer AsPrivate()
        {
            _accessModifier = new PrivateModifierStatement();
            return this;
        }

        public ClassContainer AsProtected()
        {
            _accessModifier = new ProtectedModifierStatement();
            return this;
        }

        public ClassContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }

        public ClassContainer AsFile()
        {
            _accessModifier = new FileModifierStatement();
            return this;
        }

        public ClassContainer AsAbstract() => _generalModifiers.AsAbstract();

        public ClassContainer AsStatic() => _generalModifiers.AsStatic();

        public ClassContainer AsPartial() => _generalModifiers.AsPartial();

        public ClassContainer AsSealed() => _generalModifiers.AsSealed();

        public ClassContainer AddGeneric(string value)
        {
            _genericList.AddGeneric(value);
            return this;
        }

        public ClassContainer WithGenericConstraint(string generic, string constraint)
        {
            _constraintContainer.AddConstraint(generic, constraint);

            return this;
        }

        public ClassContainer WithConstructor()
        {
            _sourceItems.Add(new ConstructorContainer(SourceText));

            return this;
        }

        public ClassContainer WithConstructor(Action<ConstructorContainer> constructorBuilder)
        {
            var constructor = new ConstructorContainer(SourceText);
            _sourceItems.Add(constructor);

            constructorBuilder.Invoke(constructor);

            return this;
        }

        public ClassContainer WithMethod(string methodName, string returnType)
        {
            _sourceItems.Add(new MethodContainer(methodName, returnType));

            return this;
        }

        public ClassContainer WithMethod(string methodName, string returnType, Action<MethodContainer> builder)
        {
            var container = new MethodContainer(methodName, returnType);
            _sourceItems.Add(container);

            builder.Invoke(container);

            return this;
        }

        public ClassContainer Inherits(string baseClassName)
        {
            _inheritenceStatement = new InheritenceStatement(baseClassName);

            return this;
        }

        public ClassContainer Implements(string implementsInterface)
        {
            _implementsContainer.AddImplements(implementsInterface);

            return this;
        }

        public ClassContainer AddField(string type, string name, Action<FieldContainer> builder = null)
        {
            var fieldContainer = new FieldContainer(type, name);
            _sourceItems.Add(fieldContainer);

            builder?.Invoke(fieldContainer);

            return this;
        }

        public ClassContainer AddProperty(string type, string name, Action<PropertyContainer> builder = null)
        {
            var propertyContainer = new PropertyContainer(type, name);
            _sourceItems.Add(propertyContainer);

            builder?.Invoke(propertyContainer);

            return this;
        }

        public ClassContainer AddAttribute(string attributeName, Action<AttributeStatement> builder = null)
        {
            var attribute = _attributeList.AddAttribute(attributeName);
            builder?.Invoke(attribute);

            return this;
        }
    }
}
