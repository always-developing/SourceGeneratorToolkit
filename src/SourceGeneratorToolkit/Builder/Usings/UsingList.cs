using System;
using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Contains a list of "using" statements 
    /// </summary>
    public class UsingList : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(UsingList);

        /// <summary>
        /// Adds a "using" statement
        /// </summary>
        /// <param name="using">The namespace to include in the "using" statement</param>
        /// <param name="builder">The builder used to modify the properties of the "using" statement</param>
        /// <returns>The using container created</returns>
        public UsingContainer AddUsing(string @using, Action<UsingContainer> builder = null)
        {
            var usingContainer = new UsingContainer(@using);
            _sourceItems.Add(usingContainer);

            builder?.Invoke(usingContainer);

            return usingContainer;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            _sourceItems = _sourceItems
                .Select(s => s as UsingContainer)
                .ToList()
                .OrderByDescending(s => s._isGlobal)
                .ThenBy(s => s.SourceText)
                .Select(s => s as SourceStatement)
                .ToList();

            return base.ToSource();
        }
    }
}
