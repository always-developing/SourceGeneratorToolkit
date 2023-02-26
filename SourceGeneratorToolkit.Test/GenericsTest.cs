using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class GenericsTest
{
    [TestMethod]
    public void Empty_Class_One_Generic()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => 
                    {
                        cls.AddGeneric("T");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass<T>
    {
    }
}

", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Generic()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls
                        .AddGeneric("T")
                        .AddGeneric("T2"); ;
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass<T, T2>
    {
    }
}

", file);
    }

    [TestMethod]
    public void Empty_Class_One_Generic_One_Coonstraint()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddGeneric("T")
                            .WithGenericConstraint("T", "new()");

                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass<T> where T : new()
    {
    }
}

", file);
    }

    [TestMethod]
    public void Empty_Class_One_Generic_Multi_Coonstraint()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddGeneric("T")
                        .WithGenericConstraint("T", "new()")
                        .WithGenericConstraint("T", "ITemp");

                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass<T> where T : new(), ITemp
    {
    }
}

", file);
    }
}
