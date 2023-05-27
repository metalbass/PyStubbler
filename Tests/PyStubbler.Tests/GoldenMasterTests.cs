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
    [UseReporter(typeof(VisualStudioReporter), typeof(XUnit2Reporter))]
    public class GoldenMasterTests
    {
        private readonly string goldenMasterDirectory;
        private readonly string testDataDirectory;

        public GoldenMasterTests()
        {
            goldenMasterDirectory = Path.Join(GetProjectDirectory(), "GoldenMaster");
            testDataDirectory = Path.Join(Directory.GetCurrentDirectory(), "TestData");

            if (Directory.Exists(testDataDirectory))
            {
                Directory.Delete(testDataDirectory, recursive: true);
            }
        }

        [Fact]
        public void TryFailingPublishing()
        {
            Assert.Fail("This should fail the action before we publish this version");
        }

        [Fact]
        public void CompareAgainstGoldenMaster()
        {
            GenerateStubs(testDataDirectory);

            foreach (string actualFilePath in ListStubFilePaths(testDataDirectory))
            {
                string relativePath = Path.GetRelativePath(testDataDirectory, actualFilePath);
                string expectedFilePath = Path.Join(goldenMasterDirectory, relativePath);

                Approvals.Verify(new FileApprovalWriter(expectedFilePath, actualFilePath));
            }
        }

        [Fact]
        public void GeneratedStubFiles()
        {
            GenerateStubs(testDataDirectory);

            Approvals.VerifyAll("Generated stub files", ListStubFilePaths(testDataDirectory),
                formatter: absolutePath => Path.GetRelativePath(testDataDirectory, absolutePath));
        }

        private static void GenerateStubs(string destinationFolder)
        {
            string targetAssemblyPath = Path.Join(Directory.GetCurrentDirectory(), "ExampleCSharpLibrary.dll");
            string destPath = Path.Join(destinationFolder, "ExampleCSharpLibrary");

            StubBuilder.BuildAssemblyStubs(targetAssemblyPath, destPath);
        }

        private static IEnumerable<string> ListStubFilePaths(string directory)
        {
            return Directory.EnumerateFiles(directory, "*.pyi", SearchOption.AllDirectories);
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

            if (!File.Exists(expectedFilePath))
            {
                string directorypath = Path.GetDirectoryName(expectedFilePath)!;
                if (!Directory.Exists(directorypath))
                {
                    Directory.CreateDirectory(directorypath);
                }

                File.Create(expectedFilePath).Close();
            }

            if (!File.Exists(actualFilePath))
            {
                throw new("Existing File is required: '" + actualFilePath + "'");
            }
        }

        public string GetApprovalFilename(string basename) => expectedFilePath;
        public string GetReceivedFilename(string basename) => actualFilePath;
        public string WriteReceivedFile(string received) => actualFilePath;
    }
}
