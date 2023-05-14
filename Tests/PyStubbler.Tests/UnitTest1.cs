namespace PyStubbler.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
        }

        static void Main(string[] args)
        {
            string targetAssemblyPath = Path.Join(Directory.GetCurrentDirectory(), "ExampleCSharpLibrary.dll");
            string destPath = Path.Join(Directory.GetCurrentDirectory(), "GoldenMaster", "ExampleCSharpLibrary");

            StubBuilder.BuildAssemblyStubs(targetAssemblyPath, destPath);
        }
    }
}