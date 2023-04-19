using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class StructContainer : SourceContainer, IPublicModifier<StructContainer>, IPrivateModifier<StructContainer>,
        IInternalModifier<StructContainer>, IFileModifier<StructContainer>, IProtectedModifier<StructContainer>, IReadOnlyModifier<StructContainer>,
        ISupportsImplementation<StructContainer>, ISupportsComments<StructContainer>, ISupportsDocumentation<StructContainer>, ISupportsAttributes<StructContainer>,
        ISupportsGenerics<StructContainer>, ISupportsGenericsConstraints<StructContainer>, IPrivateProtectedModifier<StructContainer>, IPartialModifier<StructContainer>,
        IProtectedInternalModifier<StructContainer>, IUnsafeModifier<StructContainer>
    {
        internal override string Name => nameof(StructContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public ImplementsContainer Implements { get; internal set; } = new ImplementsContainer();

        public DocumentationContainer Documentation { get; } = new DocumentationContainer();

        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        public GenericList GenericList { get; } = new GenericList();

        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        public StructContainer(string structName)
        {
            SourceText = structName;
        }

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
