using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class RecordContainer : SourceContainer, IPublicModifier<RecordContainer>, IProtectedModifier<RecordContainer>, IPrivateModifier<RecordContainer>,
        IInternalModifier<RecordContainer>, IFileModifier<RecordContainer>, IProtectedInternalModifier<RecordContainer>,
        IPartialModifier<RecordContainer>, IAbstractModifier<RecordContainer>, IUnsafeModifier<RecordContainer>,
        ISupportsGenerics<RecordContainer>, ISupportsGenericsConstraints<RecordContainer>, ISupportsAttributes<RecordContainer>,
        ISupportsDocumentation<RecordContainer>, ISupportsImplementation<RecordContainer>, ISupportsInheritence<RecordContainer>,
        ISupportsProperty<RecordContainer>, IPrivateProtectedModifier<RecordContainer>
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

        public PositionalParameterContainer PositionalParameters = new PositionalParameterContainer();

        public PropertyList Properties { get; } = new PropertyList();

        private string recordType = "";

        public RecordContainer(string recordName)
        {
            SourceText = recordName;
        }

        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                Documentation,
                AttributeList,
                AccessModifier,
                GeneralModifiers,
                new Statement($"record {recordType}{SourceText}"),
                GenericList
            };

            if (PositionalParameters.SourceItems.Any() || !HasBody())
            {
                builderList.Add(new ParenthesisStartStatement());
                builderList.Add(PositionalParameters);
                builderList.Add(new ParenthesisEndStatement());
            }

            builderList.Add(ConstraintContainer);
            builderList.Add(Implements);

            _sourceItems.InsertRange(0, builderList);

            if (!HasBody())
            {
                _sourceItems.Add(new SemiColonStatement());
                return base.ToSource();
            }

            _sourceItems.Add(new BraceStartStatement());
            _sourceItems.Add(Properties);
            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
        }

        public RecordContainer AddPositionalParameter(string type, string name)
        {
            PositionalParameters.AddParameter(type, name);

            return this;
        }

        public RecordContainer AsStruct()
        {
            recordType = "struct ";
            return this;
        }

        public RecordContainer AsClass()
        {
            recordType = "class ";
            return this;
        }

        private bool HasBody()
        {
            return Properties.SourceItems.Any();
        }
    }
}
