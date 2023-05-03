using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a get accessor
    /// </summary>
    public class GetAccessorContainer : SourceContainer, IPublicModifier<GetAccessorContainer>, IPrivateModifier<GetAccessorContainer>,
        IInternalModifier<GetAccessorContainer>, IProtectedModifier<GetAccessorContainer>, IPrivateProtectedModifier<GetAccessorContainer>,
        IProtectedInternalModifier<GetAccessorContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(GetAccessorContainer);

        /// <inheritdoc/>
        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        /// <inheritdoc/>
        public override string ToSource()
        {
            if (!SourceItems.Any())
            {
                _sourceItems.Add(AccessModifier);
                _sourceItems.Add(new Statement("get"));
                _sourceItems.Add(new SemiColonStatement());
            }

            return base.ToSource();
        }
    }
}
