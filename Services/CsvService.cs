using CsvHelper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services
{
    public class CsvService : ICsvService
    {
        private readonly IJsonService JsonService;
        private readonly IValidationService ValidationService;

        public CsvService(IJsonService jsonService, IValidationService validationService)
        {
            JsonService = jsonService;
            ValidationService = validationService;
        }

        public byte[] GenerateCSVExport()
        {
            List<VehicleRequest> validVehicles = JsonService.GetAllVehicles().FindAll(
                x => ValidationService.ValidateVehicleRequest(x) == VehicleValidationResultCode.Valid
            );

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

                foreach (var vehicle in validVehicles)
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

        public List<VehicleRequest> ImportCsvVehicles(IFormFile CsvFile)
        {
            List<VehicleRequest> vehicles = new List<VehicleRequest>();

            if (CsvFile != null && CsvFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    CsvFile.CopyTo(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    using (StreamReader streamReader = new StreamReader(memoryStream))
                    using (var csvReader = new CsvReader(streamReader))
                    { 
                        vehicles = csvReader.GetRecords<VehicleRequest>().ToList();

                    }
                }
            }

            return vehicles;
        }

    }
}
