using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;
using ApprovalTests.Core;
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
        [UseReporter(typeof(VisualStudioReporter), typeof(XUnit2Reporter))]
        public void CompareAgainstGoldenMaster()
        {
            string testDataFolder = Path.Join(Directory.GetCurrentDirectory(), "TestData");

            GenerateStubs(testDataFolder);
            
            string relativePath = Path.Join("ExampleCSharpLibrary", "ExampleCSharpLibrary", "__init__.pyi");

            string expectedFilePath = Path.Join(goldenMasterDirectory, relativePath);
            string actualFilePath = Path.Join(testDataFolder, relativePath);

            Approvals.Verify(new FileApprovalWriter(expectedFilePath, actualFilePath));
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

    public class FileApprovalWriter : IApprovalWriter
    {
        private readonly string actualFilePath;
        private readonly string expectedFilePath;

        public FileApprovalWriter(string expectedFilePath, string actualFilePath)
        {
            this.actualFilePath = actualFilePath;
            this.expectedFilePath = expectedFilePath;

            if (!File.Exists(actualFilePath))
            {
                throw new("Existing File is required: '" + actualFilePath + "'");
            }
        }

        public string GetApprovalFilename(string basename)
        {
            return expectedFilePath;
        }

        public string GetReceivedFilename(string basename)
        {
            return actualFilePath;
        }

        public string WriteReceivedFile(string received)
        {
            return actualFilePath;
        }
    }
}
