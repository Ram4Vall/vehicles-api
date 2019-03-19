using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace Vehicles_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IJsonService JsonService;

        public VehicleController(IJsonService jsonService)
        {
            JsonService = jsonService;
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
            return new ProcessVehicleResponse(vehicleRequest);
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
    }
}
