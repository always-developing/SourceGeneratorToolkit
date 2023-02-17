using SourceGeneratorToolkit;
using System;

namespace SourceGeneratorToolkit
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
            container.Parameters.SourceItems.Add(parameterStatement);

            return container;
        }

        public static MethodContainer WithBody(this MethodContainer container, string bodyContent)
        {
            var methodBody = new MethodBodyStatement(bodyContent);

            container.SourceItems.Add(new BraceStartStatement());
            container.SourceItems.Add(methodBody);
            container.SourceItems.Add(new EmptyLineStatement
            {
                Order = int.MaxValue - 1
            });
            container.SourceItems.Add(new BraceEndStatement());

            return container;
        }

        public static MethodContainer WithExpressionBody(this MethodContainer container, string bodyContent)
        {
            var methodBody = new MethodBodyStatement(bodyContent);
            var lambdaStart = new LambdaStatement();
            var space = new SpaceStatement(1);
            var endStatement = new EndStatement();

            container.PostStatements.SourceItems.Add(lambdaStart);
            container.SourceItems.Add(space);
            container.SourceItems.Add(methodBody);
            container.SourceItems.Add(endStatement);

            return container;
        }
    }
}
