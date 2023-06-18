using System.Collections.Generic;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a c# enum
    /// </summary>
    public class EnumContainer : SourceContainer, ISupportsDocumentation<EnumContainer>, ISupportsAttributes<EnumContainer>, 
        IPublicModifier<EnumContainer>
    {
        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public DocumentationContainer Documentation { get; } = new DocumentationContainer();

        /// <inheritdoc/>
        public EnumMemberList EnumMembers { get; } = new EnumMemberList();

        /// <inheritdoc/>
        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        /// <inheritdoc/>

        public EnumTypeStatement EnumType { get; private set; }

        /// <inheritdoc/>
        internal override string Name => nameof(EnumContainer);

        /// <summary>
        /// Constructor for the EnumContainer class
        /// </summary>
        /// <param name="enumName">The enum name</param>
        /// <param name="configuration">The build configuration settings</param>
        public EnumContainer(string enumName, BuilderConfiguration configuration)
        {
            SourceText = enumName;
            Configuration = configuration;
        }

        /// <summary>
        /// Constructor for the EnumContainer class
        /// </summary>
        /// <param name="enumName">The enum name</param>
        /// <param name="type">The enum type</param>
        /// <param name="configuration">The build configuration settings</param>
        public EnumContainer(string enumName, string type, BuilderConfiguration configuration)
        {
            SourceText = enumName;
            EnumType = new EnumTypeStatement(type);
            Configuration = configuration;
        }

        /// <summary>
        /// Adds a member to the enum
        /// </summary>
        /// <param name="name">The member name</param>
        /// <returns>The enum container</returns>
        public EnumContainer AddMember(string name)
        {
            EnumMembers.AddEnumMember(name);
            return this;
        }

        /// <summary>
        /// Adds a member with a value to the enum
        /// </summary>
        /// <param name="name">The member name</param>
        /// <param name="value">The member value</param>
        /// <returns>The enum container</returns>
        public EnumContainer AddMember(string name, string value)
        {
            EnumMembers.AddEnumMember(name, value);
            return this;
        }

        /// <summary>
        /// Specifies the type of the enum
        /// </summary>
        /// <param name="type">The enum type</param>
        /// <returns></returns>
        public EnumContainer OfType(string type)
        {
            EnumType = new EnumTypeStatement(type);

            return this;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                Documentation,
                AttributeList,
                AccessModifier,
                new Statement($"enum {SourceText}"),
            };

            if(EnumType != null)
            {
                builderList.Add(EnumType);
            }

            builderList.Add(new NewLineStatement());
            builderList.Add(new BraceStartStatement());

            _sourceItems.InsertRange(0, builderList);

            _sourceItems.Add(EnumMembers);

            _sourceItems.Add(new BraceEndStatement());

            return base.ToSource();
        }
    }
}
