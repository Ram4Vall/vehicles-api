using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace VehiclesRepository
{
    public class JsonService : IJsonService
    {
        private readonly string FILE_NAME = "vehicles.json";
        private readonly string ROOT = "wwwroot";
        private readonly IHostingEnvironment HostingEnvironment;

        public JsonService(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        private string ReadFile()
        {
            string jsonResult = "";

            var path = Path.Combine(
                HostingEnvironment.WebRootPath,
                FILE_NAME
            );

            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonResult = streamReader.ReadToEnd();
            }

            return jsonResult;
        }

        private void WriteFile(string jsonData)
        {
            var path = Path.Combine(
                HostingEnvironment.WebRootPath,
                FILE_NAME
            );

            using (var streamWriter = File.CreateText(path))
            {
                streamWriter.Write(jsonData);
            }
        }
    }
}
