namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container which represents the access modifiers of a parent container
    /// </summary>
    public class AccessModifierContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(AccessModifierContainer);

        /// <summary>
        /// Marks the container as public
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">The parent container</param>
        /// <returns>The parent</returns>
        internal T AsPublic<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new PublicModifierStatement());

            return parent;
        }

        /// <summary>
        /// Marks the container as private
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">The parent container</param>
        /// <returns>The parent</returns>
        internal T AsPrivate<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new PrivateModifierStatement());

            return parent;
        }

        /// <summary>
        /// Marks the container as protected
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">The parent container</param>
        /// <returns>The parent</returns>
        internal T AsProtected<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new ProtectedModifierStatement());

            return parent;
        }

        /// <summary>
        /// Marks the container as internal
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">The parent container</param>
        /// <returns>The parent</returns>
        internal T AsInternal<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new InternalModifierStatement());

            return parent;
        }

        /// <summary>
        /// Marks the container as file scoped
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">The parent container</param>
        /// <returns>The parent</returns>
        internal T AsFile<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new FileModifierStatement());

            return parent;
        }

        /// <summary>
        /// Marks the container as protected internal
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">The parent container</param>
        /// <returns>The parent</returns>
        internal T AsProtectedInternal<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new ProtectedInternalModifierStatement());

            return parent;
        }

        /// <summary>
        /// Marks the container as private protected
        /// </summary>
        /// <typeparam name="T">The parent type</typeparam>
        /// <param name="parent">The parent container</param>
        /// <returns>The parent</returns>
        internal T AsPrivateProtected<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new PrivateProtectedStatement());

            return parent;
        }
    }
}
