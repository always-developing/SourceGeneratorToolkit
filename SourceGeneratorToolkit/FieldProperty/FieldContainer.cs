using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FieldContainer : SourceContainer, IPublicModifier<FieldContainer>, IPrivateModifier<FieldContainer>, IProtectedModifier<FieldContainer>,
        IInternalModifier<FieldContainer>, IReadOnlyModifier<FieldContainer>, IStaticModifier<FieldContainer>, ISupportsDefaultValue<FieldContainer>
    {
        internal override string Name => nameof(FieldContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public DefaultValueContainer DefaultValue { get; internal set; } = new DefaultValueContainer();

        public FieldContainer(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        public override string ToSource()
        {
            _sourceItems.Add(AccessModifier);
            _sourceItems.Add(GeneralModifiers);
            _sourceItems.Add(new Statement(SourceText));
            _sourceItems.Add(DefaultValue);
            _sourceItems.Add(new SemiColonStatement());
            _sourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }
    }
}
