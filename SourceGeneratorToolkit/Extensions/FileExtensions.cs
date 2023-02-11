using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class FileExtensions
    {
        public static GeneratorConfiguration WithFile(this GeneratorConfiguration generator, Action<FileContainer> contents)
        {
            var file = new FileContainer();
            generator.SourceItems.Add(file);

            contents.Invoke(file);

            return generator;
        }

        public static GeneratorConfiguration WithFile(this GeneratorConfiguration generator, string fileName, Action<FileContainer> contents)
        {
            var file = new FileContainer(fileName);
            generator.SourceItems.Add(file);

            contents.Invoke(file);

            return generator;
        }
    }
}
