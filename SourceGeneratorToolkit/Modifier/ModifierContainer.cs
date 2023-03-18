using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ModifierContainer<ParentContainer> : SourceContainer where ParentContainer : SourceContainer
    {
        internal override string Name => nameof(ModifierContainer<ParentContainer>);

        private readonly ParentContainer _parentContainer;

        public ModifierContainer(ParentContainer parentContainer)
        {
            _parentContainer = parentContainer;
        }

        public override string ToSource()
        {
            if(!SourceItems.Any())
            {
                return string.Empty;
            }

            base.OrderSourceItems();
            return base.ToSource();
        }

        private ParentContainer AddModifier(SourceStatement modifier)
        {
            _sourceItems.Add(modifier);

            return _parentContainer;
        }

        public ParentContainer AsAbstract() =>  this.AddModifier(new AbstractModifierStatement());

        public ParentContainer AsStatic() => this.AddModifier(new StaticModifierStatement());

        public ParentContainer AsPartial() => this.AddModifier(new PartialModifierStatement());

        public ParentContainer AsSealed() => this.AddModifier(new SealedModifierStatement());

        public ParentContainer AsReadOnly() => this.AddModifier(new ReadOnlyModifierStatement());

        public ParentContainer AsVirtual() => this.AddModifier(new VirtualModifierStatement());

        public ParentContainer AsAsync(bool enforceTaskReturnType) => this.AddModifier(new AsyncModifierStatement(enforceTaskReturnType));

        public ParentContainer AsOverride() => this.AddModifier(new OverrideModifierStatement());

    }
}
