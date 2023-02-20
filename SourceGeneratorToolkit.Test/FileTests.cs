namespace SourceGeneratorToolkit.Test;

[TestClass]
public class FileTests
{
    [TestMethod]
    public void Empty_File()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {

            });
        }).Build();

        Assert.AreEqual(@"", file);
    }

    [TestMethod]
    public void Empty_Files()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {

            }).WithFile("file2", file2 =>
            {
            });
        }).Build();

        Assert.AreEqual(@"", file);
    }

    [TestMethod]
    public void Empty_File_Tree()
    {
        var tree = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {

            });
        }).ToTree();

        Assert.AreEqual(@"|-Generator
 |-FileContainer (file1)
", tree);
    }

    [TestMethod]
    public void Empty_Files_Tree()
    {
        var tree = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {

            }).WithFile("file2", file2 =>
            {
            });
        }).ToTree();

        Assert.AreEqual(@"|-Generator
 |-FileContainer (file1)
 |-FileContainer (file2)
", tree);
    }
}