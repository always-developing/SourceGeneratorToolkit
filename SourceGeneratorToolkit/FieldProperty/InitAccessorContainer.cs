using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class InitAccessorContainer : SourceContainer, IPublicModifier<InitAccessorContainer>, IPrivateModifier<InitAccessorContainer>,
        IInternalModifier<InitAccessorContainer>, IProtectedModifier<InitAccessorContainer>, IPrivateProtectedModifier<InitAccessorContainer>
    {
        internal override string Name => nameof(InitAccessorContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

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
