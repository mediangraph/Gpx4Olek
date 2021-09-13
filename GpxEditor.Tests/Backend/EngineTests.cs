using GpxEditor.Backend;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GpxEditor.Tests.Backend
{
    public class EngineTests : IDisposable
    {

        const string TestFileDir = @"C:\Tests";
        const string TestFolderName = @"Folder";
        const string TestOutputFolder = @"Edited";

        public EngineTests()
        {
            ClearCopyFile();
        }

        [Fact]
        public void ShouldEditGpxFiles()
        {
            var dir = CopyGpxFolder();
            var engine = new Engine();
            var file = Directory.GetFiles(dir).First();
            engine.EditGpxFile(file, Path.Combine(dir, TestOutputFolder));
        }

        private void ClearCopyFile()
        {
            foreach (var file in Directory.CreateDirectory(Path.Combine(TestFileDir, TestFolderName)).EnumerateFiles("*.*",SearchOption.AllDirectories))
            {
                file.Delete();
            }
        }

        private string CopyGpxFolder()
        {
            var dir = Path.Combine(TestFileDir, TestFolderName);
            Directory.CreateDirectory(dir);
            var testDir = Path.Combine(Environment.CurrentDirectory, @"Resources\", TestFolderName);
            foreach (var file in Directory.CreateDirectory(testDir).EnumerateFiles())
            {
                File.Copy(file.FullName, Path.Combine(dir,file.Name));
            }

            return dir;
        }

        public void Dispose()
        {
            
        }
    }
}
