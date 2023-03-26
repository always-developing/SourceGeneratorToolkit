﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class InheritenceTest
{
    [TestMethod]
    public void Empty_Class_One_Inheritence()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => 
                    {
                        cls.WithInheritence("StringBuilder");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass : StringBuilder
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Inheritence()
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
                        .WithInheritence("StringBuilder")
                        .WithInheritence("Task");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass : Task
    {
    }
}", file);
    }
}
