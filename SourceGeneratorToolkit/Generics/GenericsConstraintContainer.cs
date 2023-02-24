using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit 
{
    internal class GenericsConstraintContainer : SourceContainer
    {
        internal override string Name => nameof(GenericsConstraintContainer);

        internal Dictionary<string, List<string>> _constraints = new Dictionary<string, List<string>>();

        internal void AddConstraint(string key)
        {
            if (!_constraints.ContainsKey(key))
            {
                _constraints.Add(key, new List<string>());
            }
        }
    }
}
