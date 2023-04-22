using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class UsingContainer : SourceContainer, IStaticModifier<UsingContainer>
    {
        internal override string Name => nameof(UsingContainer);

        public GeneralModifierContainer GeneralModifiers { get; } = new GeneralModifierContainer();

        internal bool _isGlobal = false;

        public UsingContainer(string @using)
        {
            SourceText = @using;
        }

        public override string ToSource()
        {
            if(_isGlobal)
            {
                _sourceItems.Add(new Statement("global "));
            }
            _sourceItems.Add(new Statement("using "));
            _sourceItems.Add(GeneralModifiers);
            _sourceItems.Add(new Statement(SourceText));
            _sourceItems.Add(new SemiColonStatement());

            return base.ToSource();
        }

        public UsingContainer AsGlobal()
        {
            _isGlobal = true;
            return this;
        }
    }
}
