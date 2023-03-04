﻿using System;
using System.Collections.Generic;
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
            tempList.Add(_constraintContainer);
            tempList.Add(new NewLineStatement());
            tempList.Add(new BraceStartStatement());

            SourceItems.InsertRange(0, tempList);

            SourceItems.Add(new BraceEndStatement());

            return base.ToSource();

            //var sb = new  IndentedStringBuilder(IndentLevel);

            //sb.Append($"{_accessModifier?.ToSource()}");
            //sb.Append(_generalModifiers.ToSource(), 0);

            //sb.Append($"class {SourceText}", 0);

            //sb.Append(_genericsContainer.ToSource(), 0);
            //sb.Append(_constraintContainer.ToSource(), 0);

            //sb.Append(new NewLineStatement().ToSource(), 0);
            //sb.Append(new BraceStartStatement().ToSource());
            //sb.AppendLine(base.ToSource());
            //sb.Append(new BraceEndStatement(0).ToSource());

            //return sb.ToString();
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
    }
}
