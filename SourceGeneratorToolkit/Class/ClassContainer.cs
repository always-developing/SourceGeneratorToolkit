﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit
{
    public class ClassContainer : SourceContainer, IStaticModifier<ClassContainer>, IAbstractModifier<ClassContainer>, IPartialModifier<ClassContainer>,
        ISealedModifier<ClassContainer>, IPublicModifier<ClassContainer>, IPrivateModifier<ClassContainer>,
        IInternalModifier<ClassContainer>, IFileModifier<ClassContainer>, IProtectedModifier<ClassContainer>, IUnsafeModifier<ClassContainer>,
        ISupportsGenerics<ClassContainer>, ISupportsGenericsConstraints<ClassContainer>, ISupportsAttributes<ClassContainer>,
        ISupportsComments<ClassContainer>, ISupportsDocumentation<ClassContainer>, ISupportsImplementation<ClassContainer>,
        ISupportsInheritence<ClassContainer>, ISupportsProperty<ClassContainer>, ISupportsField<ClassContainer>, IPrivateProtectedModifier<ClassContainer>,
        IProtectedInternalModifier<ClassContainer>, ISupportsMethods<ClassContainer>, ISupportsStatement<ClassContainer>

    {
        internal override string Name => nameof(ClassContainer);

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public GenericList GenericList { get; } = new GenericList();

        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        public InheritenceContainer Inherits { get; } = new InheritenceContainer();

        public ImplementsContainer Implements { get; } = new ImplementsContainer();

        public DocumentationContainer Documentation { get; } = new DocumentationContainer();

        public PropertyList Properties { get; } = new PropertyList();

        public FieldList Fields { get; } = new FieldList();

        public ClassContainer(string className)
        {
            SourceText = className;
        }

        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                Documentation,
                AttributeList,
                AccessModifier,
                GeneralModifiers,
                new Statement($"class {SourceText}"),
                GenericList,
                Inherits
            };

            Implements.ParentAlsoInherits(Inherits.SourceItems.Any());

            builderList.Add(Implements);
            builderList.Add(ConstraintContainer);
            builderList.Add(new NewLineStatement());
            builderList.Add(new BraceStartStatement());

            _sourceItems.InsertRange(0, builderList);

            _sourceItems.Add(Fields);
            _sourceItems.Add(Properties);

            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
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

        
    }
}
