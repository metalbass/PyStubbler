using System.Runtime.CompilerServices;

namespace PyStubbler.Tests
{
    public class GoldenMasterTests
    {
        [Fact]
        public void Test1()
        {
        }

        /// <summary> Regenerates the golden master </summary>
        private static void Main(string[] args)
        {
            GenerateStubs(Path.Join(GetProjectDirectory(), "GoldenMaster"));
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
