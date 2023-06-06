using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// All valid entity types an attribute can be applied to
    /// </summary>
    [Flags]
    public enum AttributeTarget
    {
        /// <summary>
        ///The attribute can be applied to an assembly
        /// </summary>
        Assembly,
        /// <summary>
        ///The attribute can be applied to a module
        /// </summary>
        Module,
        /// <summary>
        ///The attribute can be applied to a field
        /// </summary>
        Field,
        /// <summary>
        ///The attribute can be applied to an event
        /// </summary>
        Event,
        /// <summary>
        ///The attribute can be applied to a method
        /// </summary>
        Method,
        /// <summary>
        ///The attribute can be applied to a parameter
        /// </summary>
        Param,
        /// <summary>
        ///The attribute can be applied to a property
        /// </summary>
        Property,
        /// <summary>
        ///The attribute can be applied to a return statement
        /// </summary>
        Return,
        /// <summary>
        ///The attribute can be applied to a type
        /// </summary>
        Type
    }
}
