﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class PropertyTest
{
    [TestMethod]
    public void Class_Default_Property()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        int myIntField { get; set; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder.AsPublic();
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        public int myIntField { get; set; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Internal_Property_DefaultValue()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsInternal()
                            .WithValue("100");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        internal int myIntField { get; set; } = 100;
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property_No_Getter()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .WithNoGetter();
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        public int myIntField { set; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property_No_Setter()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .WithNoSetter();
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        public int myIntField { get; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property_With_Initer()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .WithIniter();
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        public int myIntField { get; init; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Virtual_Property()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .AsVirtual();
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        public virtual int myIntField { get; set; }
    }
}", file);
    }
}