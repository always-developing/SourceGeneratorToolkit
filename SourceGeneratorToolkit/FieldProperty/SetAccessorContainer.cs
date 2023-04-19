using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class SetAccessorContainer : SourceContainer, IPublicModifier<SetAccessorContainer>, IPrivateModifier<SetAccessorContainer>,
        IInternalModifier<SetAccessorContainer>, IProtectedModifier<SetAccessorContainer>, IPrivateProtectedModifier<SetAccessorContainer>,
        IProtectedInternalModifier<SetAccessorContainer>
    {
        internal override string Name => nameof(SetAccessorContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

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
