using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class MethodUnitTests
{

    [TestMethod]
    public void Empty_Method_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .WithMethod("TestMethod", method => { }
                        )
                    )
                )
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

class TestClass
{
    void TestMethod()
}
", content);
    }

    [TestMethod]
    public void Empty_Public_Method_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .WithMethod("TestMethod", method => method
                            .AsPublic()
                        )
                    )
                )
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

class TestClass
{
    public void TestMethod()
}
", content);
    }

    [TestMethod]
    public void Empty_Internal_Method_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .WithMethod("TestMethod", method => method
                            .AsInternal()
                        )
                    )
                )
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

class TestClass
{
    internal void TestMethod()
}
", content);
    }

    [TestMethod]
    public void Empty_Private_Method_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .WithMethod("TestMethod", method => method
                            .AsPrivate()
                        )
                    )
                )
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

class TestClass
{
    private void TestMethod()
}
", content);
    }

    [TestMethod]
    public void Empty_Protected_Method_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .WithMethod("TestMethod", method => method
                            .AsProtected()
                        )
                    )
                )
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

class TestClass
{
    protected void TestMethod()
}
", content);
    }

    [TestMethod]
    public void Empty_Partial_Method_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .WithMethod("TestMethod", method => method
                            .AsPartial()
                        )
                    )
                )
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

class TestClass
{
    partial void TestMethod()
}
", content);
    }

    [TestMethod]
    public void Empty_Public_Partial_Method_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .WithMethod("TestMethod", method => method
                            .AsPartial()
                            .AsPublic()
                        )
                    )
                )
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

class TestClass
{
    public partial void TestMethod()
}
", content);
    }

    [TestMethod]
    public void Empty_Public_Return_Int_Method_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .WithMethod("TestMethod", method => method
                            .AsPublic()
                            .WithReturnType("int")
                        )
                    )
                )
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

class TestClass
{
    public int TestMethod()
}
", content);
    }

    [TestMethod]
    public void Exp_Body_Public_Return_Int_Method_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .WithMethod("TestMethod", method => method
                            .AsPublic()
                            .WithReturnType("int")
                            .WithExpressionBody("return 10")
                        )
                    )
                )
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

class TestClass
{
    public int TestMethod() => return 10;
}
", content);
    }


}
