using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class RecordContainer : SourceContainer, IPublicModifier<RecordContainer>, IProtectedModifier<RecordContainer>, IPrivateModifier<RecordContainer>,
        IInternalModifier<RecordContainer>, IFileModifier<RecordContainer>, IProtectedInternalModifier<RecordContainer>,
        IPartialModifier<RecordContainer>, IAbstractModifier<RecordContainer>, IUnsafeModifier<RecordContainer>,
        ISupportsGenerics<RecordContainer>, ISupportsGenericsConstraints<RecordContainer>, ISupportsAttributes<RecordContainer>,
        ISupportsDocumentation<RecordContainer>, ISupportsImplementation<RecordContainer>, ISupportsInheritence<ClassContainer>
    {
        internal override string Name => nameof(RecordContainer);

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public GenericList GenericList { get; } = new GenericList();

        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        public ImplementsContainer Implements { get; internal set; } = new ImplementsContainer();

        public DocumentationContainer Documentation { get; } = new DocumentationContainer();

        public InheritenceContainer Inherits { get; } = new InheritenceContainer();

        public RecordContainer(string recordName)
        {
            SourceText = recordName;
        }
    }
}
