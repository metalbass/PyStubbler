using System.Runtime.CompilerServices;

namespace PyStubbler.Tests
{
    /// <summary>
    /// https://blog.thecodewhisperer.com/permalink/surviving-legacy-code-with-golden-master-and-sampling
    /// </summary>
    public class GoldenMasterTests
    {
        private static string goldenMasterDirectory = Path.Join(GetProjectDirectory(), "GoldenMaster");

        [Fact]
        public void CompareAgainstGoldenMaster()
        {
            string testDataFolder = Path.Join(Directory.GetCurrentDirectory(), "TestData");

            GenerateStubs(testDataFolder);

            // TODO: since this only works with one file, replace with texttest?
            string relativePath = Path.Join("ExampleCSharpLibrary", "ExampleCSharpLibrary", "__init__.pyi");

            string expected = File.ReadAllText(Path.Join(goldenMasterDirectory, relativePath));
            string actual = File.ReadAllText(Path.Join(testDataFolder, relativePath));

            Assert.Equal(expected, actual);
        }

        /// <summary> Regenerates the golden master </summary>
        private static void Main(string[] args)
        {
            GenerateStubs(goldenMasterDirectory);
        }

        private static void GenerateStubs(string destinationFolder)
        {
            string targetAssemblyPath = Path.Join(Directory.GetCurrentDirectory(), "ExampleCSharpLibrary.dll");
            string destPath = Path.Join(destinationFolder, "ExampleCSharpLibrary");

            StubBuilder.BuildAssemblyStubs(targetAssemblyPath, destPath);
        }

        /// <remarks>
        /// Only works if you've compiled the project on the same machine as the one executing it,
        /// since it inlines the absolute path to the file on the machine during compilation.
        /// </remarks>
        private static string GetProjectDirectory([CallerFilePath] string callerFilePath = "")
        {
            return Path.GetDirectoryName(callerFilePath)!;
        }
    }
}
