using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container which represents the generic contraints applied to a container
    /// </summary>
    public class GenericConstraintList : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(GenericConstraintList);

        /// <summary>
        /// Adds a generic constraint to the container
        /// </summary>
        /// <param name="genericKey">The generic value the contstraint is applied to</param>
        /// <param name="constraint">The constraint type</param>
        public void AddConstraint(string genericKey, string constraint)
        {
            var match = SourceItems.FirstOrDefault(g => g.SourceText == genericKey);

            if(match != null && match is GenericConstraintContainer container) 
            {
                container.AddConstraint(constraint);

                return;
            }

            _sourceItems.Add(new GenericConstraintContainer(genericKey, constraint));
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            if(!SourceItems.Any())
            {
                return "";
            }

            return base.ToSource();
        }
    }
}
