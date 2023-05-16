using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the container supports the in keyword
    /// </summary>
    /// <typeparam name="TContainer">The parent container type</typeparam>
    public interface IInModifier<TContainer> where TContainer : SourceContainer
    {
        /// <inheritdoc/>
        GeneralModifierContainer GeneralModifiers { get; }
    }
}
