using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class GeneralModifierContainer : SourceContainer 
    {
        internal override string Name => nameof(GeneralModifierContainer);

        public override string ToSource()
        {
            if(!SourceItems.Any())
            {
                return string.Empty;
            }

            base.OrderSourceItems();
            return base.ToSource();
        }

        private T AddModifier<T>(T parent, SourceStatement modifier) where T : SourceContainer
        {
            _sourceItems.Add(modifier);

            return parent;
        }

        internal T AsAbstract<T>(T parent) where T : SourceContainer =>  this.AddModifier(parent, new AbstractModifierStatement());

        public T AsStatic<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new StaticModifierStatement());

        public T AsPartial<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new PartialModifierStatement());

        public T AsSealed<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new SealedModifierStatement());

        public T AsReadOnly<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new ReadOnlyModifierStatement());

        public T AsVirtual<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new VirtualModifierStatement());

        public T AsAsync<T>(T parent, bool enforceTaskReturnType) where T : SourceContainer => this.AddModifier(parent, new AsyncModifierStatement(enforceTaskReturnType));

        public T AsOverride<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new OverrideModifierStatement());

    }
}
