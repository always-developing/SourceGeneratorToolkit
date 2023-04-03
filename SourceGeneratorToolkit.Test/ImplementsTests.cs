﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class ImplementsTests
{
    [TestMethod]
    public void Empty_Class_One_Implements()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithImplementation("IStringBuilder");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass : IStringBuilder
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Implements()
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
                        .WithImplementation("IStringBuilder")
                        .WithImplementation("ITask");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass : IStringBuilder, ITask
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_One_Implements_Inherits()
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
                        .WithImplementation("IStringBuilder")
                        .WithInheritence("Baseclass");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass : Baseclass, IStringBuilder
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Implements_Inherits()
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
                        .WithImplementation("IStringBuilder")
                        .WithInheritence("Baseclass")
                        .WithImplementation("ITask");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass : Baseclass, IStringBuilder, ITask
    {
    }
}", file);
    }
}