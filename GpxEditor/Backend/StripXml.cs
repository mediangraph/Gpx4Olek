using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpxEditor.Backend
{
    public static class StripXml
    {
        private static string START_TAG = "<trkpt ";
        private static string ELE_START_TAG = "<ele>";
        private static string ELE_END_TAG = "</ele>";


        public static void RemoveUnnecessaryTags(GpxFile gpx)
        {
            if(gpx == null)
            {
                throw new FileNotFoundException("Failed when trying to edit gpx file: the file does not exists.");
            }

            try
            {
                var copyPath = CopyFileToTemp(gpx.FilePath);
                CreateOutputDir(gpx);
                using (var writer = new StreamWriter(gpx.OutputFilePath))
                {
                    int indexLines = 0;
                    using (var reader = new StreamReader(copyPath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var editedLine = RemoveTagsFromLine(line, indexLines);
                            SaveLineToFile(editedLine, writer, gpx.OutputFilePath);
                            indexLines++;
                        }
                    }
                }

                ClearTempFiles(copyPath);
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed while removing tags for file: {gpx.FilePath}", ex);
            }
        }

        private static string RemoveTagsFromLine(string line, int index)
        {
            try
            {
                var editedLine = line;
                if (line.TrimStart().StartsWith(START_TAG))
                {
                    editedLine = line.Substring(0, line.IndexOf(ELE_START_TAG));
                    int endTagIndex = line.IndexOf(ELE_END_TAG) + ELE_END_TAG.Length;
                    editedLine += line.Substring(endTagIndex, line.Length - endTagIndex);
                }
                return editedLine;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't remove tags for line: {index}", ex);
            }
        }

        private static void SaveLineToFile(string editedLine, StreamWriter writer, string outputFile)
        {
            try
            {
                writer.WriteLine(editedLine);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't save line to file: {outputFile}", ex);
            }
        }

        private static void CreateOutputDir(GpxFile gpx)
        {
            try
            {
                var dir = Path.GetDirectoryName(gpx.OutputFilePath);
                if (dir != null && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't create output dir: {gpx.OutputFilePath}", ex);
            }
        }

        public static string CopyFileToTemp(string filePath)
        {
            var copyFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            try
            {
                File.Copy(filePath, copyFile);
                return copyFile;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't copy file to temp path: {filePath}", ex);
            }
        }

        private static void ClearTempFiles(string copyPath)
        {
            try
            {
                var fileTemp = new FileInfo(copyPath);
                fileTemp.Delete();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't clear temp files: {copyPath}", ex);
            }
        }
    }
}
