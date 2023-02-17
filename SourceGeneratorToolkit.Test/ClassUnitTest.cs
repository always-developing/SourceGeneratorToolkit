using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class ClassUnitTest
{
    [TestMethod]
    public void Empty_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => { }
                    )
                )
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Public_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPublic()
                    ))
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

public class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Private_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPrivate()
                    ))
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

private class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Protected_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsProtected()
                    )
                , true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

protected class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Internal_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsInternal()
                    )
                , true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

internal class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Static_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsStatic()
                    )
                , true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

static class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Partial_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPartial()
                    )
                , true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

partial class TestClass
{

}
", content);
    }

    //------------------

    [TestMethod]
    public void Empty_Public_Static_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPublic()
                        .AsStatic()
                    )
                , true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

public static class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Private_Static_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPrivate()
                        .AsStatic()
                    )
                , true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

private static class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Protected_Static_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsProtected()
                        .AsStatic()
                    )
                , true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

protected static class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Internal_Static_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsInternal()
                        .AsStatic()
                    )
                , true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

internal static class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Static_Partial_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPartial()
                        .AsStatic()
                    )
                , true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

static partial class TestClass
{

}
", content);
    }

    [TestMethod]
    public void Empty_Public_Static_Partial_Class_Filescoped_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPartial()
                        .AsPublic()
                        .AsStatic()
                    )
                , true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;

public static partial class TestClass
{

}
", content);
    }


    //---------------------------------------------

    [TestMethod]
    public void Empty_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => { }
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Public_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPublic()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    public class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Private_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPrivate()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    private class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Protected_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsProtected()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    protected class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Internal_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsInternal()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    internal class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Static_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsStatic()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    static class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Partial_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPartial()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    partial class TestClass
    {

    }
}
", content);
    }

    //------------------

    [TestMethod]
    public void Empty_Public_Static_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPublic()
                        .AsStatic()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    public static class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Private_Static_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPrivate()
                        .AsStatic()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    private static class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Protected_Static_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsProtected()
                        .AsStatic()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    protected static class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Internal_Static_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsInternal()
                        .AsStatic()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    internal static class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Static_Partial_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPartial()
                        .AsStatic()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    static partial class TestClass
    {

    }
}
", content);
    }

    [TestMethod]
    public void Empty_Public_Static_Partial_Class_Traditional_Namespace()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => ns
                    .WithClass("TestClass", cls => cls
                        .AsPartial()
                        .AsPublic()
                        .AsStatic()
                    )
                , false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{
    public static partial class TestClass
    {

    }
}
", content);
    }

}
