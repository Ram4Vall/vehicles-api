using Microsoft.AspNetCore.Mvc;
using Vehicles_API.Models;

namespace Vehicles_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
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
    }
}
