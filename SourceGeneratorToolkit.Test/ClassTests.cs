using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class ClassTests
{
    [TestMethod]
    public void Empty_Class_NoModifiers_Trad_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => { });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
    }
}

", file);
    }

    [TestMethod]
    public void Empty_Class_NoModifiers_Filescoped_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => { });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns;

class myClass
{
}

", file);
    }
}
