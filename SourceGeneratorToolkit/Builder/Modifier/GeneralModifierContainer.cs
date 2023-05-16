using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container which represents the (non-access) modifiers of a parent container
    /// </summary>
    public class GeneralModifierContainer : SourceContainer 
    {
        /// <inheritdoc/>
        internal override string Name => nameof(GeneralModifierContainer);

        /// <inheritdoc/>
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

        /// <summary>
        /// Removes all modifiers from the collection
        /// </summary>
        internal void ClearModifiers()
        {
            _sourceItems.Clear();
        }

        /// <summary>
        /// Marks the container as abstract
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsAbstract<T>(T parent) where T : SourceContainer =>  this.AddModifier(parent, new AbstractModifierStatement());

        /// <summary>
        /// Marks the container as static
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsStatic<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new StaticModifierStatement());

        /// <summary>
        /// Marks the container as partial
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsPartial<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new PartialModifierStatement());

        /// <summary>
        /// Marks the container as sealed
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsSealed<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new SealedModifierStatement());

        /// <summary>
        /// Marks the container as readonly
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsReadOnly<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new ReadOnlyModifierStatement());

        /// <summary>
        /// Marks the container as virtual
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsVirtual<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new VirtualModifierStatement());

        /// <summary>
        /// Marks the container as async
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <param name="enforceTaskReturnType">Flag to indicate if the return type should automatically be wrapped in 'Task'</param>
        /// <returns>The parent</returns>
        public T AsAsync<T>(T parent, bool enforceTaskReturnType) where T : SourceContainer => this.AddModifier(parent, new AsyncModifierStatement(enforceTaskReturnType));

        /// <summary>
        /// Marks the container as override
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsOverride<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new OverrideModifierStatement());

        /// <summary>
        /// Marks the container as unsafe
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsUnsafe<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new UnsafeModifierStatement());

        /// <summary>
        /// Marks the container as required
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsRequired<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new RequiredModifierStatement());

        /// <summary>
        /// Marks the container as out
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsOut<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new OutModifierStatement());

        /// <summary>
        /// Marks the container as ref
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsRef<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new RefModifierStatement());

        /// <summary>
        /// Marks the container as in
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">the parent container</param>
        /// <returns>The parent</returns>
        public T AsIn<T>(T parent) where T : SourceContainer => this.AddModifier(parent, new InModifierStatement());



    }
}
