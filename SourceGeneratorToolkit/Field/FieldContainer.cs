using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FieldContainer : SourceContainer
    {
        internal override string Name => nameof(FieldContainer);

        internal AccessModifierStatement _accessModifier;

        internal ModifierContainer _generalModifiers = new ModifierContainer();

        internal string _defaultValue = null;

        public FieldContainer(string type, string name)
        {
            SourceText = $"{type} {name}";
        }

        public override string ToSource()
        {
            if(_accessModifier != null)
            {
                SourceItems.Add(_accessModifier);
            }

            SourceItems.Add(_generalModifiers);
            SourceItems.Add(new Statement(SourceText));

            if(_defaultValue != null)
            {
                SourceItems.Add(new EqualsStatement());
                SourceItems.Add(new Statement(_defaultValue));
            }

            SourceItems.Add(new SemiColonStatement());
            SourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }

        public FieldContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement();
            return this;
        }

        public FieldContainer AsPrivate()
        {
            _accessModifier = new PrivateModifierStatement();
            return this;
        }

        public FieldContainer AsProtected()
        {
            _accessModifier = new ProtectedModifierStatement();
            return this;
        }

        public FieldContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }

        public FieldContainer WithValue(string value)
        {
            _defaultValue = value;
            return this;
        }

        public FieldContainer AsReadOnnly()
        {
            _generalModifiers.SourceItems.Add(new ReadOnlyModifierStatement());
            return this;
        }

        public FieldContainer AsStatic()
        {
            _generalModifiers.SourceItems.Add(new StaticModifierStatement());
            return this;
        }
    }
}
