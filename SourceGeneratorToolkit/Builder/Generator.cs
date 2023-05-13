using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a base generator
    /// </summary>
    public class Generator : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(Generator);

        /// <summary>
        /// Adds a file to the base generator
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="builder">The builder used to modify the properties of the file</param>
        /// <returns>The generator</returns>
        public Generator WithFile(string fileName, Action<FileContainer> builder)
        {
            var internalFile = new FileContainer(fileName);
            _sourceItems.Add(internalFile);

            builder.Invoke(internalFile);

            return this;
        }
    }
}
