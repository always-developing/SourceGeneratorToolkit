namespace SourceGeneratorToolkit.Test;

[TestClass]
public class FileUnitTests
{
    [TestMethod]
    public void No_File()
    {
        var content = SourceGenerator.ConfigureGenerator().Build();
        Assert.AreEqual("", content);
    }

    [TestMethod]
    public void Blank_File()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => { })
            .Build();

        Assert.AreEqual("", content);
    }

    [TestMethod]
    public void Single_Using_File()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithUsing("System")
            ).Build();

        Assert.AreEqual(@"using System;
", content);
    }

    [TestMethod]
    public void Multiple_Using_File()
    {
        var content = SourceGenerator.ConfigureGenerator()
            .WithFile("", file => file
                .WithUsing("System")
                .WithUsing("System.Text.Json")
            ).Build();

        Assert.AreEqual(@"using System;
using System.Text.Json;
", content);
    }
}