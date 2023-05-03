using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing an init accessor
    /// </summary>
    public class InitAccessorContainer : SourceContainer, IPublicModifier<InitAccessorContainer>, IPrivateModifier<InitAccessorContainer>,
        IInternalModifier<InitAccessorContainer>, IProtectedModifier<InitAccessorContainer>, IPrivateProtectedModifier<InitAccessorContainer>,
        IProtectedInternalModifier<InitAccessorContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(InitAccessorContainer);

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public override string ToSource()
        {
            if (!_sourceItems.Any())
            {
                _sourceItems.Add(AccessModifier);
                _sourceItems.Add(new Statement("init"));
                _sourceItems.Add(new SemiColonStatement());
            }

            return base.ToSource();
        }
    }
}
