using System.Collections.Generic;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a c# struct
    /// </summary>
    public class StructContainer : SourceContainer, IPublicModifier<StructContainer>, IPrivateModifier<StructContainer>,
        IInternalModifier<StructContainer>, IFileModifier<StructContainer>, IProtectedModifier<StructContainer>, IReadOnlyModifier<StructContainer>,
        ISupportsImplementation<StructContainer>, ISupportsComments<StructContainer>, ISupportsDocumentation<StructContainer>, ISupportsAttributes<StructContainer>,
        ISupportsGenerics<StructContainer>, ISupportsGenericsConstraints<StructContainer>, IPrivateProtectedModifier<StructContainer>, IPartialModifier<StructContainer>,
        IProtectedInternalModifier<StructContainer>, IUnsafeModifier<StructContainer>, ISupportsMethods<StructContainer>, ISupportsStatement<StructContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(StructContainer);

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        /// <inheritdoc/>
        public ImplementsContainer Implements { get; internal set; } = new ImplementsContainer();

        /// <inheritdoc/>
        public DocumentationContainer Documentation { get; } = new DocumentationContainer();

        /// <inheritdoc/>
        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        /// <inheritdoc/>
        public GenericList GenericList { get; } = new GenericList();

        /// <inheritdoc/>
        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        /// <summary>
        /// Constructor for the StructContainer class
        /// </summary>
        /// <param name="structName">The struct name</param>
        /// <param name="configuration">The build configuration to be used for the build</param>
        public StructContainer(string structName, BuilderConfiguration configuration)
        {
            SourceText = structName;
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
                new Statement($"struct {SourceText}"),
                GenericList,
                Implements,
                ConstraintContainer,
                new NewLineStatement(),
                new BraceStartStatement()
            };

            _sourceItems.InsertRange(0, builderList);

            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
        }
    }
}
