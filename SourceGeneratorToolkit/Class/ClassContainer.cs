using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        ISupportsComments<ClassContainer>, ISupportsDocumentation<ClassContainer>, ISupportsImplementation<ClassContainer>

    {
        internal override string Name => nameof(ClassContainer);

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public GenericList GenericList { get; } = new GenericList();

        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        public InheritenceStatement Inherits { get; internal set; }

        public ImplementsContainer Implements { get; internal set; } = new ImplementsContainer();

        public DocumentationContainer Documentation { get; } = new DocumentationContainer();

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
                GenericList
            };

            if (Inherits != null || Implements.SourceItems.Any())
            {
                builderList.Add(new ColonStatement());
            }

            if (Inherits != null)
            {
                builderList.Add(Inherits);

                if(Implements.SourceItems.Any())
                {
                    builderList.Add(new CommaStatement());
                }
            }

            builderList.Add(Implements);
            builderList.Add(ConstraintContainer);
            builderList.Add(new NewLineStatement());
            builderList.Add(new BraceStartStatement());

            _sourceItems.InsertRange(0, builderList);

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

        public ClassContainer WithInheritence(string baseClassName)
        {
            Inherits = new InheritenceStatement(baseClassName);

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
    }
}
