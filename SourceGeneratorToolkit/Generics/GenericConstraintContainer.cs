using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a generic constraint
    /// </summary>
    public class GenericConstraintContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(GenericConstraintContainer);

        /// <summary>
        /// Constructor for GenericConstraintContainer 
        /// </summary>
        /// <param name="genericKey">The generic constraint key</param>
        /// <param name="value">The generic constraint value</param>
        public GenericConstraintContainer(string genericKey, string value)
        {
            SourceText = genericKey;
            _sourceItems.Add(new GenericConstraintStatement(value));
            _sourceItems.Add(new CommaStatement());
        }

        /// <summary>
        /// Adds a constraint to the container
        /// </summary>
        /// <param name="value">The constraint value</param>
        public void AddConstraint(string value)
        {
            _sourceItems.Add(new GenericConstraintStatement(value));
            _sourceItems.Add(new CommaStatement());
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            if(SourceItems.Last().GetType() == typeof(CommaStatement)) 
            {
                _sourceItems.Remove(SourceItems.Last());
            }

            _sourceItems.Insert(0, new Statement($" where {SourceText} :"));

            return base.ToSource();
        }
    }
}
