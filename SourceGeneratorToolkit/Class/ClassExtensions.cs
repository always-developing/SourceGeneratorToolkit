using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensiosn for class type entities (classes, records, structs)
    /// </summary>
    public static class ClassExtensions
    {

        /// <summary>
        /// Adds a class to the container
        /// </summary>
        /// <typeparam name="TContainer">The parent container</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="className">The name of the class</param>
        /// <param name="builder">The builder used to modify the properties of the class</param>
        /// <returns>The parent container</returns>
        public static TContainer WithClass<TContainer>(this ISupportsClasses<TContainer> @base, string className, Action<ClassContainer> builder) where TContainer : SourceContainer
        {
            var classContainer = new ClassContainer(className);

            ((SourceContainer)@base)._sourceItems.Add(classContainer);
            builder.Invoke(classContainer);

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a struct to the container
        /// </summary>
        /// <typeparam name="TContainer">The parent container</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="structName">The name of the struct</param>
        /// <param name="builder">The builder used to modify the properties of the struct</param>
        /// <returns>The parent container</returns>
        public static TContainer WithStruct<TContainer>(this ISupportsStructs<TContainer> @base, string structName, Action<StructContainer> builder) where TContainer : SourceContainer
        {
            var structContainer = new StructContainer(structName);

            ((SourceContainer)@base)._sourceItems.Add(structContainer);
            builder.Invoke(structContainer);

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a record to the namespace
        /// </summary>
        /// <typeparam name="TContainer">The parent container</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="recordName">The name of the record</param>
        /// <param name="builder">The builder used to modify the properties of the record</param>
        /// <returns>The parent container</returns>
        public static TContainer WithRecord<TContainer>(this ISupportsRecords<TContainer> @base, string recordName, Action<RecordContainer> builder) where TContainer : SourceContainer
        {
            var recordContainer = new RecordContainer(recordName);

            ((SourceContainer)@base)._sourceItems.Add(recordContainer);
            builder.Invoke(recordContainer);

            return (TContainer)@base;
        }
    }
}
