using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FieldContainer : SourceContainer, IPublicModifier<FieldContainer>, IPrivateModifier<FieldContainer>, IProtectedModifier<FieldContainer>,
        IInternalModifier<FieldContainer>, IReadOnlyModifier<FieldContainer>, IStaticModifier<FieldContainer>
    {
        internal override string Name => nameof(FieldContainer);

        public AccessModifierContainer AccessModifier { get; } = new AccessModifierContainer();

        public ModifierContainer GeneralModifier { get; } = new ModifierContainer();

        internal string _defaultValue = null;

        public FieldContainer(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        public override string ToSource()
        {
            _sourceItems.Add(AccessModifier);
            _sourceItems.Add(GeneralModifier);
            _sourceItems.Add(new Statement(SourceText));

            if(_defaultValue != null)
            {
                _sourceItems.Add(new EqualsStatement());
                _sourceItems.Add(new Statement(_defaultValue));
            }

            _sourceItems.Add(new SemiColonStatement());
            _sourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }

        public FieldContainer WithValue(string value)
        {
            _defaultValue = value;
            return this;
        }
    }
}
