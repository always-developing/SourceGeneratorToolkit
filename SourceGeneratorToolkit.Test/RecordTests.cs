using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class RecordTests
{
    [TestMethod]
    public void Empty_Record()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithRecord("MyRecord", cls => { });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    record MyRecord();
}", file);
    }

    [TestMethod]
    public void Empty_Record_Class()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithRecord("MyRecord", rec => 
                    {
                        rec.AsClass();
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    record class MyRecord();
}", file);
    }

    [TestMethod]
    public void Empty_Record_Struct()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithRecord("MyRecord", rec =>
                    {
                        rec.AsStruct();
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    record struct MyRecord();
}", file);
    }

    [TestMethod]
    public void Public_Record_One_Param()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithRecord("MyRecord", rec =>
                    {
                        rec.AsPublic()
                        .AddPositionalParameter("string", "Name");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public record MyRecord(string Name);
}", file);
    }

    [TestMethod]
    public void Internal_Record_Multi_Param()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithRecord("MyRecord", rec =>
                    {
                        rec.AsInternal()
                        .AddPositionalParameter("int", "Id")
                        .AddPositionalParameter("string", "Name")
                        .AddPositionalParameter("int", "Age");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    internal record MyRecord(int Id, string Name, int Age);
}", file);
    }

    [TestMethod]
    public void Record_Generic_Param_With_Contraint()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithRecord("MyRecord", rec =>
                    {
                        rec.AsPrivate()
                        .AddGeneric("T")
                        .AddPositionalParameter("T", "Id");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    private record MyRecord<T>(T Id);
}", file);
    }

    [TestMethod]
    public void Private_Record_Generic_Param()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithRecord("MyRecord", rec =>
                    {
                        rec.AsPrivate()
                        .AddGeneric("T")
                        .WithGenericConstraint("T", "new()")
                        .AddPositionalParameter("T", "Id");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    private record MyRecord<T>(T Id)
        where T : new();
}", file);
    }

    [TestMethod]
    public void Public_Record_With_Property()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithRecord("MyRecord", rec =>
                    {
                        rec.AsPublic()
                        .AddProperty("Guid", "Id");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public record MyRecord
    {
        Guid Id { get; set; }
    }
}", file);
    }

    [TestMethod]
    public void Public_Record_With_Positional_And_Property()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithRecord("MyRecord", rec =>
                    {
                        rec.AsPublic()
                        .AddProperty("Guid", "Id", prop =>
                        {
                            prop
                            .AsPublic()
                            .WithIniter()
                            .WithGetter();
                        })
                        .AddPositionalParameter("string", "Name");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public record MyRecord(string Name)
    {
        public Guid Id { get; init; }
    }
}", file);
    }
}
