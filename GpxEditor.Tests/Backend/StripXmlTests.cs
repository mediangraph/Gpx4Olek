using GpxEditor.Backend;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace GpxEditor.Tests
{
    public class StripXmlTests : IDisposable
    {

        const string TestFileName = @"NewFile.txt";
        const string TestFileDir = @"C:\Tests";
        const string TestOutputFolder = @"Edited";

        public StripXmlTests()
        {
            ClearCopyFile();
        }

        [Fact]
        public void ShouldCopyFileToTempGiveSameSize()
        {
            //Assing
            var filePath = CreateNewFile();

            //Act
            var outputPath = StripXml.CopyFileToTemp(filePath);
            //Assert

            var origFile = new FileInfo(filePath);
            var copiedFile = new FileInfo(outputPath);

            Assert.Equal(origFile.Length, copiedFile.Length);
        }

        //[Fact]
        //public void ShouldRemoveTagsFromLine()
        //{
        //    var line = "<trkpt lat=\"50.45317031443119\" lon=\"19.51680287718773\"><ele>395</ele><time>2021-09-11T08:57:16</time><name>WP 001</name></trkpt>";
        //    var expectedLine = "<trkpt lat=\"50.45317031443119\" lon=\"19.51680287718773\"><time>2021-09-11T08:57:16</time><name>WP 001</name></trkpt>";
        //    var editedLine = StripXml.RemoveTagsFromLine(line);

        //    Assert.Equal(expectedLine, editedLine);
        //}

        [Fact]
        public void ShouldRemoveUnnecessaryTags()
        {
            var gpx = new GpxFile();
            gpx.FilePath = CreateGpxFile();
            gpx.OutputFilePath = Path.Combine(Path.GetDirectoryName(gpx.FilePath), TestOutputFolder);

            StripXml.RemoveUnnecessaryTags(gpx);

            var assertFile = new FileInfo(Path.Combine(Environment.CurrentDirectory, @"Resources\", "TestGpx_Result.gpx"));
            var copiedFile = new FileInfo(gpx.OutputFilePath);

            Assert.Equal(assertFile.Length, copiedFile.Length);
        }

        private string CreateNewFile()
        {
            var path = Directory.CreateDirectory(TestFileDir);
            var filePath = Path.Combine(path.FullName, TestFileName);
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("This is sample file.");
            }
            return filePath;
        }

        private void ClearCopyFile()
        {
            foreach (var file in Directory.CreateDirectory(TestFileDir).EnumerateFiles())
            {
                file.Delete();
            }

            var fileTemp = new FileInfo(Path.Combine(Path.GetTempPath(), TestFileName));
            fileTemp.Delete();
        }

        private string CreateGpxFile()
        {
            var path = Directory.CreateDirectory(TestFileDir);
            var filePath = Path.Combine(path.FullName, "TestGpx.gpx");
            var testFile = Path.Combine(Environment.CurrentDirectory, @"Resources\", "TestGpx.gpx");

            File.Copy(testFile, filePath);

            return filePath;
        }

        public void Dispose()
        {
            
        }
    }
}
