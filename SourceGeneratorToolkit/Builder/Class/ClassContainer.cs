using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a c# class
    /// </summary>
    public class ClassContainer : SourceContainer, IStaticModifier<ClassContainer>, IAbstractModifier<ClassContainer>, IPartialModifier<ClassContainer>,
        ISealedModifier<ClassContainer>, IPublicModifier<ClassContainer>, IPrivateModifier<ClassContainer>,
        IInternalModifier<ClassContainer>, IFileModifier<ClassContainer>, IProtectedModifier<ClassContainer>, IUnsafeModifier<ClassContainer>,
        ISupportsGenerics<ClassContainer>, ISupportsGenericsConstraints<ClassContainer>, ISupportsAttributes<ClassContainer>,
        ISupportsComments<ClassContainer>, ISupportsDocumentation<ClassContainer>, ISupportsImplementation<ClassContainer>,
        ISupportsInheritence<ClassContainer>, ISupportsProperty<ClassContainer>, ISupportsField<ClassContainer>, IPrivateProtectedModifier<ClassContainer>,
        IProtectedInternalModifier<ClassContainer>, ISupportsMethods<ClassContainer>, ISupportsStatement<ClassContainer>,
        ISupportsClasses<ClassContainer>, ISupportsRecords<ClassContainer>, ISupportsStructs<ClassContainer>, ISupportsInterfaces<ClassContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ClassContainer);

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public GenericList GenericList { get; } = new GenericList();

        /// <inheritdoc/>
        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        /// <inheritdoc/>
        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        /// <inheritdoc/>
        public InheritenceContainer Inherits { get; } = new InheritenceContainer();

        /// <inheritdoc/>
        public ImplementsContainer Implements { get; } = new ImplementsContainer();

        /// <inheritdoc/>
        public DocumentationContainer Documentation { get; } = new DocumentationContainer();

        /// <inheritdoc/>
        public PropertyList Properties { get; } = new PropertyList();

        /// <inheritdoc/>
        public FieldList Fields { get; } = new FieldList();

        /// <summary>
        /// Contructor for the class container
        /// </summary>
        /// <param name="className">The class name</param>
        /// <param name="configuration">The build configuration to be used for the build</param>
        public ClassContainer(string className, BuilderConfiguration configuration)
        {
            SourceText = className;
            Configuration = configuration;
        }

        /// <inheritdoc/>
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

        /// <summary>
        /// Adds an empty constructor to the class 
        /// </summary>
        /// <returns>The class container</returns>
        public ClassContainer WithConstructor()
        {
            _sourceItems.Add(new ConstructorContainer(SourceText));

            return this;
        }

        /// <summary>
        /// Adds a conttructor to the class
        /// </summary>
        /// <param name="builder">The builder used to modify the properties of the class constructor</param>
        /// <returns>The class container</returns>
        public ClassContainer WithConstructor(Action<ConstructorContainer> builder)
        {
            var constructor = new ConstructorContainer(SourceText);
            _sourceItems.Add(constructor);

            builder.Invoke(constructor);

            return this;
        }
        
    }
}
