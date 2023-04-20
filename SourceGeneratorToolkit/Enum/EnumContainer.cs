using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class EnumContainer : SourceContainer, ISupportsDocumentation<EnumContainer>, ISupportsAttributes<EnumContainer>, 
        IPublicModifier<EnumContainer>
    {
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public DocumentationContainer Documentation { get; } = new DocumentationContainer();

        public EnumMemberList EnumMembers { get; } = new EnumMemberList();

        public AttributeContainer AttributeList { get; } = new AttributeContainer();

        public EnumTypeStatement EnumType { get; private set; }

        internal override string Name => nameof(EnumContainer);

        public EnumContainer(string enumName)
        {
            SourceText = enumName;
        }

        public EnumContainer(string enumName, string type)
        {
            SourceText = enumName;
            EnumType = new EnumTypeStatement(type);
        }

        public EnumContainer AddMember(string name)
        {
            EnumMembers.AddEnumMember(name);
            return this;
        }

        public EnumContainer AddMember(string name, string value)
        {
            EnumMembers.AddEnumMember(name, value);
            return this;
        }

        public EnumContainer OfType(string type)
        {
            EnumType = new EnumTypeStatement(type);

            return this;
        }

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
