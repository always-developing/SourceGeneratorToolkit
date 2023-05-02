using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the members of an enum
    /// </summary>
    public class EnumMemberList : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(EnumMemberList);

        /// <summary>
        /// Adds a member to the enum
        /// </summary>
        /// <param name="name">The member name</param>
        /// <returns>The enum member container</returns>
        public EnumMemberContainer AddEnumMember(string name)
        {
            var memberContainer = new EnumMemberContainer(name);

            if(_sourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(memberContainer);

            return memberContainer;
        }

        /// <summary>
        /// Adds a member to the enum with a specific value
        /// </summary>
        /// <param name="name">The enum name</param>
        /// <param name="value">The enum value</param>
        /// <returns>The enum member container</returns>
        public EnumMemberContainer AddEnumMember(string name, string value)
        {
            var memberContainer = new EnumMemberContainer(name, value);

            if (_sourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }

            _sourceItems.Add(memberContainer);

            return memberContainer;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return base.ToSource();
        }
    }
}
