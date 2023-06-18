using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static configuration for the Source Genrator toolkit
    /// </summary>
    public class BuilderConfiguration
    {
        /// <summary>
        ///  Flag to indicate if the GeneratedCodeAttribute should be output on generated code
        ///  Default is true
        /// </summary>
        public bool OutputGeneratedCodeAttribute { get; set; } = true;

        /// <summary>
        /// Flag to indicate if the DebuggerStepThroughAttribute should be output on generated code
        ///  Default is false
        /// </summary>
        public bool OutputDebuggerStepThroughAttribute { get; set; } = false;
    }
}
