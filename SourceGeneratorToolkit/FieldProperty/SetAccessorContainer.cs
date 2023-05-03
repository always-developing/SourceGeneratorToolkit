using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a set accessor
    /// </summary>
    public class SetAccessorContainer : SourceContainer, IPublicModifier<SetAccessorContainer>, IPrivateModifier<SetAccessorContainer>,
        IInternalModifier<SetAccessorContainer>, IProtectedModifier<SetAccessorContainer>, IPrivateProtectedModifier<SetAccessorContainer>,
        IProtectedInternalModifier<SetAccessorContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(SetAccessorContainer);

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public override string ToSource()
        {
            if(!_sourceItems.Any())
            {
                _sourceItems.Add(AccessModifier);
                _sourceItems.Add(new Statement("set"));
                _sourceItems.Add(new SemiColonStatement());
            }

            return base.ToSource();
        }
    }
}
