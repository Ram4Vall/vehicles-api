using CsvHelper;
using Entities.Models;
using System.Collections.Generic;
using System.IO;

namespace Services
{
    public class CsvService : ICsvService
    {
        private readonly IJsonService JsonService;

        public CsvService(IJsonService jsonService)
        {
            JsonService = jsonService;
        }

        public byte[] GenerateCSVExport()
        {
            List<VehicleRequest> vehicles = JsonService.GetAllVehicles();
            byte[] result;

            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ";";

                csvWriter.WriteField("VehicleId");
                csvWriter.WriteField("Type");
                csvWriter.WriteField("ManufacturerNameShort");
                csvWriter.WriteField("Price");
                csvWriter.NextRecord();

                foreach (var vehicle in vehicles)
                {
                    csvWriter.WriteField(vehicle.VehicleId);
                    csvWriter.WriteField(vehicle.Type);
                    csvWriter.WriteField(vehicle.ManufacturerNameShort);
                    csvWriter.WriteField(vehicle.Price);
                    csvWriter.NextRecord();
                }

                writer.Flush();
                result = mem.ToArray();
            }

            return result;
        }

    }
}
