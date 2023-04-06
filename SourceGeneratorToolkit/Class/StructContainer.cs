using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class StructContainer : SourceContainer, IPublicModifier<StructContainer>, IPrivateModifier<StructContainer>,
        IInternalModifier<StructContainer>, IFileModifier<StructContainer>, IProtectedModifier<StructContainer>, IReadOnlyModifier<StructContainer>,
        ISupportsImplementation<StructContainer>, ISupportsComments<ClassContainer>, ISupportsDocumentation<ClassContainer>, ISupportsAttributes<ClassContainer>,
        ISupportsGenerics<StructContainer>, ISupportsGenericsConstraints<StructContainer>
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
                GenericList
            };

            builderList.Add(Implements);
            builderList.Add(ConstraintContainer);
            builderList.Add(new NewLineStatement());
            builderList.Add(new BraceStartStatement());

            _sourceItems.InsertRange(0, builderList);

            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
        }
    }
}
