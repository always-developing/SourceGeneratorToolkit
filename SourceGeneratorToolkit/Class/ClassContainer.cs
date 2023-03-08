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

        internal ModifierContainer _generalModifiers = new ModifierContainer();

        internal GenericsContainer _genericsContainer = new GenericsContainer();

        internal GenericsConstraintContainer _constraintContainer = new GenericsConstraintContainer();

        internal InheritenceStatement _inheritenceStatement;

        internal ImplementsContainer _implementsContainer = new ImplementsContainer();

        public ClassContainer(string className)
        {
            SourceText = className;
        }

        public override string ToSource()
        {
            var tempList = new List<SourceStatement>();

            if(_accessModifier != null)
            {
                tempList.Add(_accessModifier);
            }
            tempList.Add(_generalModifiers);
            tempList.Add(new Statement($"class {SourceText}"));
            tempList.Add(_genericsContainer);

            if(_inheritenceStatement != null || _implementsContainer.SourceItems.Any())
            {
                tempList.Add(new ColonStatement());
            }

            if (_inheritenceStatement != null)
            {
                tempList.Add(_inheritenceStatement);

                if(_implementsContainer.SourceItems.Any())
                {
                    tempList.Add(new CommaStatement());
                }
            }

            tempList.Add(_implementsContainer);
            tempList.Add(_constraintContainer);
            tempList.Add(new NewLineStatement());
            tempList.Add(new BraceStartStatement());

            SourceItems.InsertRange(0, tempList);

            SourceItems.Add(new BraceEndStatement());

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

        public ClassContainer AsAbstract()
        {
            _generalModifiers.SourceItems.Add(new AbstractModifierStatement());
            return this;
        }

        public ClassContainer AsStatic()
        {
            _generalModifiers.SourceItems.Add(new StaticModifierStatement());
            return this;
        }

        public ClassContainer AsPartial()
        {
            _generalModifiers.SourceItems.Add(new PartialModifierStatement());
            return this;
        }

        public ClassContainer AsSealed()
        {
            _generalModifiers.SourceItems.Add(new SealedModifierStatement());
            return this;
        }

        public ClassContainer AddGeneric(string value)
        {
            _genericsContainer.SourceItems.Add(new GenericContainer(value));
            return this;
        }

        public ClassContainer WithGenericConstraint(string generic, string constraint)
        {
            _constraintContainer.AddConstraint(generic, constraint);

            return this;
        }

        public ClassContainer WithConstructor()
        {
            SourceItems.Add(new ConstructorContainer(SourceText));

            return this;
        }

        public ClassContainer WithConstructor(Action<ConstructorContainer> constructorBuilder)
        {
            var constructor = new ConstructorContainer(SourceText);
            SourceItems.Add(constructor);

            constructorBuilder.Invoke(constructor);

            return this;
        }

        public ClassContainer WithMethod(string methodName, string returnType)
        {
            SourceItems.Add(new MethodContainer(methodName, returnType));

            return this;
        }

        public ClassContainer WithMethod(string methodName, string returnType, Action<MethodContainer> builder)
        {
            var container = new MethodContainer(methodName, returnType);
            SourceItems.Add(container);

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
            _implementsContainer.SourceItems.Add(new ImplementStatement(implementsInterface));
            _implementsContainer.SourceItems.Add(new CommaStatement());

            return this;
        }

        public ClassContainer AddField(string type, string name, Action<FieldContainer> builder = null)
        {
            var fieldContainer = new FieldContainer(type, name);
            SourceItems.Add(fieldContainer);

            builder?.Invoke(fieldContainer);

            return this;
        }

        public ClassContainer AddProperty(string type, string name, Action<PropertyContainer> builder = null)
        {
            var propertyContainer = new PropertyContainer(type, name);
            SourceItems.Add(propertyContainer);

            builder?.Invoke(propertyContainer);

            return this;
        }
    }
}
