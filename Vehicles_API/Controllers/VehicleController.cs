using CsvHelper;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vehicles_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IJsonService JsonService;
        private readonly ICsvService CsvService;

        public VehicleController(IJsonService jsonService, ICsvService csvService)
        {
            JsonService = jsonService;
            CsvService = csvService;
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
            ProcessVehicleResponse processVehicleResponse = new ProcessVehicleResponse(vehicleRequest);

            if (processVehicleResponse.ResultCode == VehicleValidationResultCode.Valid)
            {
                JsonService.SaveUpdateVehicle(vehicleRequest);
            }

            return processVehicleResponse;
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
