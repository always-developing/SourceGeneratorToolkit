using System.Collections.Generic;
using System.Linq;

namespace SourceGeneratorToolkit
{

    /// <summary>
    /// A container representing a c# record
    /// </summary>
    public class RecordContainer : SourceContainer, IPublicModifier<RecordContainer>, IProtectedModifier<RecordContainer>, IPrivateModifier<RecordContainer>,
        IInternalModifier<RecordContainer>, IFileModifier<RecordContainer>, IProtectedInternalModifier<RecordContainer>,
        IPartialModifier<RecordContainer>, IAbstractModifier<RecordContainer>, IUnsafeModifier<RecordContainer>,
        ISupportsGenerics<RecordContainer>, ISupportsGenericsConstraints<RecordContainer>, ISupportsAttributes<RecordContainer>,
        ISupportsDocumentation<RecordContainer>, ISupportsImplementation<RecordContainer>, ISupportsInheritence<RecordContainer>,
        ISupportsProperty<RecordContainer>, IPrivateProtectedModifier<RecordContainer>, ISealedModifier<RecordContainer>,
        ISupportsStatement<RecordContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(RecordContainer);

        /// <inheritdoc/>
        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public GenericList GenericList { get; } = new GenericList();

        /// <inheritdoc/>
        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        public GenericConstraintList ConstraintContainer { get; } = new GenericConstraintList();

        /// <inheritdoc/>
        public ImplementsContainer Implements { get; internal set; } = new ImplementsContainer();

        public DocumentationContainer Documentation { get; } = new DocumentationContainer();

        /// <inheritdoc/>
        public InheritenceContainer Inherits { get; } = new InheritenceContainer();

        /// <inheritdoc/>
        public PositionalParameterContainer PositionalParameters = new PositionalParameterContainer();

        /// <inheritdoc/>
        public PropertyList Properties { get; } = new PropertyList();

        /// <summary>
        ///  Stored if the record is class or struct
        /// </summary>
        private string _recordType = "";

        /// <summary>
        /// Constructor for RecordContainer class
        /// </summary>
        /// <param name="recordName">The record name</param>
        public RecordContainer(string recordName)
        {
            SourceText = recordName;
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
                new Statement($"record {_recordType}{SourceText}"),
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

        /// <summary>
        /// Adds a positional parameter to the record
        /// </summary>
        /// <param name="type">The parameter type</param>
        /// <param name="name">The parameter name</param>
        /// <returns>The record container</returns>
        public RecordContainer AddPositionalParameter(string type, string name)
        {
            PositionalParameters.AddParameter(type, name);

            return this;
        }

        /// <summary>
        /// Flags the record as a struct
        /// </summary>
        /// <returns>The record container</returns>
        public RecordContainer AsStruct()
        {
            _recordType = "struct ";
            return this;
        }

        /// <summary>
        /// Flags the record as a class
        /// </summary>
        /// <returns>The record container</returns>
        public RecordContainer AsClass()
        {
            _recordType = "class ";
            return this;
        }

        private bool HasBody()
        {
            return Properties.SourceItems.Any();
        }
    }
}
