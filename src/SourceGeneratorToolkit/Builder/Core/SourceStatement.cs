using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// An abstract statment which represents a single C# language keyword/statement
    /// </summary>
    public abstract class SourceStatement
    {
        /// <summary>
        /// The name of the source statement
        /// </summary>
        internal abstract string Name { get; }

        /// <summary>
        /// The order of the statement if in a collection
        /// </summary>
        internal int Order { get; set; } = 0;

        /// <summary>
        /// The source code text representation of the statement
        /// </summary>
        internal string SourceText { get; set; }

        /// <summary>
        /// The specific configuration for this build
        /// </summary>
        internal BuilderConfiguration Configuration { get; set; }

        /// <summary>
        /// Convert the container (represented by a list of statements) or statement into C# source code
        /// </summary>
        /// <returns>A string representing the source code</returns>
        public virtual string ToSource()
        {
            return SourceText;
        }

        /// <summary>
        /// Convert the container (represented by a list of statements) or statement into a visual tree hierarchy
        /// </summary>
        /// <param name="treeLevel"></param>
        /// <returns>A string representing the hierarchy of statements</returns>
        public virtual string ToTree(int treeLevel)
        {
            var sb = new StringBuilder();

            sb.Append($"{TreePrefix(treeLevel)}{this.GetType().Name}");

            return sb.ToString();
        }

        /// <summary>
        /// What is the prefix to use when ouputting the heirarchy
        /// </summary>
        /// <param name="treeLevel">The tree level</param>
        /// <returns>The tree prefix for the specific level</returns>
        protected string TreePrefix(int treeLevel)
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 2 ; i<= treeLevel; i++) 
            {
                sb.Append(" ");
            }

            sb.Append("|-");

            return sb.ToString();
        }
    }
}
