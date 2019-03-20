using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.IO;

namespace Vehicles_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IJsonService JsonService;
        private readonly ICsvService CsvService;
        private readonly IValidationService ValidationService;

        public VehicleController(IJsonService jsonService, ICsvService csvService, IValidationService validationService)
        {
            JsonService = jsonService;
            CsvService = csvService;
            ValidationService = validationService;
        }

        /// <summary>
        /// Process Vehicle Request for validate his string properties
        /// </summary>
        /// <param name="vehicleRequest">VehicleRequest</param>
        /// <returns>ProcessVehicleResponse</returns>
        [HttpPost]
        [Route("ProcessVehicle")]
        public ProcessVehicleResponse ProcessVehicle(VehicleRequest vehicleRequest)
        {
            ProcessVehicleResponse processVehicleResponse = ValidationService.GetProcessVehicleResponse(vehicleRequest);

            if (processVehicleResponse.ResultCode == VehicleValidationResultCode.Valid)
            {
                JsonService.SaveUpdateVehicle(vehicleRequest);
            }

            return processVehicleResponse;
        }

        /// <summary>
        /// Process csv file to import all valid vehicles 
        /// </summary>
        /// <param name="Documento">Documento</param>
        [HttpPost]
        [Route("ImportVehicles")]
        public void ImportVehicles(IFormFile CsvFile)
        {
            JsonService.SaveList(CsvService.ImportCsvVehicles(CsvFile));
        }


        /// <summary>
        /// List of all validated vehicles 
        /// </summary>
        /// <returns>List<VehicleRequest> </returns>
        [HttpGet]
        [Route("GetAllVehicles")]
        public List<VehicleRequest> GetAllVehicles()
        {
            return JsonService.GetAllVehicles();
        }

        /// <summary>
        /// Generate CSV file with all validated vehicles
        /// </summary>
        /// <returns>export.csv</returns>
        [HttpGet]
        [Route("ExportVehicles")]
        [Produces("text/csv")]
        public IActionResult DescargaMarcaje()
        {
            return File(new MemoryStream(CsvService.GenerateCSVExport()), "text/csv", "export.csv");
        }

    }
}
