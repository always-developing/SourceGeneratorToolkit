﻿namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the virtual keyword
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IVirtualModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
