using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class GetAccessorContainer : SourceContainer, IPublicModifier<GetAccessorContainer>, IPrivateModifier<GetAccessorContainer>,
        IInternalModifier<GetAccessorContainer>, IProtectedModifier<GetAccessorContainer>, IPrivateProtectedModifier<GetAccessorContainer>
    {
        internal override string Name => nameof(GetAccessorContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

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
