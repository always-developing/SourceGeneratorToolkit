using System;

namespace SourceGeneratorToolkit.Extensions
{
    public static class MethodExtensions
    {
        public static ClassContainer WithMethod(this ClassContainer container, string methodName, Action<MethodContainer> content)
        {
            MethodContainer ebmContainer = new MethodContainer(methodName, 1);
            container.SourceItems.Add(ebmContainer);

            content.Invoke(ebmContainer);

            return container;
        }

        public static MethodContainer WithReturnType(this MethodContainer container, string returnType)
        {
            var returnStatement = new MethodReturnStatement(returnType);
            container.WithReturnType(returnStatement);

            return container;
        }

        public static MethodContainer WithParameter(this MethodContainer container, string type, string name)
        {
            var parameterStatement = new MethodParameterStatement(type, name);
            container.Parameters.Add(parameterStatement);

            return container;
        }

        public static MethodContainer WithBody(this MethodContainer container, string bodyContent)
        {
            var methodBody = new MethodBodyStatement(bodyContent);
            container.SourceItems.Add(methodBody);

            return container;
        }

        public static MethodContainer WithExpressionBody(this MethodContainer container, string bodyContent)
        {
            var methodBody = new MethodBodyStatement(bodyContent);
            var lambdaStart = new LambdaStatement();

            container.PostStatements.Add(lambdaStart);
            container.SourceItems.Add(methodBody);

            return container;
        }
    }
}
