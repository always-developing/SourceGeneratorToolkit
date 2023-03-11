using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ModifierContainer : SourceContainer
    {
        internal override string Name => nameof(ModifierContainer);

        public override string ToSource()
        {
            if(!SourceItems.Any())
            {
                return string.Empty;
            }

            base.OrderSourceItems();
            return base.ToSource();
        }

        public SourceStatement AddModifier(SourceStatement modifier)
        {
            _sourceItems.Add(modifier);

            return modifier;
        }
    }
}
