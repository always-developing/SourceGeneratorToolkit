using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class NamespaceUnitTests
{
    [TestMethod]
    public void Namespace_Default_Parameters()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => { })
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;


", content);
    }

    [TestMethod]
    public void Namespace_Explicit_FileScoped()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => { }, true)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace;


", content);
    }

    [TestMethod]
    public void Namespace_Explicit_Not_FileScoped()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithNamespace("TestNamespace", ns => { }, false)
            ).Build();

        Assert.AreEqual(@"namespace TestNamespace
{

}
", content);
    }
}
