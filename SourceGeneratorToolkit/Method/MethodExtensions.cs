using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class MethodExtensions
    {
        public static T WithMethod<T>(this ISupportsMethods<T> @base, string methodName, string returnType) where T : SourceContainer
        {
            ((SourceContainer)@base)._sourceItems.Add(new MethodContainer(methodName, returnType));

            return (T)@base;
        }

        public static T WithMethod<T>(this ISupportsMethods<T> @base, string methodName, Type returnType) where T : SourceContainer
        {
            ((SourceContainer)@base)._sourceItems.Add(new MethodContainer(methodName, returnType));

            return (T)@base;
        }

        public static T WithMethod<T>(this ISupportsMethods<T> @base, string methodName, string returnType, Action<MethodContainer> builder) where T : SourceContainer
        {
            var container = new MethodContainer(methodName, returnType);
            ((SourceContainer)@base)._sourceItems.Add(container);

            builder.Invoke(container);

            return (T)@base;
        }

        public static T WithMethod<T>(this ISupportsMethods<T> @base, string methodName, Type returnType, Action<MethodContainer> builder) where T : SourceContainer
        {
            var container = new MethodContainer(methodName, returnType);
            ((SourceContainer)@base)._sourceItems.Add(container);

            builder.Invoke(container);

            return (T)@base;
        }
    }
}
