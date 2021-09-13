using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpxEditor.Backend
{

    public class Engine
    {

        public ConsoleMessage Message { get; set; }

        public void EditGpxFile(string filePath, string outputPath)
        {
            try
            {
                var gpx = GetGpxFile(filePath, outputPath).GetAwaiter().GetResult();
                StripXml.RemoveUnnecessaryTags(gpx);

                Message = new ConsoleMessage()
                {
                    isError = false,
                    MessageText = $"Edited file {gpx.FilePath} saved to {gpx.OutputFilePath}"
                };
            }
            catch (Exception ex)
            {
                Message = new ConsoleMessage()
                {
                    isError = true,
                    MessageText = $"{ex.Message}.{Environment.NewLine} Details:{Environment.NewLine} {ex.InnerException.Message}"
                };
            }

        }

        public bool ValidatePath(string pathToFiles)
        {
            return Directory.Exists(pathToFiles) && Directory.GetFiles(pathToFiles).Length > 0;
        }

        public bool ValidateOrCreatePath(string pathToFile)
        {
            try
            {
                Directory.CreateDirectory(pathToFile);
                return true;
            }
            catch (Exception ex)
            {
                Message = new ConsoleMessage()
                {
                    isError = true,
                    MessageText = $"{ex.Message}.{Environment.NewLine} Details:{Environment.NewLine} {ex.InnerException.Message}"
                };
                return false;
            }
        }

        private async Task<GpxFile> GetGpxFile(string pathToFile, string outputPath)
        {
            if (File.Exists(pathToFile) && Path.GetExtension(pathToFile) == ".gpx")
            {
                return new GpxFile() { FilePath = pathToFile, OutputFilePath = outputPath };
            }
            else
            {
                throw new FileNotFoundException($"File was not found or not supported: {pathToFile}.");
            }
        }

        public string GetTimestamp()
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;  
            return now.ToString("yyyyMMdd_HHmmss"); 
        }
    }
}
