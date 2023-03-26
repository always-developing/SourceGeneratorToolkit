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

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        public string DefaultValue  {get; internal set;}

        public FieldContainer(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        public override string ToSource()
        {
            _sourceItems.Add(AccessModifier);
            _sourceItems.Add(GeneralModifiers);
            _sourceItems.Add(new Statement(SourceText));

            if(DefaultValue != null)
            {
                _sourceItems.Add(new EqualsStatement());
                _sourceItems.Add(new Statement(DefaultValue));
            }

            _sourceItems.Add(new SemiColonStatement());
            _sourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }

        public FieldContainer WithDefaultValue(string value)
        {
            DefaultValue = value;
            return this;
        }
    }
}
